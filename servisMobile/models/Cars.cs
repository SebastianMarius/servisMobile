using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisMobile.models
{
    public class Cars
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100), NotNull]
        public string Marca { get; set; }
        [NotNull]
        public string Revizie { get; set; }
        [NotNull]
        public decimal PretLucrare { get; set; }
        [NotNull, Indexed]
        public DateTime FixDate { get; set; }

        public string Description { get; set; }

        [NotNull]
        public string Proprietar {  get; set; }

    }
}
