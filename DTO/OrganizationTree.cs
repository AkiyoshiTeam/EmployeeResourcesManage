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
        public string Status { get; }
        public Part(string name, string content, string status)
        {
            Name = name;
            Content = content;
            Status = status;
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
        public string About { get; }
        public string Status { get; }
        public Component(string name, string content, string status, string about, ObservableCollection<Part> parts)
        {
            Name = name;
            Content = content;
            About = about;
            Status = status;
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

        public OrganizationTree(DataSet dsOrganizationTree)
        {
            Company co = new Company("Công ty Akiyoshi", "");
            Companys = new ObservableCollection<Company>();
            Component c;
            string mabp = "";
            string tenbp = "";
            foreach (DataRow rowBP in dsOrganizationTree.Tables[0].Rows)
            {
                mabp = rowBP[0].ToString();
                tenbp = rowBP[1].ToString();
                Parts = new ObservableCollection<Part>();
                foreach (DataRow row in dsOrganizationTree.Tables[1].Rows)
                {
                    if (row[6].ToString() == rowBP[0].ToString())
                    {
                        Part p = new Part(row[1].ToString(), "Where pb.MaPB='" + row[0].ToString() + "'", row[5].ToString());
                        Parts.Add(p);
                    }
                }
                c = new Component(tenbp, "Where bp.MaBP='" + mabp + "'", rowBP[3].ToString(), mabp, Parts);
                co.Components.Add(c);
            }
            Companys.Add(co);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
