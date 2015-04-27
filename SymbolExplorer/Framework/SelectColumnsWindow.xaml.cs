using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SymbolExplorer.Framework
{
    /// <summary>
    /// Interaction logic for SelectColumnsWindow.xaml
    /// </summary>
    public partial class SelectColumnsWindow : Window
    {
        public SelectColumnsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
