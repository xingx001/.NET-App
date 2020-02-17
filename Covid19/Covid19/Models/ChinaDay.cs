#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2020/2/17 10:57:32
** VERSION:     V1.0.0
**    GUID:     b5135795-8cd0-49eb-9d81-f6d64a2a7cdd
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Models
{
    public class ChinaDay : Overview
    {
        public decimal DeadRate { get; set; }

        public decimal HealRate { get; set; }

        public string Date { get; set; }
    }
}
