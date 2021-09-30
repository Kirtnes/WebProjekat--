import { Osoba } from "./Osoba.js";
import { Sala } from "./Sala.js";
import { Sediste } from "./Sediste.js";



fetch("https://localhost:5001/Sala/PreuzmiSale").then(p=>
{
    p.json().then(data => 
    {
        data.forEach(sala =>
            {
                const x = new Sala(sala.brojSale,sala.brojRedova,sala.brojMestaPoRedu);
                x.crtajSalu(document.body);

                    
                    sala.sedista.forEach(sed =>{
                
                    fetch("https://localhost:5001/Sala/PreuzmiOsobe/"+sed.id).then(k1=>k1.json().then(k2=>k2.forEach(k3=>
                    {
                        
                        //alert(k3.ime + k3.prezime + k3.email +k3.brojKarte);
                        alert(k3.id);
                        const xd = new Osoba(k3.ime,k3.prezime,k3.mail,k3.brojKarte,k3.id);
                        x.sedista[k3.brojKarte].zauzmiSediste(xd);

                     

                    })));


                    });
            });
    });
});








// const x = new Sala(5,4,10);
// x.crtajSalu(document.body);