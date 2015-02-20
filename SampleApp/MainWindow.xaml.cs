using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Image Files | *.*";

            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        MyImage.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        listBox1.Items.Add(openFileDialog.FileName);
                        MessageBox.Show("Successfully done");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Problem occured, try again later");
            }
        }
    }
}
