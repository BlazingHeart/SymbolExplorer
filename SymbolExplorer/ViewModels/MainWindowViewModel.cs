using SymbolExplorer.Code;
using SymbolExplorer.Framework;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace SymbolExplorer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ToolbarViewModel _toolbarViewModel = new ToolbarViewModel();

        ObservableCollection<ArchiveFileViewModel> _archiveFiles = new ObservableCollection<ArchiveFileViewModel>();
        
        #region Properties

        public ToolbarViewModel Toolbar { get { return _toolbarViewModel; } }

        public bool HideLinkerMembers { get { return Filters.SymbolViewModel_HideLinkerSymbols_Enabled; } set { Filters.SymbolViewModel_HideLinkerSymbols_Enabled = value; OnPropertyChanged("HideLinkerMembers"); } }

        public ObservableCollection<ArchiveFileViewModel> ArchiveFiles { get { return _archiveFiles; } }

        public ICommand OpenFile { get { return new RelayCommand(OpenFileExecute); } }

        public ICommand ShowAboutDialog { get { return new RelayCommand(ShowAboutDialogExecute); } }

        public ICommand RefreshDataGrid { get { return new RelayCommand(RefreshDataGridExecute); } }

        public ICommand HideColumn { get { return new RelayCommand<object>(HideColumnExecute, null); } }

        public ICommand SelectColumns { get { return new RelayCommand<object>(SelectColumnsExecute, null); } }

        public ICommand ToggleLinkerMembers { get { return new RelayCommand<object>(ToggleLinkerMembersExecute, null); } }
        
        #endregion

        #region Commands

        private void OpenFileExecute()
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

        private void ShowAboutDialogExecute()
        {
            var assembly = Assembly.GetEntryAssembly();
            Version version = assembly.GetName().Version;

            AboutWindow s = new AboutWindow();
            s.Owner = Application.Current.MainWindow;
            s.Version = version;
            s.ShowDialog();
        }

        private void RefreshDataGridExecute()
        {
            foreach (var file in _archiveFiles)
            {
                foreach (var member in file.Members)
                {
                    var view = CollectionViewSource.GetDefaultView(member.FilteredSymbols);
                    if (view != null)
                    {
                        view.Refresh();
                    }
                }
            }
        }

        private void HideColumnExecute(object parameter)
        {
            var dataGridColumnHeader = parameter as DataGridColumnHeader;
            var dataGridColumn = dataGridColumnHeader.Column;
            if (dataGridColumn != null)
            {
                dataGridColumn.Visibility = Visibility.Collapsed;
            }
        }

        private void SelectColumnsExecute(object parameter)
        {
            var dataGridColumnHeader = parameter as DataGridColumnHeader;
            var dataGrid = VisualTreeHelpers.FindAncestor<DataGrid>(dataGridColumnHeader);
            SelectColumnsWindow dialog = new SelectColumnsWindow();
            dialog.Owner = Application.Current.MainWindow;
            dialog.Model.DataGrid = dataGrid;
            dialog.ShowDialog();
        }

        private void ToggleLinkerMembersExecute(object obj)
        {
            RefreshDataGridExecute();
        }

        #endregion

        public MainWindowViewModel()
        {
            App app = App.Current as App;
            if (!string.IsNullOrEmpty(app.FileToOpen))
            {
                LoadFile(app.FileToOpen);
            }
        }

        public void LoadFile(string filePath)
        {
            switch (Path.GetExtension(filePath))
            {
            case ".lib":
                LoadFileLib(filePath);
                break;

            case ".a":
                LoadFileA(filePath);
                break;
            }
        }

        public void LoadFileLib(string filePath)
        {
            try
            {
                FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var file = ArchiveFileLib.FromStream(s);
                ArchiveFileViewModel model = new ArchiveFileViewModel(file);
                model.Name = System.IO.Path.GetFileName(filePath);
                _archiveFiles.Add(model);

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
                var file = Code.ArchiveFileAr.FromStream(s);
            }
            catch
            {
                MessageBox.Show(string.Format("Error loading file '{0}'", filePath), "Symbol Explorer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
