import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { HomComponent } from './hom/hom.component';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BeneficiaryComponent } from './beneficiary/beneficiary.component';
import { HelComponent } from './hel/hel.component';
import { BeneNewComponent } from './bene-new/bene-new.component';
import { BeneManageComponent } from './bene-manage/bene-manage.component';
@NgModule({
  declarations: [
    AppComponent,
    HomComponent,
    LoginComponent,
    BeneficiaryComponent,
    HelComponent,
    BeneNewComponent,
    BeneManageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }