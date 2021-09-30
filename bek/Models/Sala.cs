using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bek.Models
{
    [Table("Sala")]

    public class Sala
    {
        [Key]
        [Column("ID")]
        public int ID {get; set; }

        [Column("BrojSale")]
        public int BrojSale {get; set; }

        [Column("BrojRedova")]
        public int BrojRedova {get; set; }

        [Column("BrojMestaPoRedu")]
        public int BrojMestaPoRedu {get; set; }


        public virtual List<Sediste> Sedista {get; set; }


    }
    
   

    


}