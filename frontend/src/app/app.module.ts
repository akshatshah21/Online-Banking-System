import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ButtonComponent } from './components/button/button.component';
import { AccountDetailsComponent } from './components/account-details/account-details.component';
import { TransferComponent } from './components/transfer/transfer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BeneficiaryListComponent } from './components/beneficiary-list/beneficiary-list.component';
import { TransactionsListComponent } from './components/transactions-list/transactions-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ButtonComponent,
    AccountDetailsComponent,
    TransferComponent,
    BeneficiaryListComponent,
    TransactionsListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
