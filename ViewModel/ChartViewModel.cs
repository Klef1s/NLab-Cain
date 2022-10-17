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
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQBXUHgZ9I07MDxjyOi_CuIqmniiaNwAEXRZq_toW_7Tt1hy6bkxOrwAE9v8BMrQpEpVtjLwhcrOFSA4dq6RR5uqNml_Zo7tlXZZ-DXyVQlpWZyvAza6GuX2K52RXQS4ZW6tesLRqGHfHlfTbHCqTj_OlCwT__UTQZmZb6mBVRI4KtV0Dwo3PtDHYrjHLsY", "Bearer");

            var request = new RestRequest("https://api.spotify.com/v1/playlists/37i9dQZEVXbKPTKrnFPD0G/tracks", Method.Get);
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
