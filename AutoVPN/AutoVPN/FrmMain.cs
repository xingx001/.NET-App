using DotRas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutoVPN
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Holds a value containing the handle used by the connection that was dialed.
        /// </summary>
        private RasHandle handle = null;

        private List<RasEntry> entryList = new List<RasEntry>();

        private Action<string> logAction;

        public const string EntryName = "VPN Connection";
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitRasEntryList();
            logAction = this.AppendText;
        }

        #region 初始化RasEntry列表
        /// <summary>
        /// 初始化RasEntry列表
        /// </summary>
        private void InitRasEntryList()
        {
            string phoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);

            this.cmbPhoneNumber.Items.Clear();
            this.entryList.Clear();
            using (DotRas.RasPhoneBook pbk = new DotRas.RasPhoneBook())
            {
                pbk.Open(phoneBookPath);

                foreach (RasEntry entry in pbk.Entries)
                {
                    if (RasEntryType.Vpn == entry.EntryType)
                    {
                        AddEntry(entry);
                    }
                }
            }
            if (this.cmbPhoneNumber.Items.Count > 0)
                this.cmbPhoneNumber.SelectedIndex = 0;
        }
        #endregion


        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearPhoneBook();
            InitRasEntryList();
        }

        #region 清除PhoneBook
        /// <summary>
        /// 清除PhoneBook
        /// </summary>
        private static void ClearPhoneBook()
        {
            string phoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            using (DotRas.RasPhoneBook pbk = new DotRas.RasPhoneBook())
            {
                pbk.Open(phoneBookPath);
                pbk.Entries.Clear();
            }
        }
        #endregion

        #region Entry Add
        /// <summary>
        /// Entry Add
        /// </summary>
        private void AddRasEntry(RasEntry newEntry)
        {
            string phoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            using (DotRas.RasPhoneBook pbk = new DotRas.RasPhoneBook())
            {
                pbk.Open(phoneBookPath);
                pbk.Entries.Add(newEntry);
            }
        }
        #endregion

        #region 列表Add
        /// <summary>
        /// 列表Add
        /// </summary>
        /// <param name="entry"></param>
        private void AddEntry(RasEntry entry)
        {
            this.entryList.Add(entry);
            this.cmbPhoneNumber.Items.Add(new ComboBoxItem
            {
                Text = entry.PhoneNumber,
                Val = entry.Name
            });
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = this.txtUser.Text;
            string pwd = this.txtPwd.Text;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
                return;

            object selectItem = this.cmbPhoneNumber.SelectedItem;
            if (selectItem == null)
            {
                if (!string.IsNullOrEmpty(this.cmbPhoneNumber.Text))
                {
                    RasEntry newEntry = RasEntry.CreateVpnEntry(EntryName,
                        this.cmbPhoneNumber.Text, RasVpnStrategy.PptpOnly,
                    RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn), false);
                    AddRasEntry(newEntry);
                    AddEntry(newEntry);
                    selectItem = new ComboBoxItem { Text = this.cmbPhoneNumber.Text, Val = EntryName };
                }
                else
                {
                    return;
                }
            }
            ComboBoxItem item = (ComboBoxItem)selectItem;
            RasEntry entry = entryList.Single(s => s.Name.Equals(item.Val));
            if (entry == null)
                return;
            this.Dialer.EntryName = entry.Name;
            this.Dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            try
            {
                // Set the credentials the dialer should use.
                this.Dialer.Credentials = new NetworkCredential(user, pwd);

                // NOTE: The entry MUST be in the phone book before the connection can be dialed.
                // Begin dialing the connection; this will raise events from the dialer instance.
                this.handle = this.Dialer.DialAsync();

                // Enable the disconnect button for use later.
                this.btnLogout.Enabled = true;
            }
            catch (Exception ex)
            {
                this.AppendText(ex.ToString());
            }
        }
        #endregion

        #region 登出
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (this.Dialer.IsBusy)
            {
                // The connection attempt has not been completed, cancel the attempt.
                this.Dialer.DialAsyncCancel();
            }
            else
            {
                // The connection attempt has completed, attempt to find the connection in the active connections.
                RasConnection connection = RasConnection.GetActiveConnectionByHandle(this.handle);
                if (connection != null)
                {
                    // The connection has been found, disconnect it.
                    connection.HangUp();
                }
            }
        }
        #endregion

        #region Occurs when the dialer state changes during a connection attempt.
        /// <summary>
        /// Occurs when the dialer state changes during a connection attempt.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An <see cref="DotRas.StateChangedEventArgs"/> containing event data.</param>
        private void Dialer_StateChanged(object sender, StateChangedEventArgs e)
        {
            this.Invoke(logAction, e.State.ToString() + "\r\n");
        }
        #endregion

        #region Occurs when the dialer has completed a dialing operation.
        /// <summary>
        /// Occurs when the dialer has completed a dialing operation.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An <see cref="DotRas.DialCompletedEventArgs"/> containing event data.</param>
        private void Dialer_DialCompleted(object sender, DialCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Invoke(logAction, "Cancelled!");
            }
            else if (e.TimedOut)
            {
                this.Invoke(logAction, "Connection attempt timed out!");
            }
            else if (e.Error != null)
            {
                this.Invoke(logAction, e.Error.ToString());
            }
            else if (e.Connected)
            {
                this.Invoke(logAction, "Connection successful!");
            }

            if (!e.Connected)
            {
                // The connection was not connected, disable the disconnect button.
                this.btnLogout.Enabled = false;
            }
        }
        #endregion

        #region log
        /// <summary>
        /// log
        /// </summary>
        /// <param name="txt"></param>
        private void AppendText(string txt)
        {
            bool scroll = false;
            if (this.lsb.TopIndex == this.lsb.Items.Count - (int)(this.lsb.Height / this.lsb.ItemHeight))
                scroll = true;
            this.lsb.Items.Add(" " + txt);
            if (scroll)
                this.lsb.TopIndex = this.lsb.Items.Count - (int)(this.lsb.Height / this.lsb.ItemHeight);
        }

        #endregion

    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Val { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
