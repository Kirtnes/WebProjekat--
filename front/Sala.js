import { Osoba } from "./Osoba.js";
import { Sediste } from "./Sediste.js";

export class Sala{
    constructor(brojSale, brojRedova, brojMestaPoRedu){
        this.brojSale = brojSale;
        this.brojRedova = brojRedova;
        this.brojMestaPoRedu = brojMestaPoRedu;
        this.kontejner = null;
        this.sedista = [];
        this.maxSedista = this.brojRedova*this.brojMestaPoRedu;
    }


    crtajSalu(host){
        if(!host)
             throw new Error("Roditeljski element ne postoji!");
        this.kontejner = document.createElement("div");
        this.kontejner.classList.add("kontejner");
        host.appendChild(this.kontejner);   

        this.crtajFormu(this.kontejner);

    }


    crtajPodatke(host){

    }

    crtajFormu(host){


        
        const parentKontForma = document.createElement("div");
        parentKontForma.classList.add("parentKontForma");
        host.appendChild(parentKontForma);

        this.crtajSedista(parentKontForma);

        const kontForma = document.createElement("div");
        kontForma.classList.add("kontForma");
        parentKontForma.appendChild(kontForma);

        // var lab = document.createElement("label");
        // lab.classList.add("lab");
        // lab.innerHTML = "podaci o korisniku";
        // kontForma.appendChild(lab);

        var lab = document.createElement("h4");
        lab.classList.add("lab");
        lab.innerHTML = "Ime:";
        kontForma.appendChild(lab);

        let inp = document.createElement("input");
        inp.classList.add("inpIme");
        inp.classList.add("input")
        kontForma.appendChild(inp);

        lab = document.createElement("h4");
        lab.classList.add("lab");
        lab.innerHTML = "Prezime:";
        kontForma.appendChild(lab);

        inp = document.createElement("input");
        inp.classList.add("inpPrezime");
        inp.classList.add("input")
        kontForma.appendChild(inp);

        lab = document.createElement("h4");
        lab.classList.add("lab");
        lab.innerHTML = "Email:";
        kontForma.appendChild(lab);

        inp = document.createElement("input");
        inp.classList.add("inpEmail");
        inp.classList.add("input")
        kontForma.appendChild(inp);

        lab = document.createElement("h4");
        lab.classList.add("lab");
        lab.innerHTML = "Broj karte:";
        kontForma.appendChild(lab);

        inp = document.createElement("input");
        inp.classList.add("inpBrojKarte");
        inp.classList.add("input")  
        kontForma.appendChild(inp);


        const zauzmiMesto = document.createElement("button");
        zauzmiMesto.innerHTML = "Zauzmi mesto";
        zauzmiMesto.classList.add("zauzmiMesto");
        kontForma.appendChild(zauzmiMesto);

        zauzmiMesto.onclick=(ev)=>{

            const ime = this.kontejner.querySelector(".inpIme").value;
            const prezime = this.kontejner.querySelector(".inpPrezime").value;
            const email = this.kontejner.querySelector(".inpEmail").value;
            const brojKarte = this.kontejner.querySelector(".inpBrojKarte").value;

            const osoba = new Osoba(ime,prezime,email,brojKarte);
            console.log(osoba);

            if(brojKarte>this.maxSedista){
                alert("Sediste ne postoji!");
                return;
            }
            if(ime==""){
                alert("Morate uneti ime!");
                return;
            }
            if(prezime==""){
                alert("Morate uneti prezime!");
                return;
            }

            //if(this.sedista[brojKarte])
            if(this.sedista[brojKarte].slobodno==true){
                this.sedista[brojKarte].upisiUBazu(osoba);
                this.sedista[brojKarte].zauzmiSediste(osoba);
            }
            else if(this.sedista[brojKarte].slobodno==false)
            alert("To mesto je vec zauzeto! Ako zelite da ga izmenite, kliknite na opciju azuriraj.");
        }


        const oslobodiMesto = document.createElement("button");
        oslobodiMesto.innerHTML="Oslobodi mesto";
        oslobodiMesto.classList.add("oslobodiMesto");
        kontForma.appendChild(oslobodiMesto);

        oslobodiMesto.onclick=(ev)=>{

            const brojKarte = this.kontejner.querySelector(".inpBrojKarte").value;
            
            if(brojKarte>this.maxSedista){
                alert("sediste ne postoji!");
                return;
            }



            if(this.sedista[brojKarte].slobodno==false){
                this.sedista[brojKarte].oslobodiSediste();
            }
            else if(this.sedista[brojKarte].slobodno==true)
            alert("To mesto je vec slobodno!");

            

        }

        const izmeniMesto = document.createElement("button");
        izmeniMesto.innerHTML="Izmeni mesto";
        izmeniMesto.classList.add("izmeniMesto");
        kontForma.appendChild(izmeniMesto);

        izmeniMesto.onclick=(ev)=>{

            const ime = this.kontejner.querySelector(".inpIme").value;
            const prezime = this.kontejner.querySelector(".inpPrezime").value;
            const email = this.kontejner.querySelector(".inpEmail").value;
            const brojKarte = this.kontejner.querySelector(".inpBrojKarte").value;
        
            const osoba = new Osoba(ime,prezime,email,brojKarte);
            
            if(this.sedista[brojKarte].slobodno==false){
                this.sedista[brojKarte].izmeniSediste(osoba);
            }
            else{
                
                alert("Ovo mesto je prazno!");
            }

        }





        //this.crtajSedista(parentKontForma);


    }
    dodajSediste(S){
        this.sedista.push(S);
    }
    
    
    crtajSedista(host){

        const ekran = document.createElement("div");
        ekran.classList.add("ekran");
        host.appendChild(ekran);
        ekran.innerHTML="*ekran"


        const kontSedista = document.createElement("div");
        kontSedista.classList.add("kontSedista");
        host.appendChild(kontSedista);
    
        let lab = document.createElement("h4");
        lab.classList.add("lab");
        lab.innerHTML = "*sedista";
        kontSedista.appendChild(lab);
    
        let red;
        let sediste;    

        for(let i = 0; i < this.brojRedova; i++){
    
        lab = document.createElement("label");
        lab.className = "nivo";
        lab.innerHTML = (i+1) + ". red"; 
        lab.classList.add("redovi");
        kontSedista.appendChild(lab);
    
    
        red = document.createElement("div");
        red.className = "red";
        kontSedista.appendChild(red);
    


        const osoba = new Osoba();
        for(let j = 0; j<this.brojMestaPoRedu; j++){
    
            sediste = new Sediste(osoba);
            this.dodajSediste(sediste);
            sediste.crtajSediste(red);
    
    
    
         }
        }

       
    }

} 

