using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TktMaster
{
  
    public class Availability
    {
        public string EventId { get; set; }
        public int MsgCode { get; set; }
    }

    public class clsAvsResponse
    {
        public string ShowAvailability { get; set; }
        public List<Availability> availabilities { get; set; }
    }
}
