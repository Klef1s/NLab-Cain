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
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQDJwuQZLcQdhu1HqNO_jiBvYJ5pGOv12FnLLUpvXB07Jf35dtAcqRFMVz_obbwRK1Etl36NAVSfaXuLVMYZnK8El3DvJA2HaNSiAZPxUsUH5lg9y8HPBCtBdVg8w-Zsw3qksf83FyBylzFC0EMWff2outCR-VWN2Wlg2umH3jaZErmQDbpDRZh9b63Yktg", "Bearer");

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
