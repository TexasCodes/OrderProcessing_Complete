using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessing_Complete.Models
{
    public class orderClass
    {

        public int OrderID { get; set; }

        public string OrderDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public string TShirtColor { get; set; }

        public string TShirtSize { get; set; }

        public string TShirtPrice { get; set; }

        public string Quantity { get; set; }

        public int OrderTotal { get; set; }

        public int OrderStatusID { get; set; }

        public string Notes { get; set; }

    }
}