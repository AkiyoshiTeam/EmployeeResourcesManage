using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Employee_Resources_Manage.Domain
{
    public class ItemSorter : IComparer
    {
        private string PropertyName { get; set; }

        public ItemSorter(string propertyName)
        {
            PropertyName = propertyName;
        }
        public int Compare(object x, object y)
        {
            SelectableViewModel ix = (SelectableViewModel)x;
            SelectableViewModel iy = (SelectableViewModel)y;

            switch (PropertyName)
            {
                case "Name":
                    return 0;
                case "Age":
                    //if (ix.Age > iy.Age) return 1;
                    //if (iy.Age > ix.Age) return -1;
                    return 0;
                default:
                    throw new InvalidOperationException("Cannot sort by " +
                                                         PropertyName);
            }
        }
    }
    public class ListsAndGridsViewCommand : ICommand
    {
        private ListsAndGridsViewModel _ListsAndGridsViewModel;

        public ListsAndGridsViewCommand(ListsAndGridsViewModel avm)
        {
            _ListsAndGridsViewModel = avm;
        }

        public void Execute(object parameter)
        {
            _ListsAndGridsViewModel.ExecuteCommand(parameter.ToString());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
    public class ListsAndGridsViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;
        private bool _isAllItems1Selected;
        public ICollectionView ItemsView { get; set; }
        public ListsAndGridsViewCommand ListsAndGridsViewCommand
        {
            get { return new ListsAndGridsViewCommand(this); }
        }
        
        public void ExecuteCommand(string command)
        {
            ListCollectionView list = (ListCollectionView)ItemsView;
            switch (command)
            {
                case "SortByName":
                    list.CustomSort = new ItemSorter("Name");
                    return;
                case "SortByAge":
                    list.CustomSort = new ItemSorter("Age");
                    return;
                case "ApplyFilter":
                    list.Filter = new Predicate<object>(x =>((SelectableViewModel)x).Name == "");
                    return;
                case "RemoveFilter":
                    list.Filter = null;
                    return;
                default:
                    return;
            }
        }
        public ListsAndGridsViewModel()
        {
            _items1 = CreateData1();
            _items2 = CreateData();
            _items3 = CreateData();
        }

        public bool IsAllSelected
        {
            get { return _isAllItems1Selected; }
            set
            {
                if (_isAllItems1Selected == value) return;

                _isAllItems1Selected = value;

                OnPropertyChanged("IsAllSelected");
                SelectAll(_isAllItems1Selected, Items3);
                SelectAll(_isAllItems1Selected, Items1);
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
                    Icon = "AccountSettingsVariant",
                    IconNum = 24,
                    Code = 'E',
                    Name = "Employee Resources",
                    Numeric=1,
                    Description = "Manage Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Timetable",
                    IconNum = 1477,
                    Code = 'T',
                    Name = "Time Attendance",
                    Description = "Download and Manage Time",
                    Numeric=3
                }
            };
        }

        private static ObservableCollection<SelectableViewModel> CreateData1()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    IsSelected=true,
                    Icon = "AccountSettingsVariant",
                    IconNum = 24,
                    Code = 'E',
                    Name = "Employee Resources",
                    Numeric=1,
                    Description = "Manage Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,

                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employee",
                    Numeric=2,
                },

                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Timetable",
                    IconNum = 1477,
                    Code = 'T',
                    Name = "Time Attendance",
                    Description = "Download and Manage Time",
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