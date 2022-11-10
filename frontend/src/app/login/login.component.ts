import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import {Router } from '@angular/router';

@Component({
  selector:'app-login',
  templateUrl:'./login.component.html',
  styleUrls:['./login.component.css']
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
    this.router.navigate(['/home'])
  }
}