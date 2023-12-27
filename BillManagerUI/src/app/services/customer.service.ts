// customer.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:7088/api'; // Replace with your backend API URL

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.apiUrl}/all-users`);
  }
}
