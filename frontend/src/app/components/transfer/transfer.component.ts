import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { faMoneyBillTransfer } from '@fortawesome/free-solid-svg-icons';
import { Subscription } from 'rxjs';
import IBeneficiary from 'src/app/interfaces/beneficiary';
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

  to: string;
  amount: number;
  pin: string;


  constructor(private bankApiService: BankApiService) { }

  ngOnInit(): void {
    this.sub = this.bankApiService.getBeneficiariesOfAccount(this.bankAccountNumber).subscribe({
      next: beneficiaries => this.beneficiaries = beneficiaries,
      error: err => console.log(err)
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
