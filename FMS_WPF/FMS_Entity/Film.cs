using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Entity
{
    [Serializable]
    public class Film
    {
        //• Film title(Must be Unique)
        //• Film description
        //• Release year
        //• Rental duration
        //• Rental rate
        //• Length
        //• Replacement cost
        //• Rating
        //• Search Film by Actor
        //• Search Film by Category
        //• Search Film by Language
        //• Search Film by Rating

        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? RentalDuration { get; set; }
        public double? RentalRate { get; set; }
        public short? Length { get; set; }
        public double? ReplacementCost { get; set; }
        public float? Rating { get; set; }
        public string Actors { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
    }
}
