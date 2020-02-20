using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PinTest.Models
{
    public class PinKripto
    {

        public int Id { get; set; }
        [Display(Name = "Symbol")]
        public string Symbol { get; set; }
        [Display(Name = "KriptoName")]
        public string KriptoName { get; set; }
        [Display(Name = "USD")]
        public int USD { get; set; }


    }
}
