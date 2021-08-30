using System.Collections.Generic;
using System.Linq;

namespace CicekSepetiStudyCase.Domain.Entities
{
    public class Basket
    { 
        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }

        public int ProductCount => Items.Sum(x => x.Quantity);

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
