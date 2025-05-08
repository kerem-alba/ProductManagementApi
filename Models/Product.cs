﻿namespace ProductManagementApi.Models
{
    public class Product
    {
        public int Id { get; set; }           // Ürün kimliği
        public string? Name { get; set; }       // Ürün adı
        public decimal Price { get; set; }     // Ürün fiyatı
        public string? Category { get; set; }   // Ürün kategorisi
    }

}
