import { KwAllowed } from "./enums/KwAllowed";
import { Role } from "./enums/Role";

export interface User {
    customerName: string;
    customerAddress: string;
    role: Role;
    mobileNo: string;
    alternativeNumber: string;
    pincode: string;
    kwAllowed?: KwAllowed; // Only show if Role is Customer
    createdAt: Date;
    updatedAt: Date;
    electricityBills: [];
}

