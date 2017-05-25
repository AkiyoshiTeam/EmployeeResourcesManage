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
            Component c;
            string mabp = "";
            string tenbp = "";
            foreach(DataRow row in TableOrganizationTree.Rows)
            {
                if(mabp!=row[6].ToString())
                {
                    if(Parts!=null)
                    {
                        c = new Component(tenbp, "Where bp.MaBP='" + mabp + "'", Parts);
                        co.Components.Add(c);
                    }
                    mabp = row[6].ToString();
                    tenbp = row[7].ToString();
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
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
