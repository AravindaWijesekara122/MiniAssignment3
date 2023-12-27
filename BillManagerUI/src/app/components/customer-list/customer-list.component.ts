// customer-list.component.ts

import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';


@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  constructor(private router: Router) {}

  httpClient = inject(HttpClient)
  customers: any[] = [];
  filteredCustomers: any[] = [];
  searchText: string = '';
  sortKey: string = '';

  //constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadCustomers();
  }

  // loadCustomers() {
  //   this.customerService.getCustomers().subscribe((data : any) => {
  //     console.log(data);
  //     this.customers = data;
  //     this.filteredCustomers = this.customers;
  //   });
  // }

  loadCustomers(){
    let url = 'https://localhost:7088/api/all-users';
    console.log("Test");
    this.httpClient.get(url).subscribe((data: any) => {
      
      console.log(data);
      this.customers = data;
      this.filteredCustomers = this.customers;
    });

  }

  sort(key: string) {
    this.sortKey = key;
    this.filteredCustomers = this.sortCustomers(this.customers, key);
  }

  sortCustomers(customers: any[], key: string): any[] {
    return customers.sort((a, b) => {
      return a[key] > b[key] ? 1 : -1;
    });
  }
}
