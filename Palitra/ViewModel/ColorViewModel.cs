using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Palitra.ViewModel
{
    class ColorViewModel : INotifyPropertyChanged
    {
        private bool checkAlpha;
        private bool checkRed = true;
        private bool checkGreen = true;
        private bool checkBlue = true;
        private byte colorAlpha = 255;
        private byte colorRed = 128;
        private byte colorGreen = 128;
        private byte colorBlue = 128;
        private SolidColorBrush colorBorder;
        private MyColor selectedColor;
        public ObservableCollection<MyColor> Colors { get; set; }
        public ColorViewModel()
        {
            Colors = new ObservableCollection<MyColor>();
            BuildingCode();
        }
        public bool CheckAlpha
        {
            get { return checkAlpha; }
            set { checkAlpha = value;
                ColorAlpha = 255;
            }
        }
        public bool CheckRed
        {
            get { return checkRed; }
            set
            {
                checkRed = value;
                ColorRed = 0;
            }
        }
        public bool CheckGreen
        {
            get { return checkGreen; }
            set
            {
                checkGreen = value;
                ColorGreen = 0;
            }
        }
        public bool CheckBlue
        {
            get { return checkBlue; }
            set
            {
                checkBlue = value;
                ColorBlue = 0;
            }
        }
        public MyColor SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;               
                OnPropertyChanged("SelectedColor");                
            }
        }
        public void BuildingCode()
        {
            ColorBorder = new SolidColorBrush(Color.FromArgb(ColorAlpha, ColorRed, ColorGreen, ColorBlue));            
        }
        
        public SolidColorBrush ColorBorder
        {
            get { return colorBorder; }
            set
            {
                colorBorder = value;
                OnPropertyChanged("ColorBorder");
            }

        }
        public byte ColorAlpha
        {
            get { return colorAlpha; }
            set
            {
                colorAlpha = value;
                OnPropertyChanged("ColorAlpha");
                BuildingCode();
            }
        }

        public byte ColorRed
        {
            get { return colorRed; }
            set
            {
                colorRed = value;
                OnPropertyChanged("ColorRed");
                BuildingCode();
            }
        }
        public byte ColorGreen
        {
            get { return colorGreen; }
            set
            {
                colorGreen = value;
                OnPropertyChanged("ColorGreen");
                BuildingCode();
            }
        }
        public byte ColorBlue
        {
            get { return colorBlue; }
            set
            {
                colorBlue = value;
                OnPropertyChanged("ColorBlue");
                BuildingCode();
            }
        }
        //public void Constructor_16x_Code()
        //{
        //    ColorBorder = new SolidColorBrush(Color.FromArgb(ColorAlpha, ColorRed, ColorGreen, ColorBlue));
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private RelayCommand addColor;
        public RelayCommand AddColor
        {
            set { addColor = value; }
            get
            {
                return addColor ?? (addColor = new RelayCommand(obj =>
                  {
                      MyColor color = new MyColor
                      {
                          AlphaColor = colorAlpha,
                          RedColor = colorRed,
                          GreenColor = colorGreen,
                          BlueColor = colorBlue,
                          ColorCode = $"#{colorAlpha:x2}{colorRed:x2}{colorGreen:x2}{colorBlue:x2}"
                      };
                      Colors.Insert(0, color);
                  }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            set { removeCommand = value; }
            get
            {
                return removeCommand??
                new RelayCommand(obj =>
                {
                    MessageBoxResult result = MessageBox.Show($"1 remove _color {obj}", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        MyColor _color = obj as MyColor;
                        if (_color != null)
                        {
                            Colors.Remove(_color);
                        }
                    }                
                    
                },
                obj => {
                    return Colors.Count > 0;
                });
            }
        }
    }
}
