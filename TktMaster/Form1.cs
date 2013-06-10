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
namespace TktMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //// Create a request for the URL. 
                //WebRequest request = WebRequest.Create(
                //  "http://www.ticketmaster.com/json/browse/sports?select=n31");
                //// If required by the server, set the credentials.
                //request.Credentials = CredentialCache.DefaultCredentials;
                //// Get the response.
                //WebResponse response = request.GetResponse();
                //// Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                //// Get the stream containing content returned by the server.
                //Stream dataStream = response.GetResponseStream();
                //// Open the stream using a StreamReader for easy access.
                //StreamReader reader = new StreamReader(dataStream);
                //// Read the content.
                //string responseFromServer = reader.ReadToEnd();
                //// Display the content.
                //Console.WriteLine(responseFromServer);
                //richTextBox1.Text = responseFromServer;
                //// Clean up the streams and the response.
                //reader.Close();
                //response.Close();

                StreamReader reader = new StreamReader("C:\\response.txt");
                //// Read the content.
                string responseFromServer = reader.ReadToEnd();
                JObject a = JObject.Parse(responseFromServer);

                TktMaster.clstMaster.RootObject obj = JsonConvert.DeserializeObject<TktMaster.clstMaster.RootObject>(responseFromServer);

                foreach (var item in obj.response.docs)
                {
                    Console.WriteLine("item.EventId", item.EventId);
                    Console.WriteLine("item.VenueCountry", item.VenueCountry);
                    Console.WriteLine("item.VenueId", item.VenueId);
                    Console.WriteLine("item.Host", item.Host);
                    Console.WriteLine("item.AttractionId", item.AttractionId);

                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
