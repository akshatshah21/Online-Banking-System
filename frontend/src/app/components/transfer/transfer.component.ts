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
  beneficiaries = ["abc", "xyz", "pqr"];

  to: string;
  amount: number;
  pin: string;


  constructor() { }

  ngOnInit(): void {
  }

}
