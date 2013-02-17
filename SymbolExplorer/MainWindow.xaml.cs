﻿using SymbolExplorer.ViewModels;
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
        public ArchiveFileViewModel Archive;

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
                string filename = dlg.FileName;

                FileStream s = new FileStream(filename, FileMode.Open);
                var file = ArchiveFile.FromStream(s);
                Archive = new ArchiveFileViewModel(file);

                //var items = MemberTree.Items;
                //var root = new TreeViewItem();
                //root.Header = System.IO.Path.GetFileName(filename);
                //items.Add(root);

                //var first = new TreeViewItem();
                //first.Header = "First";
                //first.DataContext = Archive.First;

                //var second = new TreeViewItem();
                //second.Header = "Second";
                //second.DataContext = Archive.second;

                //var longnames = new TreeViewItem();
                //longnames.Header = "Longnames";
                //longnames.DataContext = Archive.longnames;

                //root.Items.Add(first);
                //root.Items.Add(second);
                //root.Items.Add(longnames);

                MemberTree.DataContext = Archive;
            }
        }

        private void MemberTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }
    }
}