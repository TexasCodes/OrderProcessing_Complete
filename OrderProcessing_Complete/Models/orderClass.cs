using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrderProcessing_Complete.Models
{
    public class orderClass
    {

        public int OrderID { get; set; }

        [DisplayName("Order Date")]
        public string OrderDate { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Customer Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("Customer Phone")]
        public string CustomerPhone { get; set; }

        [DisplayName("TShirt Color")]
        public string TShirtColor { get; set; }

        [DisplayName("TShirt Size")]
        public string TShirtSize { get; set; }

        [DisplayName("TShirt Price")]
        public string TShirtPrice { get; set; }

        
        public string Quantity { get; set; }

        [DisplayName("Order Total")]
        public int OrderTotal { get; set; }

        [DisplayName("Order Status")]
        public int OrderStatusID { get; set; }

        public string Notes { get; set; }

        public List<orderClass> statusInfo { get; set; }

    }
}