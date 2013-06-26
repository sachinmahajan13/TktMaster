using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security;
namespace TktMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CookieContainer cookieJar = new CookieContainer();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Create a request for the URL. 
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
                  "http://www.ticketmaster.com/json/search/event/local?aid=1577176");

                request.CookieContainer = cookieJar;
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
                //richTextBox1.Text = responseFromServer;
                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                //StreamReader reader = new StreamReader( Application.StartupPath + "\\response.txt");
                //string responseFromServer = reader.ReadToEnd();

                TktMaster.clstMaster.RootObject obj = JsonConvert.DeserializeObject<TktMaster.clstMaster.RootObject>(responseFromServer);
                Dictionary<string, Avsdetail> objAvsdetailnew = new Dictionary<string, Avsdetail>();
                foreach (var item in obj.response.docs)
                {
                    Avsdetail objAvsdetail = new Avsdetail();
                    List<string> AttractionId = new List<string>();
                    AttractionId.Add(item.AttractionId[0].ToString());
                    objAvsdetail.AttractionId = AttractionId;//.Add("sa");// .Add( .Add(AttractionId);
                    objAvsdetail.AttractionOrganization = new List<object>();
                    objAvsdetail.Country = item.VenueCountry.ToString();
                    objAvsdetail.Host = item.Host.ToString();
                    objAvsdetail.VenueId = item.VenueId.ToString();
                    objAvsdetail.VenueOrganization= new List<object>();
                    objAvsdetailnew.Add(item.EventId.ToString(), objAvsdetail);
                 }
                Dictionary<string, Dictionary<string, Avsdetail>> objAvsdetailnew1 = new Dictionary<string, Dictionary<string, Avsdetail>>();
                objAvsdetailnew1.Add("avs_request", objAvsdetailnew);
                string AvsstrRequest = JsonConvert.SerializeObject(objAvsdetailnew1);

                requestAVS(AvsstrRequest);







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }


        private void requestAVS(string req)
        {

            StreamReader reader = new StreamReader(Application.StartupPath + "\\avsrequest.txt");
            string responseFromServer = reader.ReadToEnd();

            byte[] data = new ASCIIEncoding().GetBytes("avs=" + responseFromServer);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.ticketmaster.com/json/avs");

            request.AllowAutoRedirect = false;

            
           // request.CookieContainer =  PersistentCookies.GetCookieContainerForUrl(url);
            // If required by the server, set the credentials.
            request.Method = "POST";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.CookieContainer = cookieJar;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Referer = "http://www.ticketmaster.com/Hunter-Hayes-tickets/artist/1577176?tm_link=tm_homeA_b_10001_1";
            request.UserAgent = " Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.KeepAlive = true;
            using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data,0,data.Length);
                }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

          
            }
    }
}


/*
 * { "avs_request" : [ { "0E004A31AB4B7151" : { "AttractionId" : [ "1541172" ],
            "AttractionOrganization" : [  ],
            "Country" : "US",
            "Host" : "ATL",
            "VenueId" : "115647",
            "VenueOrganization" : [  ]
          } },
      { "0E004A8FCD69FA35" : { "AttractionId" : [ "836344",
                "807358"
              ],
            "AttractionOrganization" : [  ],
            "Country" : "US",
            "Host" : "ATL",
            "VenueId" : "115120",
            "VenueOrganization" : [  ]
          } },
      { "0E004A31AB517193" : { "AttractionId" : [ "1541172" ],
            "AttractionOrganization" : [  ],
            "Country" : "US",
            "Host" : "ATL",
            "VenueId" : "115647",
            "VenueOrganization" : [  ]
          } }
    ] }
 * 
 * 
 * { "ShowAvailability" : "1",
  "availabilities" : [ { "EventId" : "0E004A31AB4B7151",
        "MsgCode" : 0
      },
      { "EventId" : "0E004A8FCD69FA35",
        "MsgCode" : 0
      },
      { "EventId" : "0E004A31AB4C7157",
        "MsgCode" : 0
      },
      
      { "EventId" : "0E004A31AB517193",
        "MsgCode" : 0
      }
    ]
}
*/