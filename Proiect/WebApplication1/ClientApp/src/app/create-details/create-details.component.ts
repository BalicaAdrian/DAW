import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { updateDetails } from '../models/UpdateDetails';
import { User } from '../models/User';
import { UserProfile } from '../models/UserProfile';
import { ApiService } from '../services/api.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-create-details',
  templateUrl: './create-details.component.html',
  styleUrls: ['./create-details.component.css']
})
export class CreateDetailsComponent implements OnInit {

  selectedUser: updateDetails;
  createForm: FormGroup;
  isLoading = false;
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public userProfile: UserProfile;

  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private api: ApiService,
    private formBuilder: FormBuilder, private router: Router){

    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser'))),
    this.currentUser = this.currentUserSubject.asObservable();
    }


   ngOnInit() {
    this.setForm();
  }

  onSubmit() {
    if (this.createForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;
    console.log(this.createForm.value);
    this.api.createProfile(this.createForm.value).subscribe(x => {
      this.isLoading = false;
      this.modal.close('Yes');
    },
      error => {
        this.isLoading = false;
      });
  }

  get createFormData() { return this.createForm.controls; }

  private setForm() {

    this.createForm = this.formBuilder.group({
      UserId: [this.currentUserSubject.getValue().id],
      firstName: [this.selectedUser.firstName ],
      lastName: [this.selectedUser.lastName ],
      city: [{ value: this.selectedUser.city} ],
      country: [this.selectedUser.country]
    });
  }
}
