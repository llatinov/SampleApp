using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Tests.Framework.Tests;

namespace SampleApp.Tests
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        private string imagePath = CurrentPath + "HappyFace.jpg";

        [TestInitialize]
        public void Initialise()
        {
            Start();
        }

        [TestMethod]
        public void OpenFile_OnCancel_GivesMessage()
        {
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.ClickCancelButton();
            Assert.AreEqual("Problem occured, try again later", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
        }

        [TestMethod]
        public void OpenFile_OnAttachFile_GivesMessageAndFileIsShown()
        {
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(imagePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(imagePath, App.MainWindow.GetFilePathAtIndex(1));
        }

        [TestMethod]
        public void OpenFile_OnAttachTwoFiles_GivesMessageAndFilesAreShown()
        {
            // Attach file
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(imagePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(imagePath, App.MainWindow.GetFilePathAtIndex(1));
            // Attach again
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(imagePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(imagePath, App.MainWindow.GetFilePathAtIndex(2));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Stop();
        }
    }
}
