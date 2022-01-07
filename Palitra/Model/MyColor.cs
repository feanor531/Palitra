using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Palitra.ViewModel
{
    class MyColor:INotifyPropertyChanged

    {
        private double alpha;
        private double red;
        private double green;
        private double blue;
        private string colorCode;

        public MyColor() { }
        public double AlphaColor
        {
            get { return alpha; }
            set { alpha = value;
                OnPropertyChanged("AlphaColor");
            }
        }

        public double RedColor
        {
            get { return red; }
            set
            {
                red = value;
                OnPropertyChanged("RedColor");
            }
        }
        public double GreenColor
        {
            get { return green; }
            set
            {
                green = value;
                OnPropertyChanged("GreenColor");
            }
        }
        public double BlueColor
        {
            get { return blue; }
            set
            {
                blue = value;
                OnPropertyChanged("BlueColor");
            }
        }
        public string ColorCode
        {
            get { return colorCode; }
            set
            {
                colorCode = value;
                OnPropertyChanged("ColorCode");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

    
}
