import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { updateDetails } from '../models/UpdateDetails';
import { User } from '../models/User';
import { UserProfile } from '../models/UserProfile';
import { ApiService } from '../services/api.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  selectedUser: updateDetails;
  editForm: FormGroup;
  isLoading = false;
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public userProfile: UserProfile;

  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private api: ApiService,
    private formBuilder: FormBuilder, private router: Router){

    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser'))),
    this.currentUser = this.currentUserSubject.asObservable();
    }

     getProfile() {
       this.api.getProfileUser(this.currentUserSubject.getValue().id)
        .subscribe((data: UserProfile) => {
          console.log("DATA E",data);
          this.userProfile = data;
        },
          (error: Error) => {
            console.log('err', error);

          });
    }
   ngOnInit() {
     this.getProfile();
      this.setForm();
    //console.log("RADA",this.userProfile.userDetails.id)
  }

  onSubmit() {
    if (this.editForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;
    console.log(this.editForm.value);
    var ovj = this.editForm.value;
    ovj = Object.assign(this.editForm.value, {id:this.userProfile.userDetails.id})
    this.api.editProfile(ovj).subscribe(x => {
      this.isLoading = false;
      this.modal.close('Yes');
    },
      error => {
        this.isLoading = false;
      });
  }

  get editFormData() { return this.editForm.controls; }

  private setForm() {

    this.editForm = this.formBuilder.group({
      //id: [this.userProfile.userDetails.id],
      UserId: [this.currentUserSubject.getValue().id],
      firstName: [this.selectedUser.firstName ],
      lastName: [this.selectedUser.lastName ],
      city: [{ value: this.selectedUser.city} ],
      country: [this.selectedUser.country]
    });
    console.log("AICII", this.selectedUser.city);
  }
}


