using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class Product
    {
        public Product(uint id, string name, uint price, bool active)
        {
            ProductID = SetProductID(id);
            ProductName = SetProductName(name);
            Price = SetPrice(price);
            SetActive(active);
            CanBeBoughtOnCredit = false;
        }
        protected Product() { }
        public uint ProductID { get; protected set; }
        public string ProductName { get; protected set; }
        public uint Price { get; protected set; }
        public bool Active { get; protected set; }
        public bool CanBeBoughtOnCredit { get; protected set; }

        protected uint SetProductID(uint productID)
        {
            if (productID == 0)
                throw new ArgumentNullException("product med 0 ID'et");
            else
                return productID;
        }
        protected string SetProductName(string name)
        {
            if (!(name == null || name == ""))
                return name;
            else throw new ArgumentNullException("forkert indtastning");
        }
        public uint SetPrice(uint newPrice)
        {
            Price = newPrice;
            return Price;
        }
        public void SetActive(bool act)
        {
            Active = act;
            
        }
        public void SetCanBeBoughtOnCredit(bool YesNo)
        {
            CanBeBoughtOnCredit = YesNo;
            
        }

    }
}
