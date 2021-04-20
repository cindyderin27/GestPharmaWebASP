using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GestPharmMobile.Model
{
    class CardModel: INotifyPropertyChanged
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Numbers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Command DecreseTapCommand
        {
            get
            {
                return new Command(val =>
                {
                    var modelObj = (CardModel)val;
                    if (modelObj.Numbers >= 2)
                    {
                        Numbers = (modelObj.Numbers - 1);
                        OnPropertyChanged("numbers");
                    }
                });
            }
        }

        public Command IncreaseTapCommand
        {
            get
            {
                return new Command(val =>
                {
                    Numbers = (Int16.Parse(val.ToString()) + 1);
                    OnPropertyChanged("numbers");
                });
            }
        }
    }
}
