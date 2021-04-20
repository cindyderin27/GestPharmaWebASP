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
    class MedicamentPreviewViewModel : INotifyPropertyChanged
    {
        readonly IList<MedicamentPreview> source;
        public ObservableCollection<MedicamentPreview> ItemPreview { get; private set; }

        readonly IList<FeaturedBrand> source1;
        public ObservableCollection<FeaturedBrand> FeaturedItemPreview { get; private set; }

        IList<Categorie> sourceCat;
        public ObservableCollection<Categorie> Categories { get; private set; }

        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }
        public MedicamentPreviewViewModel()
        {
            source = new List<MedicamentPreview>();
            source1 = new List<FeaturedBrand>();
            sourceCat = new List<Categorie>();
            CreateItemCollection();
            CreateFeaturedItemCollection();
            CreateCategoriesCollection();

            ItemTapCommand = new Command<MedicamentPreview>(items =>
            {
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync((new PageMedicament()));
            });

            CatTapCommand = new Command<Categorie>(items =>
            {
                string selcate = items.NomCategorie;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new PageCategorie());
            });

            FeaturedTapCommand = new Command<FeaturedBrand>(brand =>
            {
                string selBrand = brand.Brand;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new BrandPage()));
            });
        }

        async void CreateCategoriesCollection()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync
                    (
                    "http://localhost:81/GespharmWeb.Api/api/Categorie"
                    );
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    sourceCat = JsonConvert.DeserializeObject<IList<Categorie>>(json);
                }
            }

            Categories = new ObservableCollection<Categorie>(sourceCat);
        }
        void CreateFeaturedItemCollection()
        {
            source1.Add(new FeaturedBrand
            {
                ImageUrl = "Icon_Bo",
                Brand = "B&o",
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
                ImageUrl = "Icon_Apple",
                Brand = "Apple Inc",
                Details = "5693 Products"
            });

            FeaturedItemPreview = new ObservableCollection<FeaturedBrand>(source1);
        }
        void CreateItemCollection()
        {
            source.Add(new MedicamentPreview
            {
                Photo = "Image1",
                NomMedicament = "BeoPlay Speaker",
                Brand = "Bang and Olufsen",
                Prix = 755
            });
            source.Add(new MedicamentPreview
            {
                Photo = "Image2",
                NomMedicament = "Leather Wristwatch",
                Brand = "Tag Heuer",
                Prix = 450
            });
            source.Add(new MedicamentPreview
            {
                Photo = "Image3",
                NomMedicament = "Smart Bluetooth Speaker",
                Brand = "Google LLC",
                Prix = 9000
            });
            source.Add(new MedicamentPreview
            {
                Photo = "Image4",
                NomMedicament = "Smart Luggage",
                Brand = "Smart Inc",
                Prix = 1200
            });
            ItemPreview = new ObservableCollection<MedicamentPreview>(source);
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
