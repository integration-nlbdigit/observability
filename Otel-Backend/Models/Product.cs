using System;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}