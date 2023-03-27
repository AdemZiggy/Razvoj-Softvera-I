import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
  studentid: any;
  maticnaKnjigaPodaci: any;
  odabranaKnjiga: any;
  AKPodaci: any;
  novaOvjera: any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.studentid = +params['id'];
      this.getMaticnaKnjigaPodaci();
      this.getAK();
    });

  }

  getMaticnaKnjigaPodaci() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaKnjiga/Get?id="+this.studentid, MojConfig.http_opcije()).subscribe(x=>{
      this.maticnaKnjigaPodaci = x;
    });
  }
  getAK(){
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.AKPodaci = x;
    });
  }
  upisiSemestar() {
    this.odabranaKnjiga={
      id:this.studentid
    }
  }

  spasiKnjigu() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/Add",this.odabranaKnjiga, MojConfig.http_opcije()).subscribe(x=>{
      this.odabranaKnjiga=null;
      this.getMaticnaKnjigaPodaci();
    });
  }

  ovjeri(s: any) {
    this.novaOvjera={
      id:s.id
    }
  }

  spasiOvjeru() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/Ovjera?id="+this.novaOvjera.id,this.novaOvjera, MojConfig.http_opcije()).subscribe(x=>{
      this.novaOvjera = null;
      this.getMaticnaKnjigaPodaci();
    });
  }
}
