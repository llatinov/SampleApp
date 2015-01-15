using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Tests.Framework.Tests;

namespace SampleApp.Tests
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
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
            string filePath = @"C:\SampleApp\SampleApp\bin\Debug\HappyFace.jpg";
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(filePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(filePath, App.MainWindow.GetFilePathAtIndex(1));
        }

        [TestMethod]
        public void OpenFile_OnAttachTwoFiles_GivesMessageAndFilesAreShown()
        {
            string filePath = @"C:\SampleApp\SampleApp\bin\Debug\HappyFace.jpg";
            // Attach file
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(filePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(filePath, App.MainWindow.GetFilePathAtIndex(1));
            // Attach again
            App.MainWindow.ClickBrowseButton();
            App.OpenFile.EnterFileName(filePath);
            App.OpenFile.ClickOpenButton();
            Assert.AreEqual("Successfully done", App.MessageBox.GetText());
            App.MessageBox.ClickOkButton();
            Assert.AreEqual(filePath, App.MainWindow.GetFilePathAtIndex(2));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Stop();
        }
    }
}
