using ArtOfTest.WebAii.Wpf;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace SampleApp.Tests.Framework.Elements
{
    public class App
    {
        public WpfApplication ApplicationWebAii { get; private set; }
        public Application ApplicationWhite { get; private set; }

        public App(WpfApplication webAiiApp, Application whiteApp)
        {
            ApplicationWebAii = webAiiApp;
            ApplicationWhite = whiteApp;
        }

        #region Windows
        public MainWindow MainWindow { get { return new MainWindow(ApplicationWebAii.WaitForWindow(MainWindow.WINDOW_NAME).Find); } }
        public OpenFile OpenFile { get { return new OpenFile(GetWindowByName("Open")); } }
        public MessageBox MessageBox { get { return new MessageBox(GetWindowByName("")); } }
        #endregion

        #region Private
        private Window GetWindowByName(string windowName)
        {
            // Workaround as method app.GetWindow("Open") is not working
            foreach (Window window in ApplicationWhite.GetWindows())
            {
                if (windowName.Equals(window.Name))
                {
                    return window;
                }
            }
            return null;
        }
        #endregion
    }
}
