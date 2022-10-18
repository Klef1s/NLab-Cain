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
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQDSXAsylT3qrat8DNs1m_Ks8V-dMew3e2SOS0Tgvs8Cf5bgVIaKto_cU1vSLhxZ0cY7I4LyKcPubSnZPLx2D34kdhQ3hWt08eXSO96vyQwqWubaXtLzpffRYnOPkb3FqH4m2wonlTpupGpEv9M6xpw0_JFABopzxqoTO7sl9VNaFNMIJ4HkD07TUZAQekI", "Bearer");

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
