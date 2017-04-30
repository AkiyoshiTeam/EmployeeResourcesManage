using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO : INotifyPropertyChanged
    {
        //private bool _isSelected;
        private string _id;
        private string _name;
        private DateTime _dateInto;
        private string _maCV;
        private string _maBP;
        private string _maHD;
        private string _maPB;
        private string _maLL;
        private string _maTTCT;
        private string _image;

        public string Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name; set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateInto
        {
            get => _dateInto; set
            {
                if (_dateInto == value) return;
                _dateInto = value;
                OnPropertyChanged();
            }
        }
        public string MaCV
        {
            get => _maCV; set
            {
                if (_maCV == value) return;
                _maCV = value;
                OnPropertyChanged();
            }
        }
        public string MaBP
        {
            get => _maBP; set
            {
                if (_maBP == value) return;
                _maBP = value;
                OnPropertyChanged();
            }
        }
        public string MaHD
        {
            get => _maHD; set
            {
                if (_maHD == value) return;
                _maHD = value;
                OnPropertyChanged();
            }
        }
        public string MaPB
        {
            get => _maPB; set
            {
                if (_maPB == value) return;
                _maPB = value;
                OnPropertyChanged();
            }
        }
        public string MaLL
        {
            get => _maLL; set
            {
                if (_maLL == value) return;
                _maLL = value;
                OnPropertyChanged();
            }
        }
        public string MaTTCT
        {
            get => _maTTCT; set
            {
                if (_maTTCT == value) return;
                _maTTCT = value;
                OnPropertyChanged();
            }
        }
        public string Image
        {
            get => _image; set
            {
                if (_image == value) return;
                _image = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
