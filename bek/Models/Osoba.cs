using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bek.Models{


    [Table("Osoba")]
    public class Osoba
    {

        [Key]
        [Column("ID")]
        public int ID {get; set; }

        [Column("Ime")]
        public string Ime {get; set; }

        [Column("Prezime")]
        public string Prezime {get; set; }

        [Column("Email")]
        public string Email {get; set; }

        [Column("BrojKarte")]
        public int BrojKarte {get; set; }

        //mozda ne treba? pokazivac na sediste za osobu?
         [JsonIgnore]
        public Sediste Sediste {get; set;}

    }


}