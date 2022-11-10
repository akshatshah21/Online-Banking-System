import { Component, Input, OnDestroy, OnInit, Output, EventEmitter } from '@angular/core';
import { faMoneyBillTransfer } from '@fortawesome/free-solid-svg-icons';
import { Subscription } from 'rxjs';
import IBeneficiary from 'src/app/interfaces/beneficiary';
import IInitiatedTransaction from 'src/app/interfaces/initiated-transaction';
import { BankApiService } from 'src/app/services/bank-api.service';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})
export class TransferComponent implements OnInit, OnDestroy {

  faMoneyBillTransfer = faMoneyBillTransfer;
  beneficiaries: IBeneficiary[];
  @Input() bankAccountNumber: string;
  sub: Subscription;
  transactionSub: Subscription;

  to: string;
  amount: number;
  transactionPin: string;
  comment: string = "";
  error: string | undefined;

  @Output() updateAccountDetails: EventEmitter<void> = new EventEmitter<void>();
  @Output() updateTransactions: EventEmitter<void> = new EventEmitter<void>();

  constructor(private bankApiService: BankApiService) { }

  ngOnInit(): void {
    this.sub = this.bankApiService.getBeneficiariesOfAccount(this.bankAccountNumber).subscribe({
      next: beneficiaries => this.beneficiaries = beneficiaries,
      error: err => console.log(err)
    });
  }

  onTransferSubmit(): void {
    let transaction: IInitiatedTransaction = {
      fromAccountNumber: this.bankAccountNumber,
      toAccountNumber: this.to,
      amount: this.amount,
      comment: this.comment,
      transactionPin: this.transactionPin
    }

    this.transactionSub = this.bankApiService.initiateTransaction(transaction).subscribe({
      next: transaction => {
        console.log(transaction);
        // TODO: Show successful txn in popup
        this.updateAccountDetails.emit();
        this.updateTransactions.emit();
      },
      error: err => {
        console.log(err);
        this.error = err.error;
      }
    });

    this.to = "";
    this.amount = 0;
    this.transactionPin = "";
    this.comment = "";
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
    this.transactionSub.unsubscribe();
  }
}
