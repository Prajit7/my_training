import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { ConentComponent } from './Components/conent/conent.component';
import { CalcComponent } from './Components/calc/calc.component';
import { MasterComponent } from './Components/master/master.component';
import { EmpDetailComponent } from './Components/emp-detail/emp-detail.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ConentComponent,
    CalcComponent,
    MasterComponent,
    EmpDetailComponent,


  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
