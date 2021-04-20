using System;
using System.Collections.Generic;
using System.Text;

namespace GestPharmMobile.Model
{
    class Track
    {
        public string OrderId { get; internal set; }
        public string Price { get; internal set; }
        public string Status { get; internal set; }
        public int NumberofItems { get; internal set; }

        public Track()
        {

        }

        public Track(string orderId, string price, string status, int numberofItems)
        {
            OrderId = orderId;
            Price = price;
            Status = status;
            NumberofItems = numberofItems;
        }
    }
}
