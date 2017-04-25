using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.SSO.Models
{
    public class AppInfo
    {
        public string FAppKey { get; set; }

        public string FAppSecret { get; set; }

        public string FTitle { get; set; }

        public string FIcon { get; set; }

        public string FRemark { get; set; }

        public string FDefaultBackUrl { get; set; }

        public bool FIsEnable { get; set; }

        public DateTime FCreateTime { get; set; }

        public bool FIsDelete { get; set; }
    }
}
