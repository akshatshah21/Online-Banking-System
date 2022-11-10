import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bene-new',
  templateUrl: './bene-new.component.html',
  styleUrls: ['./bene-new.component.css']
})
export class BeneNewComponent implements OnInit {

  acc_number: string;
  nickname: string;
  re_acc_number: string;

  constructor() { }

  ngOnInit(): void {
  }

}
