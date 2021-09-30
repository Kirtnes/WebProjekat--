using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bek.Models;
using Microsoft.EntityFrameworkCore;

namespace bek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class SalaController : ControllerBase
    {

        public SalaContext Context {get; set; }

        public SalaController(SalaContext context)
        {
            Context = context;
        }


        //KONTROLERI ZA SALU
        //PREUZMI SALE
        [Route("PreuzmiSale")]
        [HttpGet]
        public async Task<List<Sala>> PreuzmiSale()
        {
            //ovdemozxdagreska?
            return await Context.Sale.Include(p=>p.Sedista).ThenInclude(p => p.Osobe).ToListAsync();
            
        }
        //UPISI SALU
        [Route("UpisiSalu")]
        [HttpPost]
        public async Task UpisiSalu([FromBody]Sala sala)
        {
            Context.Sale.Add(sala);
            await Context.SaveChangesAsync();
        }
        //IZMENI SALU
        [Route("IzmeniSalu")]
        [HttpPut]
        public async Task IzmeniSalu([FromBody]Sala sala)
        {
            Context.Update<Sala>(sala);
            await Context.SaveChangesAsync();
        }
        //IZBRISI SALU
        [Route("IzbrisiSalu")]
        [HttpDelete]
        public async Task IzbrisiSalu(int id)
        {
            var sala=await Context.Sale.FindAsync(id);
            Context.Remove(sala);
            await Context.SaveChangesAsync();
        }


        //KONTROLERI ZA SEDISTA

        //IZBRISI SEDISTE
        [Route("IzbrisiSediste")]
        [HttpDelete]
        public async Task IzbrisiSediste(int id)
        {
            var sediste = await Context.Sedista.FindAsync(id);
            Context.Remove(sediste);
            await Context.SaveChangesAsync();
        }
        //UPISI SEDISTE
        [Route("UpisiSediste/{idSale}")]
        [HttpPost]
        public async Task UpisiSediste(int idSale, [FromBody] Sediste sediste)
        {
            var Sala = await Context.Sale.FindAsync(idSale);
            sediste.Sala = Sala;
            Context.Sedista.Add(sediste);
            await Context.SaveChangesAsync();
        }


        //KONTROLERI ZA OSOBU
        //UPISI OSOBU
        [Route("UpisiOsobu/{idSedista}")]
        [HttpPost]
        public async Task UpisiSediste(int idSedista, [FromBody] Osoba osoba)
        {
            var Sediste = await Context.Sedista.FindAsync(idSedista);
            osoba.Sediste = Sediste;
            Context.Osobe.Add(osoba);
            await Context.SaveChangesAsync();
        }
        //IZMENI OSOBU
        [Route("IzmeniOsobu")]
        [HttpPut]
        public async Task IzmeniOsobu([FromBody]Osoba osoba)
        {
            Context.Update<Osoba>(osoba);
            await Context.SaveChangesAsync();
        }
        //IZBRISI OSOBU
        [Route("IzbrisiOsobu")]
        [HttpDelete]
        public async Task IzbrisiOsobu(int id)
        {
            var osoba = await Context.Osobe.FindAsync(id);
            Context.Remove(osoba);
            await Context.SaveChangesAsync();
        }
        //PREUZMI OSOBE
        [HttpGet]
        [Route("PreuzmiOsobe/{id}")]
        public async Task<List<Osoba>> PreuzmiOsobe(int id)
        {
            return await Context.Osobe.Where(e => e.Sediste.ID == id).ToListAsync();
        }


    }
}
