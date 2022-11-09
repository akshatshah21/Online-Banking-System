import { Component, OnInit } from '@angular/core';
import { faMoneyBillTransfer } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})
export class TransferComponent implements OnInit {

  faMoneyBillTransfer = faMoneyBillTransfer;
  // todo beneficiaries not working in html
  beneficiaries: string[] = ["abc", "xyz", "pqr"];

  to: string = this.beneficiaries[0];
  amount: number = 0;
  pin: string = "";


  constructor() { }

  ngOnInit(): void {
  }

}
