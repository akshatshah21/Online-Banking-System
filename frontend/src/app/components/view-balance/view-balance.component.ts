import { Component, OnInit, Input } from '@angular/core';
import { faIndianRupeeSign } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-view-balance',
  templateUrl: './view-balance.component.html',
  styleUrls: ['./view-balance.component.css']
})
export class ViewBalanceComponent implements OnInit {

  @Input() acc_number: string;
  faIndianRupeeSign = faIndianRupeeSign;

  constructor() { }

  ngOnInit(): void {
  }

}
