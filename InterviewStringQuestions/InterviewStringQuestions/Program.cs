namespace InterviewStringQuestions
{
    using Newtonsoft.Json;
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Net.Http.Headers;

    class Program
    {
        private static string endPoint;
        static Program()
        {
            endPoint = ConfigurationManager.AppSettings["apiEndPoint"];
        }

        static void Main(string[] args)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(endPoint);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var url = "api/values/" + "5";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsStringAsync().Result;
                string bsObj = JsonConvert.DeserializeObject<string>(users);
                Console.WriteLine(bsObj);
               
            }
            else
            {
                Console.WriteLine( ("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase));
            }

        }


    }
    

}


    
    




