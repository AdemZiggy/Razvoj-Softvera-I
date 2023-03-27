using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public class GetVM
        {
            public int id { get; set; }
            public string ime { get; set; }
            public string prezime { get; set; }
            public List<MaticnaKnjiga> listaKnjiga { get; set; }
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            var s = _dbContext.Student.Find(id);
            var novaLista = new GetVM
            {
                id = s.id,
                ime = s.ime,
                prezime = s.prezime,
                listaKnjiga = _dbContext.MaticnaKnjiga.Include(a=>a.akademskaGodina).Include(a=>a.korisnickiNalog).Where(r => r.studentId == id).ToList(),
            };
            return Ok(novaLista);//hsjdhafkjf sdhjhfjhksjhfekjsh dfjsjafjsj nfsjfasdfhj hjshfjsheuhfjdskghaskhgfjkh khfawkhdfjskjkdjfkskjgksa
        }
        public class AddVM
        {
            public int id { get; set; }
            public DateTime datum { get; set; }
            public int godinaStudija { get; set; }
            public int akademska_godina_id { get; set; }
            public float cijenaSkolarine { get; set; }
            public bool obnova { get; set; }

        }
        [HttpPost]
        public ActionResult Add([FromBody] AddVM vm)
        {
            var novaKnjiga = new MaticnaKnjiga();
            _dbContext.Add(novaKnjiga);
            novaKnjiga.studentId = vm.id;
            novaKnjiga.datumUpisa= vm.datum;
            novaKnjiga.godinaStudija= vm.godinaStudija;
            novaKnjiga.akademska_godina_id = vm.akademska_godina_id;
            novaKnjiga.cijenaSkolarine= vm.cijenaSkolarine;
            novaKnjiga.korisnicki_nalog_id = 74;
            novaKnjiga.obnova= vm.obnova;
            _dbContext.SaveChanges();
            return Ok(novaKnjiga);
        }
        public class OvjeraVM
        {
            public DateTime DatumOvjere { get; set; }
            public string napomena { get; set; }
        }
        [HttpPost]
        public ActionResult Ovjera([FromBody] OvjeraVM vm, int id) 
        {
            var s = _dbContext.MaticnaKnjiga.Find(id);
            s.datumOvjere = vm.DatumOvjere;
            s.napomena = vm.napomena;
            _dbContext.SaveChanges();
            return Ok(s);
        }
      

       

    }
}
