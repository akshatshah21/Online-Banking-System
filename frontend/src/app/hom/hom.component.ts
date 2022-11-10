import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import IBankAccount from '../interfaces/bank-account';
import { BankApiService } from '../services/bank-api.service';

@Component({
  selector: 'app-hom',
  templateUrl: './hom.component.html',
  styleUrls: ['./hom.component.css']
})
export class HomComponent implements OnInit, OnDestroy {

  @Input() bankAccountNumber: string = "19cd1fc4-d235-4647-b5bb-aeae54df022a";
  accountDetailsSub: Subscription;
  bankAccount: IBankAccount

  constructor(private bankApiService: BankApiService) { }

  refreshAccountDetails(): void {
    console.log("update")

    this.accountDetailsSub = this.bankApiService.getBankAccount(this.bankAccountNumber).subscribe({
      next: bankAccount => this.bankAccount = bankAccount,
      error: err => console.log(err)
    });
  }

  ngOnInit(): void {
    this.refreshAccountDetails();
  }

  ngOnDestroy(): void {
    this.accountDetailsSub.unsubscribe();
  }

}
