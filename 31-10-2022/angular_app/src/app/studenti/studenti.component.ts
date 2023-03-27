import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  odabraniStudent: any;
  opstinaPodaci: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.getOpstine();
  }

  filtriraj() {
    if(this.studentPodaci==null)
      return [];
    return this.studentPodaci.filter((s:any)=>((s.ime+" "+s.prezime).startsWith(this.ime_prezime)||(s.prezime+" "+s.ime).startsWith(this.ime_prezime)||!this.ime_prezime)&&(s.opstina_rodjenja.description.startsWith(this.opstina)||!this.opstina));
  }
  getOpstine(){
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinaPodaci = x;
    });
  }
  dodajStudenta() {
    this.odabraniStudent={
      id:0,
      ime:this.ime_prezime,
      opstina_rodjenja_id:2
    };
  }

  spremiStudenta() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Student/AddEdit",this.odabraniStudent, MojConfig.http_opcije()).subscribe(x=>{
      this.odabraniStudent = null;
      this.testirajWebApi();
    });
  }

  otvoriMaticnu(s: any) {
    this.router.navigate(['student-maticnaknjiga',s.id]);
  }
}
