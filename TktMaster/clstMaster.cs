using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TktMaster
{
    class clstMaster
    {
        public class ResponseHeader
        {
            public int status { get; set; }
            public int QTime { get; set; }
        }

        public class FacetCounts
        {
        }

        public class EventDate
        {
            public int event_date_type { get; set; }
            public string date { get; set; }
            public object date_range { get; set; }
            public int suppress_time { get; set; }
        }

        public class Onsales
        {
            public object unmodified_epdate { get; set; }
            public string expire { get; set; }
            public List<object> onsales { get; set; }
            public EventDate event_date { get; set; }
            public int onsale_status { get; set; }
        }

        public class PostProcessedData
        {
            public string LocalEventDate { get; set; }
            public bool SuppressWireless { get; set; }
            public Onsales Onsales { get; set; }
        }

        public class Doc
        {
            public List<string> PromoId { get; set; }
            public List<string> SportsBrowseGenre { get; set; }
            public string VenueSEOLink { get; set; }
            public string VenueId { get; set; }
            public string LocalEventMonthYear { get; set; }
            public PostProcessedData PostProcessedData { get; set; }
            public string VenueCity { get; set; }
            public List<int> MajorGenreId { get; set; }
            public object ExpirationDate { get; set; }
            public string PriceRange { get; set; }
            public string VenueCityState { get; set; }
            public List<string> AttractionSEOLink { get; set; }
            public List<string> Type { get; set; }
            public string PurchaseDomain { get; set; }
            public int EventType { get; set; }
            public string EventNotes { get; set; }
            public string LocalEventShortWeekday { get; set; }
            public string EventName { get; set; }
            public List<string> AttractionId { get; set; }
            public string LangCode { get; set; }
            public string OnsaleOn { get; set; }
            public List<string> PromoterId { get; set; }
            public List<string> AttractionName { get; set; }
            public string LocalEventShortMonth { get; set; }
            public string VenuePostalCode { get; set; }
            public List<int> DMAId { get; set; }
            public string Currency { get; set; }
            public string SearchableUntil { get; set; }
            public List<string> AttractionImage { get; set; }
            public string EventStatus { get; set; }
            public double Stars { get; set; }
            public List<int> MinorGenreId { get; set; }
            public string LocalEventWeekdayString { get; set; }
            public string Host { get; set; }
            public string EventSEOName { get; set; }
            public string EventDate { get; set; }
            public string LocalEventDateDisplay { get; set; }
            public int LocalEventDay { get; set; }
            public string Timezone { get; set; }
            public int LocalEventYear { get; set; }
            public List<string> MinorGenre { get; set; }
            public List<int> MarketId { get; set; }
            public string timestamp { get; set; }
            public string DocumentId { get; set; }
            public int LocalEventMonth { get; set; }
            public string VenueAddress { get; set; }
            public string VenueName { get; set; }
            public string VenueLatLong { get; set; }
            public int StarReviewCount { get; set; }
            public string VenueImage { get; set; }
            public string Id { get; set; }
            public List<string> Genre { get; set; }
            public string VenueCountry { get; set; }
            public List<string> MajorGenre { get; set; }
            public string VenueState { get; set; }
            public string EventInternetRelease { get; set; }
            public string EventId { get; set; }
            public object OnsaleOff { get; set; }
            [JsonProperty("search-en")]
            public string search_en { get; set; }
            public string EventInfo { get; set; }
            public bool? ActOverride { get; set; }
            public bool? SuppressBestAvailPrice { get; set; }
            public bool? SuppressBestAvailAll { get; set; }
            public List<string> PresaleName { get; set; }
            public List<string> PresaleOff { get; set; }
            public List<string> PresaleOn { get; set; }
        }

        public class Response
        {
            public FacetCounts facet_counts { get; set; }
            public int numFound { get; set; }
            public List<Doc> docs { get; set; }
            public int start { get; set; }
        }

        public class RootObject
        {
            public ResponseHeader responseHeader { get; set; }
            public Response response { get; set; }
        }
    }

   
}
