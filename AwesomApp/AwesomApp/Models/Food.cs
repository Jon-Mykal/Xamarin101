using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomApp.Models
{
    public class Food
    {
        public Food()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Kitchen { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
