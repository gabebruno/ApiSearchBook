﻿namespace BookSearchDomain.Dto
{
    public class FilterDTO
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Illustrator { get; set; }
        public int? InitialNumberPages { get; set; }
        public int? FinalNumberPages { get; set; }
        public double? InitialPrice { get; set; }
        public double? FinalPrice { get; set; }
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }
    }
}
