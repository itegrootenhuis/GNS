using System.Collections.Generic;
using GNS.Core.Models;

namespace GNS.Web.Models
{
    public class AdminViewModel
    {
        public List<Group> Groups { get; set; }

        public List<Record> Records { get; set; }

        public RecordForm RecordForm { get; set; }
    }
}
