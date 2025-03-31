using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolosApp
{
    public class Supplier
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public Supplier(string sor) 
        {
            string[] puffer = sor.Split(',');
            this.Id = int.Parse(puffer[0]);
            this.Name = puffer[1];
            this.Email = puffer[2];
        }
    }
}
