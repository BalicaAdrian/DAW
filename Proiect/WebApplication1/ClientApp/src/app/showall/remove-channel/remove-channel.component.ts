import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-remove-channel',
  templateUrl: './remove-channel.component.html',
  styleUrls: ['./remove-channel.component.css']
})
export class RemoveChannelComponent implements OnInit {
  @Input() public subscriptionId;
  removeCForm: FormGroup;
  isLoading = false;
  selected: any;

  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private api: ApiService,
    private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.setForm();

  }

  onSubmit() {
    if (this.removeCForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;
    console.log(this.removeCForm.value);
    this.api.removeChannel(this.removeCForm.value).subscribe(x => {
      this.isLoading = false;
      this.modal.close('Yes');
    },
      error => {
        this.isLoading = false;
      });
  }

  get createFormData() { return this.removeCForm.controls; }


  private setForm() {
    this.removeCForm = this.formBuilder.group({
       ChannelId: [],
       SubscriptionId: [this.subscriptionId],
    });
  }


}
