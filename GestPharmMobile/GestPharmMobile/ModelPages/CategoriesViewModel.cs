using GestPharmMobile.Model;
using GestPharmMobile.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestPharmMobile.ModelPages
{
    class CategoriesViewModel : INotifyPropertyChanged
    {
        readonly IList<FeaturedBrand> source1;
        public ObservableCollection<FeaturedBrand> FeaturedItemPreview { get; private set; }

        IList<MedicamentPreview> source;
        public ObservableCollection<MedicamentPreview> ItemPreview { get; private set; }

        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public CategoriesViewModel()
        {
            source = new List<MedicamentPreview>();
            source1 = new List<FeaturedBrand>();
            CreateItemCollection();
            CreateFeaturedItemCollection();

            ItemTapCommand = new Command<MedicamentPreview>(items =>
            {
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync((new PageMedicament()));
            });

            FeaturedTapCommand = new Command<FeaturedBrand>(brand =>
            {
                string selBrand = brand.Brand;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new BrandPage()));
            });
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
                    source = JsonConvert.DeserializeObject<IList<MedicamentPreview>>(json);
                }
            }

            ItemPreview = new ObservableCollection<MedicamentPreview>(source);
        }

        void CreateFeaturedItemCollection()
        {
            source1.Add(new FeaturedBrand
            {
                ImageUrl = "Icon_Apple",
                Brand = "Apple Inc",
                Details = "5693 Products"
            });
            source1.Add(new FeaturedBrand
            {
                ImageUrl = "beats",
                Brand = "Beats",
                Details = "1124 Products"
            });
            source1.Add(new FeaturedBrand
            {
                ImageUrl = "Icon_Bo",
                Brand = "B&o",
                Details = "5693 Products"
            });

            FeaturedItemPreview = new ObservableCollection<FeaturedBrand>(source1);
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
