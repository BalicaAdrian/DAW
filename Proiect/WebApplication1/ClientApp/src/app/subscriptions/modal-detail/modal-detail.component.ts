import { Component, Input, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../../models/User';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-modal-detail',
  templateUrl: './modal-detail.component.html',
  styleUrls: ['./modal-detail.component.css']
})
export class ModalDetailComponent implements OnInit {
  @Input() public subscriptionId;
  channles: any;
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor( private api: ApiService, public modal: NgbActiveModal) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  ngOnInit(): void {
    this.getChannels(this.subscriptionId);
    console.log(this.subscriptionId);
  }

  getChannels(id: string){
    this.api.getSubscriptionChannels(id)
    .subscribe((data: any) => {
      console.log(data);
      this.channles = data;
    },
      (error: Error) => {
        console.log('err', error);

      });
  }

  subscribe(){
    let obj = {
      id: this.currentUserSubject.getValue().id,
      SubscriptionId: this.subscriptionId
    }
    this.api.setSubscription(obj)
    .subscribe((data: any) => {
      this.modal.close();
    },
      (error: Error) => {
        console.log('err', error);

      });
  }



}
