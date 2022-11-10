import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomComponent } from './hom/hom.component';
import { LoginComponent } from './login/login.component';
import { HelComponent } from './hel/hel.component';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { BeneManageComponent } from './bene-manage/bene-manage.component';
import { BeneNewComponent } from './bene-new/bene-new.component';

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
    path:'bene-new',
    component:BeneNewComponent
  },
  {
    path:'bene-manage',
    component:BeneManageComponent
  },
  {
    path:'',
    component:LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
