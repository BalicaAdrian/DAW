import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-set-channel',
  templateUrl: './set-channel.component.html',
  styleUrls: ['./set-channel.component.css']
})
export class SetChannelComponent implements OnInit {
  @Input() public subscriptionId;
  setCForm: FormGroup;
  isLoading = false;
  selected: any;

  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private api: ApiService,
    private formBuilder: FormBuilder, private router: Router){

    }


   ngOnInit() {
    this.setForm();
  }

  onSubmit() {
    if (this.setCForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;
    console.log(this.setCForm.value);
    this.api.setChannel(this.setCForm.value).subscribe(x => {
      this.isLoading = false;
      this.modal.close('Yes');
    },
      error => {
        this.isLoading = false;
      });
  }

  get createFormData() { return this.setCForm.controls; }


  private setForm() {
    this.setCForm = this.formBuilder.group({
       ChannelId: [],
       SubscriptionId: [this.subscriptionId],
    });
  }

}
