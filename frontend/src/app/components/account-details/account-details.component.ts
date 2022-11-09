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
export class AccountDetailsComponent implements OnInit, OnDestroy {

  @Input() bankAccountNumber: string;
  bankAccount: IBankAccount | null = null;
  sub: Subscription;

  constructor(private bankApiService: BankApiService) { }

  ngOnInit(): void {
    this.sub = this.bankApiService.getBankAccount(this.bankAccountNumber).subscribe({
      next: bankAccount => this.bankAccount = bankAccount,
      error: err => console.log(err)
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
