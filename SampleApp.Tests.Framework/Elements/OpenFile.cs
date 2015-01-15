using System.Windows.Automation;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace SampleApp.Tests.Framework.Elements
{
    public class OpenFile
    {
        private Window win;
        public OpenFile(Window window)
        {
            win = window;
        }

        #region Elements
        private Button Button_Open { get { return win.Get<Button>(SearchCriteria.ByControlType(ControlType.Button).AndByText("Open")); } }
        private Button Button_Cancel { get { return win.Get<Button>(SearchCriteria.ByControlType(ControlType.Button).AndByText("Cancel")); } }
        private TextBox TextBox_FileName { get { return win.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndByText("File name:")); } }
        #endregion

        #region Actions
        public void ClickOpenButton()
        {
            Button_Open.Click();
        }

        public void ClickCancelButton()
        {
            Button_Cancel.Click();
        }

        public void EnterFileName(string filePath)
        {
            TextBox_FileName.Enter(filePath);
        }
        #endregion
    }
}
