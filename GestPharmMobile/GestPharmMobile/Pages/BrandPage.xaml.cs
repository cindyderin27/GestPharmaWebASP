using GestPharmMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestPharmMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandPage : TabbedPage
    {
        public BrandPage()
        {
            InitializeComponent();
            //title.Text = name;
            this.ItemsSource = new MainClass[] {
                new MainClass ("All",new List<MedicamentPreview>(){ new MedicamentPreview { Photo = "Image1",NomMedicament = "Smart Bluetooth Speaker", Brand = "Bang and Olufsen",Prix = 90}, new MedicamentPreview { Photo = "Image7", NomMedicament = "B&o Desk Lamp", Brand = "Bang and Olufsen", Prix = 450 },new MedicamentPreview { Photo = "Image8", NomMedicament = "BeoPlay Stand Speaker", Brand = "Bang and Olufsen", Prix = 300} }),
                new MainClass ("Headphones",new List<MedicamentPreview>(){ new MedicamentPreview { Photo = "Image1",NomMedicament = "Smart Bluetooth Speaker", Brand = "Bang and Olufsen", Prix = 90}, new MedicamentPreview { Photo = "Image7", NomMedicament = "B&o Desk Lamp", Brand = "Bang and Olufsen", Prix = 450 },new MedicamentPreview { Photo = "Image8", NomMedicament = "BeoPlay Stand Speaker", Brand = "Bang and Olufsen", Prix = 300} }),
                new MainClass ("Speakers",new List<MedicamentPreview>(){ new MedicamentPreview { Photo = "Image1",NomMedicament = "Smart Bluetooth Speaker", Brand = "Bang and Olufsen", Prix = 90}, new MedicamentPreview { Photo = "Image7", NomMedicament = "B&o Desk Lamp", Brand = "Bang and Olufsen", Prix = 450 },new MedicamentPreview { Photo = "Image8", NomMedicament = "BeoPlay Stand Speaker", Brand = "Bang and Olufsen", Prix = 300} }),
                new MainClass ("Microphones",new List<MedicamentPreview>(){ new MedicamentPreview { Photo = "Image1",NomMedicament = "Smart Bluetooth Speaker", Brand = "Bang and Olufsen", Prix =90}, new MedicamentPreview { Photo = "Image7", NomMedicament = "B&o Desk Lamp", Brand = "Bang and Olufsen", Prix = 450 },new MedicamentPreview { Photo = "Image8", NomMedicament = "BeoPlay Stand Speaker", Brand = "Bang and Olufsen", Prix = 300} }),
            };
        }

        class MainClass
        {
            public MainClass(string name, IList<MedicamentPreview> list)
            {
                this.Name = name;
                this.list = list;
            }

            public string Name { private set; get; }
            public IList<MedicamentPreview> list { private set; get; }

            public override string ToString()
            {
                return Name;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new PageMedicament());
        }
    }
}