using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Classes
{
    internal class BooksByReader
    {

     
        public class Reader
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string photo { get; set; }
        }

        public class Record
        {
            public DateTime dateStart { get; set; }
            public DateTime dateEnd { get; set; }
            public Book book { get; set; }
        }

        public class Book
        {
            public string title { get; set; }
            public string author { get; set; }
            public string genre { get; set; }
            public string subGenre { get; set; }
            public string height { get; set; }
            public string publisher { get; set; }
        }

    }
}
