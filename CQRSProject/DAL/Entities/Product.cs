﻿namespace CQRSProject.DAL.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
