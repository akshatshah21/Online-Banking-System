import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bene-manage',
  templateUrl: './bene-manage.component.html',
  styleUrls: ['./bene-manage.component.css']
})
export class BeneManageComponent {

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