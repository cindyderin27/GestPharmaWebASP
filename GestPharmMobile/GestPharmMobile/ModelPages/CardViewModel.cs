using GestPharmMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestPharmMobile.ModelPages
{
    class CardViewModel : INotifyPropertyChanged
    {
        readonly IList<CardModel> source;
        public ObservableCollection<CardModel> ItemPreview { get; private set; }

        public ICommand DeleteCommand => new Command<CardModel>(RemoveCart);

        public CardViewModel()
        {
            source = new List<CardModel>();
            CreateItemCollection();
        }

        void RemoveCart(CardModel cart)
        {
            if (ItemPreview.Contains(cart))
            {
                ItemPreview.Remove(cart);
            }
        }
        void CreateItemCollection()
        {
            source.Add(new CardModel
            {
                Image = "Item1",
                Name = "Tag Heuer Wristwatch",
                Price = "$2400",
                Numbers = 1
            });
            source.Add(new CardModel
            {
                Image = "Item2",
                Name = "BeoPlay Speaker",
                Price = "$4400",
                Numbers = 1
            });
            source.Add(new CardModel
            {
                Image = "Item3",
                Name = "Electric Kettle",
                Price = "$400",
                Numbers = 1
            });
            source.Add(new CardModel
            {
                Image = "Item4",
                Name = "Bang & Olufsen Case",
                Price = "$4500",
                Numbers = 1
            });
            ItemPreview = new ObservableCollection<CardModel>(source);

        }



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
