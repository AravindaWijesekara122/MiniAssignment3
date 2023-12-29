// app-routing.module.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RegisterCustomerComponent } from './components/register-customer/register-customer.component';
import { AddBillComponent } from './components/add-bill/add-bill.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'register-customer', component: RegisterCustomerComponent },
  { path: 'add-bill', component: AddBillComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
