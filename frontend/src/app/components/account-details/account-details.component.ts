import { Injectable, Input, OnDestroy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import IBankAccount from 'src/app/interfaces/bank-account';
import { BankApiService } from 'src/app/services/bank-api.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent {
  @Input() bankAccount: IBankAccount;
}
