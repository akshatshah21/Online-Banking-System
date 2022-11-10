import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

interface IJwt {
  token: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = "https://localhost:7241/api/auth";

  constructor(private http: HttpClient) { }

  login(customerId: string, password: string): void {
    this.http.post<IJwt>(`${this.baseUrl}/login`, {
      id: customerId,
      password: password
    }).subscribe({
      next: jwt => this.setJwt(jwt.token),
      error: err => console.log(err)
    });
  }

  private setJwt(token: string): void {
    localStorage.setItem("jwt", token);
  }

  logout() {
    localStorage.removeItem("token");
  }

  isLoggedIn() {
    return localStorage.getItem("token") != null;
  }


}
