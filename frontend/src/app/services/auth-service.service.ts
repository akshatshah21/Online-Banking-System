import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

interface IJwt {
  token: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  baseUrl: string = "https://localhost:7241/api/auth";

  constructor(private http: HttpClient) { }

  login(customerId: string, password: string) {
    return this.http.post<IJwt>(`${this.baseUrl}/login`, {
      id: customerId,
      password: password
    });
  }
}
