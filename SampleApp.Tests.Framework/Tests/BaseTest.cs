using ArtOfTest.WebAii.Core;
using SampleApp.Tests.Framework.Elements;
using White.Core;

namespace SampleApp.Tests.Framework.Tests
{
    public class BaseTest
    {
        protected App App { get; set; }
        private string applicationPath = "C:\\SampleApp\\SampleApp\\bin\\Debug\\SampleApp.exe";

        protected void Start()
        {
            if (App == null)
            {
                Application appWhite = Application.Launch(applicationPath);
                Manager manager = new Manager(false);
                manager.Start();
                App = new App(manager.ConnectToApplication(appWhite.Process), appWhite);
            }
        }

        protected void Stop()
        {
            if (App != null && App.ApplicationWhite != null)
            {
                App.ApplicationWhite.Kill();
            }
            App = null;
        }
    }
}
