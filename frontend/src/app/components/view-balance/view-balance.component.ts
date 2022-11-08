import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-view-balance',
  templateUrl: './view-balance.component.html',
  styleUrls: ['./view-balance.component.css']
})
export class ViewBalanceComponent implements OnInit {

  @Input() acc_number: string;

  constructor() { }

  ngOnInit(): void {
  }

}
