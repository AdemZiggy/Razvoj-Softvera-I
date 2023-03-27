using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{
    public class MaticnaKnjiga
    {
        public int id { get; set; }
        public DateTime datumUpisa { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }
        public DateTime datumOvjere { get; set; }
        public string napomena { get; set; }
        [ForeignKey(nameof(akademskaGodina))]
        public int? akademska_godina_id { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }
        [ForeignKey(nameof(student))]
        public int? studentId { get; set; }
        public Student student { get; set; }
        [ForeignKey(nameof(korisnickiNalog))]
        public int? korisnicki_nalog_id { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
    }
}
