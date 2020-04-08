using Caliburn.Micro;
using GameLeapDownloader.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GameLeapDownloader.ViewModels
{
    class DownloaderViewModel : Screen
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string SavePath { get; set; }
        public string Progress { get; set; }
        public string Files { get; set; }
        public RestClient client;

        protected override void OnActivate()
        {
            base.OnActivate();
        }
        public void Download()
        {
            Files = "";
            String audioUrl = "https://cdn.gameleap.com/videos/" + Code + "/dash/1080_30/audio/" + Code + "_1080_30.mp4";
            String videoUrl = "https://cdn.gameleap.com/videos/" + Code + "/dash/1080_30/video/" + Code + "_1080_30.webm";

            Files += audioUrl + "\r\n" + videoUrl;
            NotifyOfPropertyChange(() => Files);

            //System.Net.CookieContainer container = new System.Net.CookieContainer(); 
            //client = new RestClient();
            //client.CookieContainer = container;


            //var request = new RestRequest("https://api.gameleap.com/api/auth/login", Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.RequestFormat = RestSharp.DataFormat.Json;
            //request.AddBody(new { credential = Username, password = Password });

            //Progress = "Downloading.. Please wait ";
            //NotifyOfPropertyChange(() => Progress);

            //var result = client.Execute(request);
            //if (result.IsSuccessful)
            //{

            //    Files = "";
            //    AuthModel model =
            //          JsonConvert.DeserializeObject<AuthModel>(result.Content);


               

            //    //var parameter = new object[2];
            //    //parameter[0] = audioUrl;
            //    //parameter[1] = "mp4";
           
            //    //Thread thread = new Thread(DownloadFile);
            //    //thread.Start(parameter);


              
            //    //parameter = new object[2];
            //    //parameter[0] = videoUrl;
            //    //parameter[1] = "webm";

            //    //Thread thread2 = new Thread(DownloadFile);
            //    //thread2.Start(parameter);


            //}

        }


        private void DownloadFile(object url)
        {
            Array argArray = new object[2];
            argArray = (Array)url;
            var dlRequest = new RestRequest((string) argArray.GetValue(0));

            byte[] response = client.DownloadData(dlRequest);

            String savePath = SavePath +"/"+ Code + "." + (string)argArray.GetValue(1);
            File.WriteAllBytes(savePath, response);
            Progress = "Done writing "+savePath;
            NotifyOfPropertyChange(() => Progress);
        }
    }
}
