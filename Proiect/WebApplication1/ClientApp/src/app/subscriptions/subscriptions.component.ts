import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../services/api.service';
import { ModalDetailComponent } from './modal-detail/modal-detail.component';

@Component({
  selector: 'app-subscriptions',
  templateUrl: './subscriptions.component.html',
  styleUrls: ['./subscriptions.component.css']
})
export class SubscriptionsComponent implements OnInit {

  subscriptions: any[] = [];
  constructor(private api: ApiService , private modalService: NgbModal) { }



  ngOnInit() {
    this.api.getAllSubscriptions().subscribe((data: any[]) => {
      this.subscriptions = data;

    },
      (er: Error) => {
        console.log('err', er);
      });
  }

  openModal(id: string) {
    const ref = this.modalService.open(ModalDetailComponent, { centered: true });
    ref.componentInstance.subscriptionId = id;
    ref.result.then((yes) => {
      console.log("Yes Click");

      this.api.getAllSubscriptions().subscribe((data: any[]) => {
        this.subscriptions = data;

      },
        (er: Error) => {
          console.log('err', er);
        });
    },
      (cancel) => {
        console.log("Cancel Click");

      })
   // this.api.editProfile(updateDetail);
  }

}
