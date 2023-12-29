import { BillStatus } from "./enums/billStatus";

export interface Customer {
  customerId: number;
  customerName: string;
  pincode: string;
  latestBillAmount: number;
  billStatus: BillStatus
  // ... other properties
}