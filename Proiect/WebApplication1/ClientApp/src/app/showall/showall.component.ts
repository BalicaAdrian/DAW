import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../services/api.service';
import { RemoveChannelComponent } from './remove-channel/remove-channel.component';
import { SetChannelComponent } from './set-channel/set-channel.component';

@Component({
  selector: 'app-showall',
  templateUrl: './showall.component.html',
  styleUrls: ['./showall.component.css']
})
export class ShowallComponent implements OnInit {
  channels: any[] = [];
  subscriptions: any[] = [];
  constructor(private api: ApiService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.getAllChanells();
    this.getAllSubscriptions();
  }


  getAllChanells(){
    this.api.getAllChannels()
    .subscribe((data: any) => {
      console.log(data);
      this.channels = data;
    },
      (error: Error) => {
        console.log('err', error);

      });
  }

  getAllSubscriptions(){
    this.api.getAllSubscriptions()
    .subscribe((data: any) => {
      console.log(data);
      this.subscriptions = data;
    },
      (error: Error) => {
        console.log('err', error);

      });
  }

 deleteAbonament(id: string){
    this.api.deleteAbonament(id)
    .subscribe((data: any) => {
    this.getAllChanells();
    this.getAllSubscriptions();
    },
      (error: Error) => {
        console.log('err', error);

      });
  }

  deleteChannel(id: string){
    this.api.deleteChannel(id)
    .subscribe((data: any) => {
    this.getAllChanells();
    this.getAllSubscriptions();
    },
      (error: Error) => {
        console.log('err', error);

      });
  }

  setChannel(id : string) {
    const ref = this.modalService.open(SetChannelComponent, { centered: true });
    ref.componentInstance.subscriptionId = id;

    ref.result.then((yes) => {
      console.log("Yes Click");

      this.getAllChanells();
      this.getAllSubscriptions();
    },
      (cancel) => {
        console.log("Cancel Click");

      })
   // this.api.editProfile(updateDetail);
  }

  removeChannel(id: string) {
    const ref = this.modalService.open(RemoveChannelComponent, { centered: true });
    ref.componentInstance.subscriptionId = id;

    ref.result.then((yes) => {
      console.log("Yes Click");

      this.getAllChanells();
      this.getAllSubscriptions();
    },
      (cancel) => {
        console.log("Cancel Click");

      })
   // this.api.editProfile(updateDetail);
  }
}
