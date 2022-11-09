import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ButtonComponent } from './components/button/button.component';
import { AccountDetailsComponent } from './components/account-details/account-details.component';
import { ViewBalanceComponent } from './components/view-balance/view-balance.component';
import { TransferComponent } from './components/transfer/transfer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AddBeneficiaryComponent } from './components/add-beneficiary/add-beneficiary.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ButtonComponent,
    AccountDetailsComponent,
    ViewBalanceComponent,
    TransferComponent,
    AddBeneficiaryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
