using ArtOfTest.WebAii.Core;
using SampleApp.Tests.Framework.Elements;
using System.IO;
using White.Core;

namespace SampleApp.Tests.Framework.Tests
{
    public class BaseTest
    {
        protected App App { get; set; }
        protected static string CurrentPath
        {
            get { return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar; }
        }

        protected void Start()
        {
            if (App == null)
            {
                Application appWhite = Application.Launch(CurrentPath + "SampleApp.exe");
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
