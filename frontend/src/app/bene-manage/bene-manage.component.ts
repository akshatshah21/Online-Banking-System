import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import IBeneficiary from 'src/app/interfaces/beneficiary';
import { BankApiService } from 'src/app/services/bank-api.service';

@Component({
  selector: 'app-bene-manage',
  templateUrl: './bene-manage.component.html',
  styleUrls: ['./bene-manage.component.css']
})
export class BeneManageComponent implements OnInit, OnDestroy {

  @Input() bankAccountNumber: string;
  beneficiaries: IBeneficiary[];
  sub: Subscription;

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
