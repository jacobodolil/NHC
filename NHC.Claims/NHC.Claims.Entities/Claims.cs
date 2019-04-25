using System;
using System.ComponentModel.DataAnnotations;

namespace NHC.Claims.Entities
{
    public class Claims
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [Range(0, 100000, ErrorMessage = "Damage Cost should not be more than 100000")]
        public decimal DamageCost { get; set; }
    }
}
