import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  loginForm: FormGroup | any;
  title = 'material-login';
  constructor(
    private router:Router
  ) {
    this.loginForm = new FormGroup({
      id: new FormControl('',[Validators.minLength(8),Validators.required,Validators.pattern('^([0-9])*$')]),
      password: new FormControl('', [Validators.required,Validators.pattern(
        '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,32}$'
      )])
    });
   }
  ngOnInit(): void {
  }
  onSubmit(){
    if(!this.loginForm.valid){
      return;
    }
    // localStorage.setItem('user',this.loginForm.value)
    this.router.navigate(['/home'])
  }
}