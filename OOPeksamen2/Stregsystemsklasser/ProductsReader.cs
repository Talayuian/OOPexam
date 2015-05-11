using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOPeksamen2
{
    public class ProductsReader
    {
        public Dictionary<uint, Product> productsdic = new Dictionary<uint, Product>();

        public Dictionary<uint, Product> Productreader()
        {
            string[] ProductReadLine = File.ReadAllLines("..\\..\\resourcer\\products.csv", Encoding.UTF7);
            int StringLenTemp = ProductReadLine.Length;
            for (int i = 1; i < StringLenTemp; i++)
            {
                //http://www.dotnetperls.com/remove-html-tags
                ProductReadLine[i] = Regex.Replace(ProductReadLine[i],"<.*?>",string.Empty);
                ProductReadLine[i] = ProductReadLine[i].Replace("\"","");
                string[] StringSplit = ProductReadLine[i].Split(';');
                Product product = new Product(uint.Parse(StringSplit[0]), StringSplit[1], uint.Parse(StringSplit[2]), StringSplit[3].Equals("1") ? true : false);

                productsdic.Add(product.ProductID, product);
            }
            return productsdic;
        }
    }
}
