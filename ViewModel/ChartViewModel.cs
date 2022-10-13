using Newtonsoft.Json;
using NLab_Cain.Models.ChartModel;
using NLab_Cain.Pages;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLab_Cain.ViewModel
{
    class ChartViewModel
    {
        public ObservableCollection<Item> Tracks { get; set; }

        public ChartViewModel()
        {
            Tracks = new ObservableCollection<Item>();
            PopulateCollection();
        }

        void PopulateCollection()
        {
            var client = new RestClient();
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQDQe5D6nkJF7Xx6zTggp4KuFzvYOamMNZd-uuufy9mY1_XLFWfhZG8rdRhKYRxvg_NJlv1S8Dc5qIlIzlEq7J9kzXiLYn79ONh83OIpyYa-f4qhTmsjdMu1gQYETbSviHZR79hOgejqZRx3nFrVbXK_qYZ3-Z0FcUqV1FtUheE8OdQMMlOdkGojB5X7_88", "Bearer");

            var request = new RestRequest(UrlChart.url, Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var data = JsonConvert.DeserializeObject<ChartModel>(response.Content);
        }
    }
}
