﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Employee_Resources_Manage.Domain
{
    public class ListsAndGridsViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;
        private bool _isAllItems3Selected;

        public ListsAndGridsViewModel()
        {
            _items1 = CreateData();
            _items2 = CreateData();
            _items3 = CreateData();
        }

        public bool IsAllSelected
        {
            get { return _isAllItems3Selected; }
            set
            {
                if (_isAllItems3Selected == value) return;

                _isAllItems3Selected = value;

                OnPropertyChanged("IsAllSelected");
                SelectAll(_isAllItems3Selected, Items3);
            }
        }

        private void SelectAll(bool select, IEnumerable<SelectableViewModel> models)
        {
            foreach (SelectableViewModel model in models)
            {
                model.IsSelected = select;
            }
        }

        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {                    
                    IsSelected=true,
                    Code = 'M',
                    Name = "Material Design",
                    Numeric=1,
                    Description = "Material Design in XAML Toolkit"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Code = 'D',
                    Name = "Dragablz",
                    Description = "Dragablz Tab Control",
                    Numeric=2,
                    Food = "Fries"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Code = 'P',
                    Name = "Predator",
                    Description = "If it bleeds, we can kill it",
                    Numeric=3
                }
            };
        }

        public ObservableCollection<SelectableViewModel> Items1
        {
            get { return _items1; }
        }

        public ObservableCollection<SelectableViewModel> Items2
        {
            get { return _items2; }
        }

        public ObservableCollection<SelectableViewModel> Items3
        {
            get { return _items3; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<string> Foods
        {
            get
            {
                yield return "Burger";
                yield return "Fries";
                yield return "Shake";
                yield return "Lettuce";
            }
        }
    }
}