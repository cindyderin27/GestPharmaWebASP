using GestPharmMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestPharmMobile.ModelPages
{
    class ProductViewModel : INotifyPropertyChanged
    {
        readonly IList<Review> source;
        public ObservableCollection<Review> ItemPreview { get; private set; }

        public ProductViewModel()
        {
            source = new List<Review>();
            CreateItemCollection();
        }

        void CreateItemCollection()
        {
            source.Add(new Review
            {
                Image = "user1",
                Name = "Samuel Smith",
                Revue = "Wonderful jean, perfect gift for my girl for our anniversary!",
                Rating = "4"
            });
            source.Add(new Review
            {
                Image = "user2",
                Name = "Beth Aida",
                Revue = "I love this, paired it with a nice blouse and all eyes on me.",
                Rating = "3"
            });
            source.Add(new Review
            {
                Image = "user1",
                Name = "Samuel Smith",
                Revue = "Wonderful jean, perfect gift for my girl for our anniversary!",
                Rating = "4"
            });
            source.Add(new Review
            {
                Image = "user2",
                Name = "Beth Aida",
                Revue = "I love this, paired it with a nice blouse and all eyes on me.",
                Rating = "3"
            });
            ItemPreview = new ObservableCollection<Review>(source);
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
