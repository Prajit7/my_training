import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from 'src/app/Components/dashboard/dashboard.component';
import { UserComponent } from 'src/app/Components/user/user.component';
import { RightsComponent } from 'src/app/Components/rights/rights.component';


@NgModule({
  declarations: [DashboardComponent,UserComponent,RightsComponent],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
