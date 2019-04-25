using System;

namespace NHC.Claims.DataModel
{
    public class Claims
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal DamageCost { get; set; }
    }
}
