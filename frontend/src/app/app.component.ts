import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import IBankAccount from './interfaces/bank-account';
import IHistoricalTransaction from './interfaces/historical-transaction';
import ITransaction from './interfaces/transaction';
import { BankApiService } from './services/bank-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  @Input() bankAccountNumber: string = "19cd1fc4-d235-4647-b5bb-aeae54df022a";
  accountDetailsSub: Subscription;
  bankAccount: IBankAccount
  transactions: IHistoricalTransaction[];
  sub: Subscription;

  constructor(private bankApiService: BankApiService) { }

  refreshAccountDetails(): void {
    this.accountDetailsSub = this.bankApiService.getBankAccount(this.bankAccountNumber).subscribe({
      next: bankAccount => this.bankAccount = bankAccount,
      error: err => console.log(err)
    });
  }

  refreshTransactions(): void {
    this.sub = this.bankApiService.getTransactionsOfAccount(this.bankAccountNumber).subscribe({
      next: transactions => this.transactions = transactions,
      error: err => console.log(err)
    });
  }

  ngOnInit(): void {
    this.refreshAccountDetails();
    this.refreshTransactions();
  }

  ngOnDestroy(): void {
    this.accountDetailsSub.unsubscribe();
  }

}
