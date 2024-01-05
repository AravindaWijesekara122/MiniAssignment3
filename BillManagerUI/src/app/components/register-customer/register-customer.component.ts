import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/User';
import { KwAllowed } from 'src/app/models/enums/KwAllowed';
import { Role } from 'src/app/models/enums/Role';

@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.css']
})
export class RegisterCustomerComponent {

  userForm: FormGroup = new FormGroup({
    customerName: new FormControl('', Validators.required),
    customerAddress: new FormControl('', Validators.required),
    role: new FormControl(null, Validators.required),
    mobileNo: new FormControl('', Validators.required),
    alternativeNumber: new FormControl('', Validators.required),
    pincode: new FormControl('', Validators.required),
    kwAllowed: new FormControl(null, Validators.required),
    createdAt: new FormControl('', Validators.required),
    updatedAt: new FormControl('', Validators.required),
    electricityBills: new FormControl([], Validators.required)
  });

  // roles = Object.values(Role); // Use Object.values to get an array of enum values
  // kwAllowedValues = Object.values(KwAllowed);

  constructor(private fb: FormBuilder) {
    this.initForm();
  }

  getRolesKeys() {
    var roleNames = [];
    for (var log in Role) {
      if (isNaN(Number(log))) {
        roleNames.push(log);
      }
    }
    return roleNames;
  }
  getKwKeys() {
    var kwNames = [];
    for (var log in KwAllowed) {
      if (isNaN(Number(log))) {
        kwNames.push(log);
      }
    }
    return kwNames;
  }

  initForm() {
    console.log(this.getRolesKeys());
    console.log(this.getKwKeys());
    this.userForm = this.fb.group({
      customerName: '',
      customerAddress: '',
      role: Role,
      mobileNo: '',
      alternativeNumber: '',
      pincode: '',
      kwAllowed: KwAllowed,
      createdAt: [new Date()],
      updatedAt: [new Date()],
      electricityBills: []
    });

    // Show/hide Kw_Allowed based on the selected Role
    //let role = this.userForm.get('role').value;
    this.userForm.get('role')?.valueChanges.subscribe(role => {
      const kwAllowedControl = this.userForm.get('kwAllowed');
      if (role === this.getRolesKeys()[1]) {
        kwAllowedControl?.setValidators([Validators.required]);
      } else {
        kwAllowedControl?.clearValidators();
      }
      kwAllowedControl?.updateValueAndValidity();
    });
  }



  onSubmit() {
    if (this.userForm.valid) {
      const user: User = this.userForm.value;
      // Perform the registration logic (e.g., send data to the server)
      console.log('Registered User:', user);

      this.userForm.reset();
    }
  }
}
