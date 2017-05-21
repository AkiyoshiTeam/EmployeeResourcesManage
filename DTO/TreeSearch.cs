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
        public string Content { get; }
        public SearchElement(bool ischecked, string name, string content, ObservableCollection<SearchElementDetail> searchElementDetails)
        {
            IsCheckedElement = ischecked;
            Name = name;
            Content = content;
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

        //public AnotherCommandImplementation AddCommand { get; }

        //public AnotherCommandImplementation RemoveSelectedItemCommand { get; }

        public TreesSearchModel(DataSet TableObjectSearch)
        {
            SearchElementDetails = new ObservableCollection<SearchElementDetail>();
            SearchObject SearchObjectTemp = new SearchObject(false, "Nhân Viên");
            for (int i = 0; i < TableObjectSearch.Tables[0].Rows.Count; i++)
            {
                SearchElementDetail sed;
                switch (TableObjectSearch.Tables[0].Rows[i][1].ToString())
                {
                    case "MaCV":
                        {
                            sed = new SearchElementDetail(false, "Chức vụ", "cv.TenCV");
                            break;
                        }
                    case "MaPB":
                        {
                            sed = new SearchElementDetail(false, "Phòng ban", "pb.TenPB");
                            break;
                        }
                    case "MaTT":
                        {
                            sed = new SearchElementDetail(false, "Tình trạng", "ttnv.TenTT");
                            break;
                        }
                    case "MaLoaiLuong":
                        {
                            sed = new SearchElementDetail(false, "Loại lương", "ll.TenLoaiLuong");
                            break;
                        }
                    default:
                        {
                            sed = new SearchElementDetail(false, TableObjectSearch.Tables[0].Rows[i][2].ToString(), " nv."+TableObjectSearch.Tables[0].Rows[i][1].ToString());
                            break;
                        }
                }
                SearchElementDetails.Add(sed);
            }
            SearchObjectTemp.SearchElements.Add(new SearchElement(false, "Thông tin chung", "NhanVien", SearchElementDetails));
            SearchElementDetails = new ObservableCollection<SearchElementDetail>();
            for (int i = 0; i < TableObjectSearch.Tables[1].Rows.Count; i++)
            {
                SearchElementDetail sed;
                switch (TableObjectSearch.Tables[1].Rows[i][1].ToString())
                {
                    case "MaGT":
                        {
                            sed = new SearchElementDetail(false, "Giới tính", "gt.TenGT");
                            break;
                        }
                    case "MaTG":
                        {
                            sed = new SearchElementDetail(false, "Tôn giáo", "tg.TenTG");
                            break;
                        }
                    case "QuocGia":
                        {
                            sed = new SearchElementDetail(false, "Quốc gia", "qg.TenQG");
                            break;
                        }
                    case "TinhTP":
                        {
                            sed = new SearchElementDetail(false, "Tỉnh, thành phố", "ttp.TenTinh");
                            break;
                        }
                    case "QuanHuyen":
                        {
                            sed = new SearchElementDetail(false, "Quận, huyện", "qh.TenQuan");
                            break;
                        }
                    case "MaDT":
                        {
                            sed = new SearchElementDetail(false, "Dân tộc", "dt.TenDT");
                            break;
                        }
                    default:
                        {
                            sed = new SearchElementDetail(false, TableObjectSearch.Tables[1].Rows[i][2].ToString(), " tt." + TableObjectSearch.Tables[1].Rows[i][1].ToString());
                            break;
                        }
                }
                //SearchElementDetail sed = new SearchElementDetail(false, TableObjectSearch.Tables[1].Rows[i][2].ToString(), TableObjectSearch.Tables[1].Rows[i][1].ToString());
                SearchElementDetails.Add(sed);
            }
            SearchObjectTemp.SearchElements.Add(new SearchElement(false, "Thông tin chi tiết", "ThongTinChiTietNhanVien", SearchElementDetails));
            SearchObjects = new ObservableCollection<SearchObject>();
            SearchObjects.Add(SearchObjectTemp);
            //SearchObjects = new ObservableCollection<SearchObject>
            //{
            //    new SearchObject(false,"Nhân Viên",
            //        new SearchElement (false, "Thông tin chung", SearchElementDetails))
            //};

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
