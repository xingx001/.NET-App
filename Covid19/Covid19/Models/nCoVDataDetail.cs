#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2020/2/17 10:56:47
** VERSION:     V1.0.0
**    GUID:     ed222a43-b43d-44c1-a80c-fd69248dfa3a
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Models
{
    public class nCoVDataDetail
    {
        public nCoVDataDetail()
        {
            this.ChinaTotal = new Overview();
            this.ChinaAdd = new Overview();
            this.ChinaDayList = new List<ChinaDay>();
            this.ChinaDayAddList = new List<ChinaDay>();
            this.AreaTree = new List<AreaTree>();
        }

        public DateTime LastUpdateTime { get; set; }

        public Overview ChinaTotal { get; set; }

        public Overview ChinaAdd { get; set; }

        public bool IsShowAdd { get; set; }

        public List<ChinaDay> ChinaDayList { get; set; }

        public List<ChinaDay> ChinaDayAddList { get; set; }

        public List<AreaTree> AreaTree { get; set; }
    }
}
