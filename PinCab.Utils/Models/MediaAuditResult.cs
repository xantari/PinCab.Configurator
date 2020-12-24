using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public class MediaAuditResult
    {
        public MediaAuditResult() { }

        public FrontEnd FrontEnd { get; set; }

        public string FullPathToFile { get; set; }

        public MediaAuditStatus Status { get; set; }

        public MediaType MediaType { get; set; }
    }
}
