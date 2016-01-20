using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad_WPF_project
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
        //Declared this var to use for both Open and Save properties.
        string currentFile;

        //This event was created for me when making a menu item for the Open button in xaml
        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            //Assigned this OpenFileDialog class to var ofd
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog waits for the user to select a file. When user selects existing file, == true
            if (ofd.ShowDialog() == true)
            {
                //Reads the file selected and displays it in the notepad textbox
                textEditor.Text = File.ReadAllText(ofd.FileName);
                //Stores the selected file in string currentFile
                currentFile = ofd.FileName;
            }
        }
        //This event was created for me when making a menu item for the Save button in xaml
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //if currentFile opened exists..
            if (File.Exists(currentFile))
            {
                //read currentFile, and write it in the textbox
                File.WriteAllText(currentFile, textEditor.Text);
            }
            //if currentFile is new and needs to be saved, 
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllText(sfd.FileName, textEditor.Text);
                    //stores the file into currentFile
                    currentFile = sfd.FileName;
                }
            }
        }
        //This button populated by typing another menu item in xaml and I named it Exit
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            //This method found on stackoverflow closes what is currently opened and exits the notepad
            Application.Current.Shutdown();
        }
    }
}
