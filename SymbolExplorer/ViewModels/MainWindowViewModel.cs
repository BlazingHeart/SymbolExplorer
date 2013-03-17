using SymbolExplorer.Code;
using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SymbolExplorer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        bool _showingAboutDialog = false;
        bool _openingFile = false;

        ToolbarViewModel _toolbarViewModel = new ToolbarViewModel();

        ObservableCollection<ArchiveFileViewModel> _archiveFiles = new ObservableCollection<ArchiveFileViewModel>();

        #region Properties

        public ToolbarViewModel Toolbar { get { return _toolbarViewModel; } }

        public ObservableCollection<ArchiveFileViewModel> ArchiveFiles { get { return _archiveFiles; } }

        public ICommand OpenFile { get { return new RelayCommand(OpenFileExecute, CanOpenFileExecute); } }

        public ICommand ShowAboutDialog { get { return new RelayCommand(ShowAboutDialogExecute, CanShowAboutDialogExecute); } }

        #endregion

        #region Commands

        private bool CanOpenFileExecute()
        {
            return _openingFile == false;
        }

        private void OpenFileExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".lib";
            dlg.Filter = "Library Archives (.lib)|*.lib";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                switch (Path.GetExtension(dlg.FileName))
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

        private bool CanShowAboutDialogExecute()
        {
            return _showingAboutDialog == false;
        }

        private void ShowAboutDialogExecute()
        {
            _showingAboutDialog = true;

            var assembly = Assembly.GetEntryAssembly();
            Version version = assembly.GetName().Version;

            AboutWindow s = new AboutWindow();
            s.Owner = Application.Current.MainWindow;
            s.Version = version;
            s.ShowDialog();

            _showingAboutDialog = false;
        }

        #endregion

        public void LoadFile(string filePath)
        {
            try
            {
                FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var file = ArchiveFile.FromStream(s);
                ArchiveFileViewModel model = new ArchiveFileViewModel();
                model.File = file;
                model.Name = System.IO.Path.GetFileName(filePath);
                ArchiveFiles.Add(model);

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
