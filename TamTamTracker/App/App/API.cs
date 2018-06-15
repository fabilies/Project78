using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TamTamTracker
{
    public static class API_
    {

        public static string getSuggestion()
        {
            string result = "";
            using (WebClient webClient = new WebClient())
            {

                // xaml
                webClient.Encoding = System.Text.Encoding.UTF8;

                try
                {
                    result = webClient.DownloadString("http://10.0.2.2:50798/api/suggestions/getSuggestion");
                    //result = webClient.DownloadString("http://192.168.2.8:50798/api/suggestions/getSuggestion");
                }
                catch(WebException ex)
                {
                    throw new Exception("Error while obtaining suggestiondata");
                }    
            }
            return result;
        }

    }



}