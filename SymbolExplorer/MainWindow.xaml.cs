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
using SymbolExplorer.Framework;

namespace SymbolExplorer
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

        private void toggleLinkerSymbols_ToggleChecked(object sender, RoutedEventArgs e)
        {
            var source = symbolDataGrid.ItemsSource as ListCollectionView;
            if (source != null)
            {
                source.Refresh();
            }
        }

        private void MenuItem_Click_HideColumn(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Model.HideColumn.Execute(menuItem.CommandParameter);
        }

        private void MenuItem_Click_SelectColumns(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            var source = e.Source;
            Model.SelectColumns.Execute(menuItem.CommandParameter);
        }
    }
}
