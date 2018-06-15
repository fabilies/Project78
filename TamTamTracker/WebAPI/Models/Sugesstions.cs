using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SugesstionsResponse
    {
        public string mac_adres { get; set; } // User mac adres 
        public int suggestion_id { get; set; } // Guid_id 
        public Boolean IsSuggestionAccepted { get; set; } // IsSuggestionAccepted
    }
    public class SuggestionGenerator
    {
        public string mac_adres { get; set; }
        public string module { get; set; } // beacon_id // Lunch/ETC

    }
    public class DataBeacon{

        public int school_holiday { get; set; }
        public int file { get; set; }
        public DateTime dt_created { get; set; }
        public string module { get; set; }
        public int amount_of_people { get; set; }
    }
}
