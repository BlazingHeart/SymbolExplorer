using SymbolExplorer.ViewModels;
using SymbolExplorer.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                switch(Path.GetExtension(dlg.FileName))
                {
                case ".lib":
                    LoadFile(dlg.FileName);
                    break;

                case ".a":
                    LoadFileA(dlg.FileName);
                    break;
                }
            }
        }

        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetEntryAssembly();
            Version version = assembly.GetName().Version;
            string message = string.Format("SymbolExplorer {0}\n(c) 2013 Simon Stevenson", version.ToString());
            MessageBox.Show(message, "SymbolExplorer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void LoadFile(string filePath)
        {
            try
            {
                FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var file = ArchiveFile.FromStream(s);
                Archive.File = file;
                Archive.Name = System.IO.Path.GetFileName(filePath);

                this.DataContext = Archive;

                TreeViewItem item = new TreeViewItem();
                item.Header = Archive.Name;
                item.ItemsSource = Archive.Members;
                item.ItemTemplate = (DataTemplate)FindResource("ArchiveMemberViewTemplate");
                item.ExpandSubtree();

                MemberTree.Items.Add(item);

                if (file.Errors)
                {
                    MessageBox.Show(string.Format("There were errors loading '{0}'", filePath), "Symbol Explorer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Error loading file '{0}'", filePath), "Symbol Explorer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadFileA(string filePath)
        {
            try
            {
                FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var file = ArchiveFileAr.FromStream(s);
                //Archive.File = file;
                //Archive.Name = System.IO.Path.GetFileName(filePath);

                //this.DataContext = Archive;

                //TreeViewItem item = new TreeViewItem();
                //item.Header = Archive.Name;
                //item.ItemsSource = Archive.Members;
                //item.ItemTemplate = (DataTemplate)FindResource("ArchiveMemberViewTemplate");
                //item.ExpandSubtree();

                //MemberTree.Items.Add(item);

                //if (file.Errors)
                //{
                //    MessageBox.Show(string.Format("There were errors loading '{0}'", filePath), "Symbol Explorer", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
            catch
            {
                MessageBox.Show(string.Format("Error loading file '{0}'", filePath), "Symbol Explorer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App app = App.Current as App;
            if (!string.IsNullOrEmpty(app.FileToOpen))
            {
                LoadFile(app.FileToOpen);
            }
        }

        private void symbolDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string[] columnsToHide = { Utils.GetPropertyName<SymbolViewModel>(a => a.Name) };
            //foreach (var columnName in columnsToHide)
            //{
            //    var column = symbolDataGrid.Columns.Where(c => (c.Header.ToString() == columnName)).Single();
            //    column.Visibility = Visibility.Collapsed;
            //}

            string header = e.Column.Header.ToString();
            if (columnsToHide.Contains(header))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void symbolDataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {

            ContextMenu contextMenu = (ContextMenu)symbolDataGrid.FindResource("headerContextMenu");
            contextMenu.Items.Clear();
            foreach (var c in symbolDataGrid.Columns)
            {
                MenuItem item = new MenuItem();
                item.Header = c.Header;
                item.IsCheckable = true;
                item.IsChecked = (c.Visibility == Visibility.Visible);
                item.Checked += (object _sender, RoutedEventArgs _e) =>
                    {
                        c.Visibility = Visibility.Visible;
                    };
                item.Unchecked += (object _sender, RoutedEventArgs _e) =>
                    {
                        int visible = symbolDataGrid.Columns.Where(z => z.Visibility == Visibility.Visible).Count();
                        if (visible > 1)
                        {
                            c.Visibility = Visibility.Collapsed;
                        }
                        else { item.IsChecked = true; }
                    };
                contextMenu.Items.Add(item);
            }
        }

        private void toggleLinkerSymbols_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void symbolDataGrid_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            Console.WriteLine(e.OriginalSource);
        }

        private void toggleLinkerSymbols_ToggleChecked(object sender, RoutedEventArgs e)
        {
            bool c = toggleLinkerSymbols.IsChecked ?? false;

            Filters.SymbolViewModel_NonLinker_Enabled = c;

            var source = symbolDataGrid.ItemsSource as ListCollectionView;
            if (source != null)
            {
                source.Refresh();
            }
        }
    }
}
