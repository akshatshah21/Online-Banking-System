import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-beneficiary',
  templateUrl: './add-beneficiary.component.html',
  styleUrls: ['./add-beneficiary.component.css']
})
export class AddBeneficiaryComponent implements OnInit {

  acc_number: string;
  nickname: string;
  re_acc_number: string;

  constructor() { }

  ngOnInit(): void {
  }

}
