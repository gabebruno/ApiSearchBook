using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchDomain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Specifications Specifications { get; set; }
    }
}
