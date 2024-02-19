using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisMobile.models
{
    public class ListMecanics
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Cars))]
        public int CarsID { get; set; }
        public int MecanicID { get; set; }
    }
}
