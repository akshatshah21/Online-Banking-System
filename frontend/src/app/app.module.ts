import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ButtonComponent } from './components/button/button.component';
import { AccountDetailsComponent } from './components/account-details/account-details.component';
import { TransferComponent } from './components/transfer/transfer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BeneficiaryListComponent } from './components/beneficiary-list/beneficiary-list.component';
import { LoginComponent } from './login/login.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from "@angular/material/form-field";
import { HomComponent } from './hom/hom.component';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { HelComponent } from './hel/hel.component';
import { BeneNewComponent } from './bene-new/bene-new.component';
import { BeneManageComponent } from './bene-manage/bene-manage.component';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ButtonComponent,
    AccountDetailsComponent,
    TransferComponent,
    BeneficiaryListComponent,
    LoginComponent,
    HomComponent,
    LoginComponent,
    BeneficiaryComponent,
    BeneNewComponent,
    BeneManageComponent,
    HelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
