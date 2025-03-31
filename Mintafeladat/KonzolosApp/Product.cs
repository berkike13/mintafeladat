using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolosApp
{
    public class Product
    {
        public int Id{  get; set; }
        public string Name{ get; set; }
        public int Quantity {  get; set; }

        public Product(string sor)
        {
            string[] puffer = sor.Split(',');
            this.Id = int.Parse(puffer[0]);
            this.Name = puffer[1];
            this.Quantity = int.Parse(puffer[2]);
        }

    }
}
