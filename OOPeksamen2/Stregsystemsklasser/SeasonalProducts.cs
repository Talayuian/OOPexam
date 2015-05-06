using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class SeasonalProducts:Product
    {
        public SeasonalProducts(uint id, string name, uint price, bool active, DateTime seasonstart, DateTime seasonend)
        {
            ProductID = SetProductID(id);
            ProductName = SetProductName(name);
            Price = SetPrice(price);
            Active = SetActive(active);
            CanBeBoughtOnCredit = false;
            SeasonStart = seasonstart;
            SeasonEnd = seasonend;
        }
        public DateTime SeasonStart { get; protected set; }
        public DateTime SeasonEnd { get; protected set; }

    }
}
