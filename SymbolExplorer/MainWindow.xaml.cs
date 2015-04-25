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
using Fluent;

namespace SymbolExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (((TabItem)ViewTabs.SelectedItem).Visibility != Visibility.Visible)
            {
                foreach (TabItem tab in ViewTabs.Items)
                {
                    if (tab.Visibility == Visibility.Visible)
                    {
                        ViewTabs.SelectedItem = tab;
                        break;
                    }
                }
            }
        }
    }
}
