import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hel',
  templateUrl: './hel.component.html',
  styleUrls: ['./hel.component.css']
})
export class HelComponent implements OnInit {

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
