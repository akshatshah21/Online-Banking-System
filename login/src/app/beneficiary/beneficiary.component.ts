import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-beneficiary',
  templateUrl: './beneficiary.component.html',
  styleUrls: ['./beneficiary.component.css']
})
export class BeneficiaryComponent{
  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  collapse() {
    this.isCollapsed = true;
  }

  toggle() {
    this.isCollapsed = !this.isCollapsed;
}
}
