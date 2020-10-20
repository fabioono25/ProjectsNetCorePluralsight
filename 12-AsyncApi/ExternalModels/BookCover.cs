using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.ExternalModels
{
    public class BookCover
    {
        public string Name { get; set; }
        public byte[] Content { get; set; } // it can be deleted to show the results
    }
}
