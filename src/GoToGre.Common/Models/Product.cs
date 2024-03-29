﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoToGre.Common.Models
{
    public class Product
    {
        public Product() { 
        }
        public Product(int id = 0, string name ="", string imagUrl = "", string productType = "", int stockAmmount= 0,double globalPrice= 0.0) {
            Id = id;
            Name = name;
            ProductType = productType;
            ImageURL = imagUrl;
            StockAmount = stockAmmount;
            GlobalPrice = globalPrice;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string ProductType { get; set; }
        public int StockAmount { get; set; }
        public int TargetStock { get; set; }
        public double GlobalPrice { get; set; }

        

    }
}
