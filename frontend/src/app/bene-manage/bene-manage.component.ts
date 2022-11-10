import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import IBankAccount from '../interfaces/bank-account';
import { BankApiService } from '../services/bank-api.service';
import IBeneficiary from '../interfaces/beneficiary';

@Component({
  selector: 'app-bene-manage',
  templateUrl: './bene-manage.component.html',
  styleUrls: ['./bene-manage.component.css']
})
export class BeneManageComponent implements OnInit, OnDestroy {

  @Input() bankAccountNumber: string;
  beneficiaries: IBeneficiary[];
  sub: Subscription;

  constructor(private bankApiService: BankApiService, private router:Router) { }

  ngOnInit(): void {
    this.sub = this.bankApiService.getBeneficiariesOfAccount(this.bankAccountNumber).subscribe({
      next: beneficiaries => this.beneficiaries = beneficiaries,
      error: err => console.log(err)
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public isCollapsed = true;
  collapse() {
    this.isCollapsed = true;
  }

  toggle() {
    this.isCollapsed = !this.isCollapsed;
}
}