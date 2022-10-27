﻿using Newtonsoft.Json;
using NLab_Cain.Models.ChartModel;
using NLab_Cain.Pages;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLab_Cain.ViewModel
{

    class ChartViewModel
    {
        //static StreamReader str = new StreamReader("D:/Application/C#/NLab Cain/Resources/Files/token.txt", Encoding.UTF8);
        //string token = str.ReadLine();

        public ObservableCollection<Item> Tracks { get; set; }

        public ChartViewModel()
        {
            Tracks = new ObservableCollection<Item>();
            PopulateCollection();
        }

        void PopulateCollection()
        {
            var client = new RestClient();
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQAcsdUW1YuSSbg9ss12y11nPD1iWtwvYGtnygLcFOcPike-w3Usj0LXLNuwyj_AjRIMELBYgrQrehqqZSKz1w9qhBajW3S7U9DayPmiIvHnZB1QBWTYWAvoN4FV8izMbFRS9smNYeEWc5OXtcXzuG7gIIGRSQYR0cWSFiKybntdZjNTpVUniG5cueYACjI", "Bearer");

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
