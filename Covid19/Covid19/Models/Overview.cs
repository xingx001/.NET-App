#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2020/2/17 10:57:07
** VERSION:     V1.0.0
**    GUID:     ac94a1c1-c1d8-48df-8b06-cf0529996ce4
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19.Models
{
    public class Overview
    {
        public int Confirm { get; set; }

        public int Suspect { get; set; }

        public int Dead { get; set; }

        public int Heal { get; set; }
    }
}
