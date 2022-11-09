import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bene-new',
  templateUrl: './bene-new.component.html',
  styleUrls: ['./bene-new.component.css']
})
export class BeneNewComponent {
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