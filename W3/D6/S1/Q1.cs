// Create a Book.cs class in Models

using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
