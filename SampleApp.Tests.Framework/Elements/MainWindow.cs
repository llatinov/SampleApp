using ArtOfTest.WebAii.Controls.Xaml.Wpf;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.TestTemplates;
using System.Threading;

namespace SampleApp.Tests.Framework.Elements
{
    public class MainWindow : XamlElementContainer
    {
        public static string WINDOW_NAME = "MainWindow";
        private string mainPath = "XamlPath=/Border[0]/AdornerDecorator[0]/ContentPresenter[0]/Grid[0]/";
        public MainWindow(VisualFind find) : base(find) { }

        #region Elements
        private Button Button_Browse { get { return Get<Button>(mainPath + "Button[0]"); } }
        private Image Image { get { return Get<Image>(mainPath + "Image[0]"); } }
        private TextBlock GetItemFromList(int index)
        {
            return Get<TextBlock>(mainPath + "ListBox[0]/Border[0]/ScrollViewer[0]/Grid[0]/ScrollContentPresenter[0]/" +
                "ItemsPresenter[0]/VirtualizingStackPanel[0]/ListBoxItem[" + (index - 1) + "]/Border[0]/ContentPresenter[0]/TextBlock[0]");
        }
        #endregion

        #region Actions
        public void ClickBrowseButton()
        {
            Button_Browse.User.Click();
            Thread.Sleep(500);
        }

        public string GetFilePathAtIndex(int index)
        {
            return GetItemFromList(index).Text;
        }
        #endregion
    }
}
