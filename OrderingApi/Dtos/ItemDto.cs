using System;
using OrderingApi.Enums;

namespace OrderingApi.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Categories Category { get; set; }
    }
}
