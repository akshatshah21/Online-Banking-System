import { Component, OnInit } from '@angular/core';
import { faBuildingColumns } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  title: string = 'Lotak Bank';

  faBuildingColumns = faBuildingColumns;

  constructor() { }

  ngOnInit(): void {
  }

  logOut() {
    console.log("Log Out");
  }

}
