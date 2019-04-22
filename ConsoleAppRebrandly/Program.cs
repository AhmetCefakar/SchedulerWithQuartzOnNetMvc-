using ConsoleAppRebrandly.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRebrandly
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urlLinks = new List<string>
            {
                "http://yazilimustam.com/c-webclient-ve-httpclient-kullanimi/",
                //"https://ademocut.com/kisaltilmis-url-nasil-yapilir-google-url-shortener-ademocut-com/",
                //"https://www.youtube.com/results?search_query=Firebase+Dynamic+Links+API+Client+Library+for+.NET+examples"
            };

            List<string> urlShortdLinks = new List<string>();

            for (int i = 0; i < urlLinks.Count; i++)
            {
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("apikey", "7d8021cb454846438863377755dc258a");
                //client.Headers.Add("workspace", "Main_Workspace");

                string body = "{\"destination\":\"" + urlLinks[i] + "\",\"domain\":{\"fullName\":\"rebrand.ly\"}}"; // https://www.youtube.com/channel/UCHK4HD0ltu1-I212icLPt3g

                try
                {
                    string response = client.UploadString("https://api.rebrandly.com/v1/links", "POST", body); // API'ya link kısaltmak için istek yapılıyor


                    CratredLinkModel cratredLinkModel = JsonConvert.DeserializeObject<CratredLinkModel>(response);
                    urlShortdLinks.Add(cratredLinkModel.shortUrl);
                }
                catch (Exception ex)
                {
                    //request failed
                }
            }


            Console.WriteLine("==============Oluşturulan kısa linkler;===============");
            for (int i = 0; i < urlShortdLinks.Count; i++)
            {
                Console.WriteLine($"Uzun link: {urlLinks[i]}, Kısalink: {urlShortdLinks[i]}");
            }

            Console.WriteLine("=============================");
            Console.ReadLine();
        }
    }
}
