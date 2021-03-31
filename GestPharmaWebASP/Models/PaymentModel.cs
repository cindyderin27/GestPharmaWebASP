using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class PaymentModel
    {
        public int PayemenTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public PaymentModel()
        {

        }
    }
}