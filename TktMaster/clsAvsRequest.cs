using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TktMaster
{
        class clsAvsRequest
        {
            public List<AvsRequest> avs_request { get; set; }
        }

            public class Avsdetail
        {
            public List<string> AttractionId { get; set; }
            public List<object> AttractionOrganization { get; set; }
            public string Country { get; set; }
            public string Host { get; set; }
            public string VenueId { get; set; }
            public List<object> VenueOrganization { get; set; }
        }

        public class AvsRequest
        {
            public List<Avsdetail>  __Objavsrequest { get; set; }
            public string Eventid { get; set; } 
        }

}
