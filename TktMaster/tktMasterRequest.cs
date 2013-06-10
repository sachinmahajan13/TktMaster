using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TktMaster
{
    class tktMasterRequest
    {
        public class Eventid
        {
            public string Country { get; set; }
            public string VenueId { get; set; }
            public string Host { get; set; }
            public List<object> AttractionOrganization { get; set; }
            public List<object> VenueOrganization { get; set; }
            public List<string> AttractionId { get; set; }
        }

        public class AvsRequest
        {
            public List<Eventid> objEventid { get; set; }
           
        }

        public class RootObject
        {
            public List<AvsRequest> avs_request { get; set; }
        }
    }
}
