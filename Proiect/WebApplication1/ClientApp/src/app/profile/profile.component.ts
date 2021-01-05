import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject, Observable } from 'rxjs';
import { CreateDetailsComponent } from '../create-details/create-details.component';
import { EditProfileComponent } from '../edit-profile/edit-profile.component';
import { updateDetails } from '../models/UpdateDetails';
import { User } from '../models/User';
import { UserProfile } from '../models/UserProfile';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  form: FormGroup;
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public userProfile: UserProfile;
 // editProfileForm: FormGroup;

  constructor(private http: HttpClient , private api: ApiService,public fb: FormBuilder, private modalService: NgbModal) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
}

  ngOnInit(): void {
    this.getProfile();
    // this.editProfileForm = this.fb.group({
    //   firstName: [null, Validators.required],
    //   lastName: [null, Validators.required],
    //   City: [null, Validators.required],
    //   Country: [null, Validators.required],
    // });
  }

  getProfile() {
    this.api.getProfileUser(this.currentUserSubject.getValue().id)
      .subscribe((data: UserProfile) => {
        console.log(data);
        this.userProfile = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  unSubscribe() {
    let obj = {
      id: this.currentUserSubject.getValue().id
    }
    this.api.unSubscribe(obj)
      .subscribe((data: UserProfile) => {
        this.getProfile();

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  editProfile() {
    const ref = this.modalService.open(EditProfileComponent, { centered: true });
    ref.componentInstance.selectedUser = this.currentUserSubject.value;

    ref.result.then((yes) => {
      console.log("Yes Click");

      this.getProfile();
    },
      (cancel) => {
        console.log("Cancel Click");

      })
   // this.api.editProfile(updateDetail);
  }

  createProfile() {
    const ref = this.modalService.open(CreateDetailsComponent, { centered: true });
    ref.componentInstance.selectedUser = this.currentUserSubject.value;

    ref.result.then((yes) => {
      console.log("Yes Click");

      this.getProfile();
    },
      (cancel) => {
        console.log("Cancel Click");

      })
   // this.api.editProfile(updateDetail);
  }
}
