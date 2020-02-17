#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2020/2/17 10:58:20
** VERSION:     V1.0.0
**    GUID:     537ac477-c175-4a1e-b1ce-59269fa21bc2
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Models
{
    public class Today
    {
        public int Confirm { get; set; }

        public int Suspect { get; set; }

        public int Dead { get; set; }

        public int Heal { get; set; }

        public bool IsUpdated { get; set; }
    }
}
