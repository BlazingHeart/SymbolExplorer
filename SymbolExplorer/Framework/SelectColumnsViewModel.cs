using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SymbolExplorer.Framework
{
    public class SelectColumnsViewModel : ViewModelBase
    {
        public class ColumnVisibilityViewModel : ViewModelBase
        {
            DataGridColumn _dataGridColumn;
            bool _visible;

            public bool Visible { get { return _visible; } set { SetProperty(ref _visible, value, "Visible"); } }

            public object Header { get { return _dataGridColumn.Header; } }

            public ColumnVisibilityViewModel(DataGridColumn dataGridColumn)
            {
                _dataGridColumn = dataGridColumn;
                _visible = (_dataGridColumn.Visibility == Visibility.Visible);
            }

            public void ApplyChanges()
            {
                _dataGridColumn.Visibility = Visible ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        
        DataGrid _dataGrid;

        ObservableCollection<ColumnVisibilityViewModel> _columns = new ObservableCollection<ColumnVisibilityViewModel>();


        public DataGrid DataGrid { get { return _dataGrid; } set { SetProperty(ref _dataGrid, value, "DataGrid"); BuildColumnList(); } }

        public ObservableCollection<ColumnVisibilityViewModel> Columns { get { return _columns; } }


        public ICommand Ok { get { return new RelayCommand<object>(OkExecute, null); } }

        public ICommand Cancel { get { return new RelayCommand<object>(CancelExecute, null); } }

        
        public SelectColumnsViewModel()
        {
        }

        void BuildColumnList()
        {
            _columns.Clear();

            foreach (var c in _dataGrid.Columns)
            {
                _columns.Add(new ColumnVisibilityViewModel(c));
            }

            OnPropertyChanged("Columns");
        }

        private void OkExecute(object obj)
        {
            foreach (var c in _columns)
            {
                c.ApplyChanges();
            }
        }

        private void CancelExecute(object obj)
        {
        }
    }
}
