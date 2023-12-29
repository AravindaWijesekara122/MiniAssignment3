// customer.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7088/api'; // Replace with your backend API URL

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.apiUrl}/all-users`);
  }

  registerUser(user: User): Observable<any> {
    const registrationUrl = `${this.apiUrl}/register`; // Replace with your registration endpoint
    return this.http.post(registrationUrl, user);
  }

}
