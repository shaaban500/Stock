﻿using Stock.Domain.Entities.Products;

namespace Stock.Domain.ViewModels.Stores
{
    public class StoreViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
