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
    public class ListsAndGridsViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;
        private readonly ObservableCollection<SelectableViewModel> _items5;
        private readonly ObservableCollection<SelectableViewModel> _items6;
        private bool _isAllItems1Selected;
        
        public ListsAndGridsViewModel()
        {
            _items1 = CreateData1();
            _items2 = CreateData2();
            _items3 = CreateData3();
            _items5 = CreateData5();
            _items6 = CreateData6();
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
                    Name = "Employees Resources",
                    Description = "Manage Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=true,
                    Icon = "HomeModern",
                    IconNum = 825,
                    Code = 'C',
                    Name = "Company",
                    Description = "Company Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Coin",
                    IconNum = 417,
                    Code = 'P',
                    Name = "Payroll",
                    Description = "Payroll for Employees"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Timetable",
                    IconNum = 1477,
                    Code = 'T',
                    Name = "Time Attendance",
                    Description = "Download and Manage Time"
                }
            };
        }

        private static ObservableCollection<SelectableViewModel> CreateData2()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountSearch",
                    Code = 'S',
                    Name = "Employees Search",
                    Description = "Search(watch) by Information Employee(s)"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountCheck",
                    Code = 'S',
                    Name = "Employees Selector",
                    Description = "Selector Employee(s)"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountPlus",
                    Code = 'A',
                    Name = "Add Employee",
                    Description = "Add Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountMultiplePlus",
                    Code = 'A',
                    Name = "Add Multiple Employees",
                    Description = "Add Multiple Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountSettings",
                    Code = 'E',
                    Name = "Edit Employees",
                    Description = "Edit Employee Resources"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "AccountMultipleMinus",
                    Code = 'L',
                    Name = "Layoff Employees",
                    Description = "Layoff Multiple Employees Setting"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "FileDocumentBox",
                    Code = 'C',
                    Name = "Contract",
                    Description = "Contract Setting"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "ChartBar",
                    Code = 'R',
                    Name = "Report",
                    Description = "Report File Export"
                }
            };
        }

        private static ObservableCollection<SelectableViewModel> CreateData3()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "TableLarge",
                    Code = 'P',
                    Name = "Parts of Company",
                    Description = "Watch Parts for Company"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "TableRowPlusAfter",
                    Code = 'A',
                    Name = "Add Part(s)",
                    Description = "Add Part(s) for Company"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "TableEdit",
                    Code = 'E',
                    Name = "Edit Part(s)",
                    Description = "Edit Part(s) of Company"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "TableRowRemove",
                    Code = 'R',
                    Name = "Remove Part(s)",
                    Description = "Remove Part(s) of Company"
                }

            };
        }

        private static ObservableCollection<SelectableViewModel> CreateData5()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "CurrencyUsd",
                    Code = 'S',
                    Name = "Salary Calculation",
                    Description = "Salary Calculation"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "Sigma",
                    Code = 'D',
                    Name = "Salary Formula",
                    Description = "Salary Formula Settings"
                }
            };
        }

        private static ObservableCollection<SelectableViewModel> CreateData6()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "CalendarCheck",
                    Code = 'D',
                    Name = "Default",
                    Description = "Time Attendance Default"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "CalendarPlus",
                    Code = 'D',
                    Name = "Download",
                    Description = "Time Attendance Download"
                },
                new SelectableViewModel
                {
                    IsSelected=false,
                    Icon = "CalendarClock",
                    Code = 'A',
                    Name = "Assign Shift",
                    Description = "Assign Shift for Employee"
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

        public ObservableCollection<SelectableViewModel> Items5
        {
            get { return _items5; }
        }

        public ObservableCollection<SelectableViewModel> Items6
        {
            get { return _items6; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}