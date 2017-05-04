using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace DTO
{
    public class SearchElementDetail : INotifyPropertyChanged
    {
        private bool _isCheckedDetail;

        public string Content { get; }

        public string StrSearch { get; }

        public SearchElementDetail(bool ischecked, string contents, string strsearch)
        {
            IsCheckedDetail = ischecked;
            Content = contents;
            StrSearch = strsearch;
        }

        public bool IsCheckedDetail
        {
            get => _isCheckedDetail; set
            {
                if (_isCheckedDetail == value) return;
                _isCheckedDetail = value;
                OnPropertyChanged("IsCheckedDetail");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SearchElement : INotifyPropertyChanged
    {
        public ObservableCollection<SearchElementDetail> SearchElementDetails { get; }
        public bool _isCheckedElement;
        public string Name { get; }
        public SearchElement(bool ischecked, string name, ObservableCollection<SearchElementDetail> searchElementDetails)
        {
            IsCheckedElement = ischecked;
            Name = name;
            SearchElementDetails = searchElementDetails;
        }

        public bool IsCheckedElement
        {
            get => _isCheckedElement; set
            {
                if (_isCheckedElement == value) return;
                _isCheckedElement = value;
                OnPropertyChanged("IsCheckedElement");
                SelectAll(_isCheckedElement, SearchElementDetails);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SelectAll(bool select, IEnumerable<SearchElementDetail> models)
        {
            foreach (SearchElementDetail model in models)
            {
                model.IsCheckedDetail = select;
            }
        }
    }

    public class SearchObject : INotifyPropertyChanged
    {
        public bool _isChecked;
        public string Name { get; }
        public ObservableCollection<SearchElement> SearchElements { get; }
        public SearchObject(bool ischecked, string name, params SearchElement[] searchElements)
        {
            _isChecked = ischecked;
            Name = name;
            SearchElements = new ObservableCollection<SearchElement>(searchElements);
        }

        public bool IsChecked
        {
            get => _isChecked; set
            {
                if (_isChecked == value) return;
                _isChecked = value;
                OnPropertyChanged("IsChecked");
                SelectAll(_isChecked, SearchElements);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SelectAll(bool select, IEnumerable<SearchElement> models)
        {
            foreach (SearchElement model in models)
            {
                model.IsCheckedElement = select;
            }
        }
    }

    public class TreesSearchModel : INotifyPropertyChanged
    {
        public ObservableCollection<SearchObject> SearchObjects { get; }

        public ObservableCollection<SearchElement> SearchElements { get; }

        public ObservableCollection<SearchElementDetail> SearchElementDetails { get; }

        public AnotherCommandImplementation AddCommand { get; }

        public AnotherCommandImplementation RemoveSelectedItemCommand { get; }
        
        public TreesSearchModel(DataTable TableObjectSearch)
        {
            SearchElementDetails = new ObservableCollection<SearchElementDetail>();
            for (int i=0; i< TableObjectSearch.Rows.Count; i++)
            {
                SearchElementDetail sed = new SearchElementDetail(false, TableObjectSearch.Rows[i][2].ToString(), TableObjectSearch.Rows[i][1].ToString());
                SearchElementDetails.Add(sed);
            }
            SearchObjects = new ObservableCollection<SearchObject>
            {
                new SearchObject(false,"Nhân Viên",
                    new SearchElement (false, "Thông tin chung", SearchElementDetails))
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
