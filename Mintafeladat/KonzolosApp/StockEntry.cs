using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolosApp
{
    public class StockEntry
    {
        public int Id { get; set; }
        public int Supplier_id { get; set; }
        public int Product_id {  get; set; }
        public DateTime Stock_date { get; set; }

        public StockEntry(string sor) 
        {
            string[] puffer = sor.Split(',');
            this.Id = int.Parse(puffer[0]);
            this.Supplier_id = int.Parse(puffer[1]);
            this.Product_id = int.Parse(puffer[2]);
            this.Stock_date = DateTime.Parse(puffer[3]);
        }

    }
}
