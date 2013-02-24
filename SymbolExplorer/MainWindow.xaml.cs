using SymbolExplorer.ViewModels;
using SymbolExplorerLib;
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

namespace SymbolExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArchiveFileViewModel Archive = new ArchiveFileViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".lib";
            dlg.Filter = "Library Archives (.lib)|*.lib";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                LoadFile(dlg.FileName);
            }
        }

        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SymbolExplorer (c) 2013 Simon Stevenon", "SymbolExplorer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void LoadFile(string filePath)
        {
            FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var file = ArchiveFile.FromStream(s);
            Archive.File = file;
            Archive.Name = System.IO.Path.GetFileName(filePath);

            this.DataContext = Archive;

            MemberTree.ItemsSource = Archive.Members;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App app = App.Current as App;
            if (!string.IsNullOrEmpty(app.FileToOpen))
            {
                LoadFile(app.FileToOpen);
            }
        }
    }
}
