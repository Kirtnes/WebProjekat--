using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace bek.Models{


    [Table("Sediste")]
    public class Sediste
    {

        [Key]
        [Column("ID")]
        public int ID {get; set; }

        [Column("IDsedista")]
        public int IDsedista {get; set; }
        
        //ima samo jedna osoba, mozda ne treba lista?
        public virtual List<Osoba> Osobe {get; set; }

        [JsonIgnore]
        public Sala Sala {get; set;}

    }


}