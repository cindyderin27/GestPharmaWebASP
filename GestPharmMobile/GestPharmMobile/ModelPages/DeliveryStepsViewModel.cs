using GestPharmMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GestPharmMobile.ModelPages
{
    class DeliveryStepsViewModel
    {

        readonly IList<DelivreryStep> source;
        public ObservableCollection<DelivreryStep> DelList { get; private set; }

        int currentFlag = 3; //Starts from 0
        List<TempData> tempData = new List<TempData>() {
            new TempData
            {
                Name="Order Signed",
                Location="Lagos State, Nigeria",
                DateMon="20/18",
                Tim="10:00 AM"
            },
            new TempData
            {
                Name="Order Signed",
                Location="Lagos State, Nigeria",
                DateMon="20/18",
                Tim="10:00 AM"
            },
            new TempData
            {
                Name="Order Signed",
                Location="Lagos State, Nigeria",
                DateMon="20/18",
                Tim="10:00 AM"
            },
            new TempData
            {
                Name="Order Signed",
                Location="Lagos State, Nigeria",
                DateMon="20/18",
                Tim="10:00 AM"
            },
            new TempData
            {
                Name="Order Signed",
                Location="Lagos State, Nigeria",
                DateMon="20/18",
                Tim="10:00 AM"
            }

        };
        public DeliveryStepsViewModel()
        {
            source = new List<DelivreryStep>();
            CreateCollection();
        }
        void CreateCollection()
        {

            Xamarin.Forms.Color frColor = Xamarin.Forms.Color.FromHex("#00C569");
            Xamarin.Forms.Color linColor = Xamarin.Forms.Color.FromHex("#00C569");

            for (int i = 0; i < tempData.Count; i++)
            {
                if (i == (tempData.Count - 1))
                {
                    linColor = Xamarin.Forms.Color.Transparent;
                }
                else
                {
                    if (i < currentFlag)
                    {
                        frColor = Xamarin.Forms.Color.FromHex("#00C569");
                        linColor = Xamarin.Forms.Color.FromHex("#00C569");
                    }
                    else
                    {
                        frColor = Xamarin.Forms.Color.Transparent;
                        linColor = Xamarin.Forms.Color.FromHex("#DDDDDD");
                    }
                }
                source.Add(new DelivreryStep
                {
                    Name = tempData[i].Name,
                    Location = tempData[i].Location,
                    DateMon = tempData[i].DateMon,
                    Tim = tempData[i].Tim,
                    ColorFrame = frColor,
                    ColorLine = linColor
                });

            }
            DelList = new ObservableCollection<DelivreryStep>(source);
        }

    }

    public class TempData
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string DateMon { get; set; }
        public string Tim { get; set; }
    }
}
