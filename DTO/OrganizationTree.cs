using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Part : INotifyPropertyChanged
    {
        public string Name { get; }
        public string Content { get; }
        public Part(string name, string content)
        {
            Name = name;
            Content = content;
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Component : INotifyPropertyChanged
    {
        public ObservableCollection<Part> Parts { get; }
        public string Name { get; }
        public string Content { get; }

        public Component(string name, string content, ObservableCollection<Part> parts)
        {
            Name = name;
            Content = content;
            Parts = parts;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Company : INotifyPropertyChanged
    {
        public string Name { get; }
        public string Content { get; }
        public ObservableCollection<Component> Components { get; }

        public Company(string name, string content, params Component[] components)
        {
            Name = name;
            Content = content;
            Components = new ObservableCollection<Component>(components);
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class OrganizationTree : INotifyPropertyChanged
    {
        public ObservableCollection<Company> Companys { get; }

        public ObservableCollection<Component> Components { get; }

        public ObservableCollection<Part> Parts { get; }

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                this.MutateVerbose(ref _selectedItem, value, args => PropertyChanged?.Invoke(this, args));
            }
        }

        public OrganizationTree(DataTable TableOrganizationTree)
        {
            Company co = new Company("Công ty Akiyoshi", "");
            Companys = new ObservableCollection<Company>();
            //Components = new ObservableCollection<Component>();
            Component c;
            string mabp = "";
            string tenbp = "";
            foreach(DataRow row in TableOrganizationTree.Rows)
            {
                if(mabp!=row[5].ToString())
                {
                    if(Parts!=null)
                    {
                        c = new Component(tenbp, "Where bp.MaBP='" + mabp + "'", Parts);
                        co.Components.Add(c);
                    }
                    mabp = row[5].ToString();
                    tenbp = row[6].ToString();
                    Parts = new ObservableCollection<Part>();
                    Part p = new Part(row[1].ToString(), "Where pb.MaPB='" + row[0].ToString() + "'");
                    Parts.Add(p);
                }
                else
                {
                    Part p = new Part(row[1].ToString(), "Where pb.MaPB='" + row[0].ToString() + "'");
                    Parts.Add(p);
                }
            }
            Companys.Add(co);
            //SearchElementDetails = new ObservableCollection<Part>();
            //SearchObject SearchObjectTemp = new SearchObject(false, "Nhân Viên");
            //for (int i = 0; i < TableObjectSearch.Tables[0].Rows.Count; i++)
            //{
            //    SearchElementDetail sed;
            //    switch (TableObjectSearch.Tables[0].Rows[i][1].ToString())
            //    {
            //        case "MaCV":
            //            {
            //                sed = new SearchElementDetail(false, "Chức vụ", "cv.TenCV");
            //                break;
            //            }
            //        case "MaPB":
            //            {
            //                sed = new SearchElementDetail(false, "Phòng ban", "pb.TenPB");
            //                break;
            //            }
            //        case "MaTT":
            //            {
            //                sed = new SearchElementDetail(false, "Tình trạng", "ttnv.TenTT");
            //                break;
            //            }
            //        case "MaLoaiLuong":
            //            {
            //                sed = new SearchElementDetail(false, "Loại lương", "ll.TenLoaiLuong");
            //                break;
            //            }
            //        default:
            //            {
            //                sed = new SearchElementDetail(false, TableObjectSearch.Tables[0].Rows[i][2].ToString(), " nv." + TableObjectSearch.Tables[0].Rows[i][1].ToString());
            //                break;
            //            }
            //    }
            //    SearchElementDetails.Add(sed);
            //}
            //SearchObjectTemp.SearchElements.Add(new SearchElement(false, "Thông tin chung", "NhanVien", SearchElementDetails));
            //SearchElementDetails = new ObservableCollection<Part>();
            //for (int i = 0; i < TableObjectSearch.Tables[1].Rows.Count; i++)
            //{
            //    SearchElementDetail sed;
            //    switch (TableObjectSearch.Tables[1].Rows[i][1].ToString())
            //    {
            //        case "MaGT":
            //            {
            //                sed = new SearchElementDetail(false, "Giới tính", "gt.TenGT");
            //                break;
            //            }
            //        case "MaTG":
            //            {
            //                sed = new SearchElementDetail(false, "Tôn giáo", "tg.TenTG");
            //                break;
            //            }
            //        case "QuocGia":
            //            {
            //                sed = new SearchElementDetail(false, "Quốc gia", "qg.TenQG");
            //                break;
            //            }
            //        case "TinhTP":
            //            {
            //                sed = new SearchElementDetail(false, "Tỉnh, thành phố", "ttp.TenTinh");
            //                break;
            //            }
            //        case "QuanHuyen":
            //            {
            //                sed = new SearchElementDetail(false, "Quận, huyện", "qh.TenQuan");
            //                break;
            //            }
            //        case "MaDT":
            //            {
            //                sed = new SearchElementDetail(false, "Dân tộc", "dt.TenDT");
            //                break;
            //            }
            //        default:
            //            {
            //                sed = new SearchElementDetail(false, TableObjectSearch.Tables[1].Rows[i][2].ToString(), " tt." + TableObjectSearch.Tables[1].Rows[i][1].ToString());
            //                break;
            //            }
            //    }
            //    //SearchElementDetail sed = new SearchElementDetail(false, TableObjectSearch.Tables[1].Rows[i][2].ToString(), TableObjectSearch.Tables[1].Rows[i][1].ToString());
            //    SearchElementDetails.Add(sed);
            //}
            //SearchObjectTemp.SearchElements.Add(new SearchElement(false, "Thông tin chi tiết", "ThongTinChiTietNhanVien", SearchElementDetails));
            //SearchObjects = new ObservableCollection<SearchObject>();
            //SearchObjects.Add(SearchObjectTemp);
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
