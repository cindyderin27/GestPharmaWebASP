using GestPharmMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace GestPharmMobile.ModelPages
{
    class BrandViewModel
    {
        readonly IList<BrandItems> source;
        IList<MedicamentPreview> model;
        public ObservableCollection<BrandItems> ItemList { get; private set; }
        public ObservableCollection<MedicamentPreview> ItemPreview { get; private set; }

       readonly ICommand tapCommand;
        public BrandViewModel()
        {
            source = new List<BrandItems>();
            model = new List<MedicamentPreview>();
            CreateMenuCollection();
            CreateItemCollection();
        }

        public ICommand TapCommand
        {
            get
            {
                return tapCommand;
            }
        }
        async void CreateItemCollection()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                        "http://localhost:81/GespharmWeb.Api/api/Medicament"
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IList<MedicamentPreview>>(json);
                }
            }
           
            ItemPreview = new ObservableCollection<MedicamentPreview>(model);
        }
        void CreateMenuCollection()
        {
            source.Add(new BrandItems
            {
                Brand = "Bang and Olufsen",
                BrandName = "All"
            });
            source.Add(new BrandItems
            {
                Brand = "Bang and Olufsen",
                BrandName = "Headphones"
            });
            source.Add(new BrandItems
            {
                Brand = "Bang and Olufsen",
                BrandName = "Speakers"
            });
            source.Add(new BrandItems
            {
                Brand = "Bang and Olufsen",
                BrandName = "Microphones"
            });
            ItemList = new ObservableCollection<BrandItems>(source);
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
