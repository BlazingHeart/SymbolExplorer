using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
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

        ToolbarViewModel _toolbarViewModel = new ToolbarViewModel();


        ArchiveFileViewModel _archiveFile = new ArchiveFileViewModel();

        #region Properties

        public ToolbarViewModel Toolbar { get { return _toolbarViewModel; } }

        public ArchiveFileViewModel ArchiveFile { get { return _archiveFile; } set { SetProperty(ref _archiveFile, value, "ArchiveFile"); } }

        public ICommand OpenFile { get { return new RelayCommand(OpenFileExecute, CanOpenFileExecute); } }

        public ICommand ShowAboutDialog { get { return new RelayCommand(ShowAboutDialogExecute, CanShowAboutDialogExecute); } }

        #endregion

        #region Commands

        private bool CanOpenFileExecute()
        {
            throw new NotImplementedException();
        }

        private void OpenFileExecute()
        {
            throw new NotImplementedException();
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
                var file = Code.ArchiveFile.FromStream(s);
                ArchiveFile.File = file;
                ArchiveFile.Name = System.IO.Path.GetFileName(filePath);

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
