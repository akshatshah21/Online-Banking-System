import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomComponent } from './hom/hom.component';
import { LoginComponent } from './login/login.component';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { HelComponent } from './hel/hel.component';

const routes: Routes = [
  {
    path:'home',
    component:HomComponent
  },
  {
    path:'beneficiary',
    component:BeneficiaryComponent
  },
  {
    path:'help',
    component:HelComponent
  },
  {
    path:'',
    component:LoginComponent
  }
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }