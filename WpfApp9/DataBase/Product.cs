using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.DataBase
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string Articul { get; set; }
        public double Price { get; set; }
        public double Sale { get; set; }
        public string Category { get; set; }


    }
}
