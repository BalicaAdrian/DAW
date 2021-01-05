import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  options = ['Channel', 'Subscription'];
  selectedOption = 'Subscription';
  currentFormRef: any;
  addChannelForm: FormGroup;
  addSubscriptionForm: FormGroup;
  success: boolean;

  constructor(public fb: FormBuilder, private api: ApiService) { }


  ngOnInit() {

    this.addChannelForm = this.fb.group({
      name: [null, Validators.required],
      tip: [null, Validators.required],
      origine: [null, Validators.required],
    });
    this.addSubscriptionForm = this.fb.group({
      name: [null, Validators.required],
      price: [null, Validators.required],
      period: [null, Validators.required],

    });

    this.currentFormRef = this.addChannelForm;

  }

  radioChange(event: any) {
    this.selectedOption = event.target.value;
    this.currentFormRef = this['add' + this.selectedOption + 'Form'];
  }

  add() {
    this.api['add' + this.selectedOption](this.currentFormRef.value).subscribe(() => {

      this.currentFormRef.reset();
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
      (error: Error) => {
        console.log(error);
        this.currentFormRef.reset();
        this.success = false;
        setTimeout(() => {
          this.success = null;
        }, 3000);
      });

  }
}
