import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import IHistoricalTransaction from 'src/app/interfaces/historical-transaction';
import ITransaction from 'src/app/interfaces/transaction';
import { BankApiService } from 'src/app/services/bank-api.service';

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.css']
})
export class TransactionsListComponent implements OnInit, OnDestroy {

  @Input() bankAccountNumber: string;
  @Input() transactions: IHistoricalTransaction[];
  sub: Subscription;

  constructor(private bankApiService: BankApiService) { }

  ngOnInit(): void {
    this.sub = this.bankApiService.getTransactionsOfAccount(this.bankAccountNumber).subscribe({
      next: transactions => this.transactions = transactions,
      error: err => console.log(err)
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
