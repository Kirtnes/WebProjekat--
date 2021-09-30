import { Sala } from "./Sala.js";
import { Osoba } from "./Osoba.js";
export class Sediste{
    constructor(osoba){
        this.osoba = osoba;
        this.slobodno = true;
        this.sedisteKontejner=null;
    }

    crtajSediste(host){
        this.sedisteKontejner = document.createElement("div");
        // this.sedisteKontejner.addEventListener("click", () =>{
        // confirm(`Mesto broj ${this.vratiBrojKarte()} je zauzeto od strane osobe: ${this.vratiIme()} ${this.vratiPrezime()}`);

        // });
        this.sedisteKontejner.classList.add("sediste");
        this.sedisteKontejner.innerHTML="Slobodno";
        this.sedisteKontejner.style.backgroundColor="rgb(153, 237, 195)";
        host.appendChild(this.sedisteKontejner);
        
    }

    // this.sedisteKontejner.addEventListener("click", () =>{
    //     confirm(`Mesto broj ${this.vratiBrojKarte()} je zauzeto od strane osobe: ${this.vratiIme()} ${this.vratiPrezime()}`);

    //     });

    

    upisiUBazu(osoba){
        this.osoba=osoba;
        console.log(this.vratiBrojKarte());
            console.log(this.osoba);
            fetch("https://localhost:5001/Sala/UpisiOsobu/"+this.vratiBrojKarte()+67,
            {
                method:"POST",
                headers:{
                        "Content-type":"application/json"        
                        },
                body: JSON.stringify(
                    {
                            ime : this.vratiIme(),
                            prezime: this.vratiPrezime(),
                            email: this.vratiEmail(),
                            brojKarte: this.vratiBrojKarte(),
                            sediste : this.vratiBrojKarte()+67
                    }
                )
            });//.then(el=> osoba.id = el.status);
        
    }


    zauzmiSediste(osoba){
        this.osoba=osoba;



        this.slobodno=false;
        this.sedisteKontejner.style.borderColor = "rgb(170, 72, 72)"; 
        this.sedisteKontejner.style.backgroundColor="rgb(188, 84, 75)";
        this.sedisteKontejner.innerHTML = "Zauzeto";  
        let x=1;
        



        this.sedisteKontejner.addEventListener("click", () =>{
            
            if(x==1 && this.slobodno==false){
            this.sedisteKontejner.innerHTML="Mesto broj:" + "<br />" +  this.vratiBrojKarte() + "<br />" + "Ime:" + "<br />" + this.vratiIme() + "<br />" + "Prezime:" + "<br />" + this.vratiPrezime();
            this.sedisteKontejner.style.borderColor = "rgb(170, 72, 72)"; 
            x=0;
            }
            else if(x==0 & this.slobodno==false){
            this.sedisteKontejner.innerHTML="Zauzeto";
            this.sedisteKontejner.style.borderColor = "rgb(170, 72, 72)"; 
            x=1;
            }
            

                }
            
            );
           

    }

    oslobodiSediste(osoba){
        this.osoba.ime = undefined;
        this.osoba.prezime = undefined;
        this.slobodno=true;
        this.sedisteKontejner.innerHTML = "Slobodno"; 
        this.sedisteKontejner.style.borderColor="rgb(185, 245, 157)";
        this.sedisteKontejner.style.backgroundColor="rgb(153, 237, 195)";

        fetch("https://localhost:5001/Sala/IzbrisiOsobu?id=" + this.osoba.id,
             {
                 method: "DELETE"
             });
    }

    izmeniSediste(osoba){



        osoba.id=this.vratiID();
        this.osoba=osoba;

        console.log(this.vratiID());
        this.slobodno=false;
        this.sedisteKontejner.innerHTML="Mesto broj:" + "<br />" +  this.vratiBrojKarte() + "<br />" + "Ime:" + "<br />" + this.vratiIme() + "<br />" + "Prezime:" + "<br />" + this.vratiPrezime();


        
        fetch("https://localhost:5001/Sala/IzmeniOsobu",
                {
                    method: "PUT",
                    headers: {
                        "Content-type": "application/json"
                    },
                    body: JSON.stringify(
                        {
                            id: this.vratiID(),
                            ime: this.vratiIme(),
                            prezime: this.vratiPrezime(),
                            email: this.vratiEmail(),
                            brojKarte:this.vratiBrojKarte()           
                         })
                    });


    }

    vratiID(){
        return this.osoba.id;
    }

    vratiIme(){
        return this.osoba.ime;
    }
    vratiPrezime(){
        return this.osoba.prezime;
    }
    vratiBrojKarte(){
        return this.osoba.brojKarte;
    }
    vratiEmail(){
        return this.osoba.email;
    }

    izmeniPodatke(ime, prezime, email){
        this.ime=ime;
        this.prezime=prezime;
        this.email=email;

        this.sedisteKontejner.innerHTML="Mesto broj:" + "<br />" +  this.vratiBrojKarte() + "<br />" + "Ime:" + "<br />" + this.vratiIme() + "<br />" + "Prezime:" + "<br />" + this.vratiPrezime();
        console.log("Mesto broj:" + "<br />" +  this.vratiBrojKarte() + "<br />" + "Ime:" + "<br />" + this.vratiIme() + "<br />" + "Prezime:" + "<br />" + this.vratiPrezime());
    }
}