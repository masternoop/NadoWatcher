using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UIKit;
using NadoWatch.Helpers;

namespace NadoWatch
{
    public partial class ViewController : UIViewController
    {
        //string url = "https://gist.githubusercontent.com/derekforeman/7f0a1914f623530499340d4c2aa20a93/raw/488c8eba5caedaa45f5a2d0bb091e8d792cfe81f/description.txt";

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            GetData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private async Task<bool> GetData()
        {
            var url = Settings.GeneralSettings;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));

            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {

                    var s = stream.ReadToEnd();
                    txtDescription.Text = s;
                    return true;
                    //process the response
                }
            }
        }
    }
}
