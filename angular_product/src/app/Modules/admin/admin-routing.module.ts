import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from 'src/app/Components/dashboard/dashboard.component';
import { RightsComponent } from 'src/app/Components/rights/rights.component';
import { UserComponent } from 'src/app/Components/user/user.component';

const routes: Routes = [
  {
    path:"admin",
    children:[
      {path:"Dashboard",component:DashboardComponent},
      {path:"User",component:UserComponent},
      {path:"Rights",component:RightsComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
