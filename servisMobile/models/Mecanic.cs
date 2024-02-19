using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace servisMobile.models
{
    public class Mecanic
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [OneToMany]
        public List<ListMecanics> ListMecanics { get; set; }

    }
}
