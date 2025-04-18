﻿using Doga.UI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doga.UI.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }


        public string Username { get; set; }

        public string AdressBasligi { get; set; }

        public string Adres1 { get; set; }

        public string Sehir { get; set; }

        public string Semt { get; set; }

        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
        public virtual List<OrderLineModel> Orderlines { get; set; }
    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
 


    }
}