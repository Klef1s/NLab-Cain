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
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQBoo_buaVFxahOjJKnb0rvZWUAj2_y9EkMxTd9Vc7S_cY25B6gitaS4q0CXfDCp5ZWATh_or2-yySxOank4J4lW74TKrXDEpatoOzc674sU18NOXONiBCpeLRD1wfsKFF6ma823MKoyno4VI7BIHzdONlQ9iyTkNRsyi768huwp3f3SX24zJ5--bFUJPdk", "Bearer");

            var request = new RestRequest(UrlChart.url, Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            var response = client.GetAsync(request).GetAwaiter().GetResult();

            var data = JsonConvert.DeserializeObject<ChartModel>(response.Content);

            for (int i = 0; i < data.Items.Length; i++)
            {
                var tracks = data.Items[i];
                tracks.Track.Number = i + 1;
                Tracks.Add(tracks);
            }
        }
    }
}
