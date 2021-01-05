import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Channel } from '../models/Channel';
import { Subscription } from '../models/Subscription';
import { updateDetails } from '../models/UpdateDetails';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    'Content-Type': 'application/json'
  });
  baseUrl = 'https://localhost:44383/api';

  addChannel(channel: Channel) {
    return this.http.post(this.baseUrl + '/Channel/create', channel, { headers: this.header });
  }

  addSubscription(subscription: Subscription) {
    return this.http.post(this.baseUrl + '/Subscription/create', {
      'id' : subscription.id,
    	'name' : subscription.name,
	    'period' : subscription.period,
	    'price' : subscription.price,
    }, { headers: this.header });
  }

  getProfileUser(id: string){
    return this.http.get(this.baseUrl + '/Users/' + id.toString(), { headers: this.header });
  }

  getSubscriptionChannels(id: string){
    return this.http.get(this.baseUrl + '/Subscription/' + id.toString() + '/channels', { headers: this.header });
  }

  getAllSubscriptions(){
    return this.http.get(this.baseUrl + '/Subscription/all', { headers: this.header });
  }

  getAllChannels(){
    return this.http.get(this.baseUrl + '/Channel/all', { headers: this.header });

  }

  editProfile(profile: any) {

    return this.http.post(this.baseUrl + '/UserDetails/update', profile, { headers: this.header });
  }

  createProfile(create : any){
    return this.http.post(this.baseUrl + '/UserDetails/create', create, { headers: this.header });

  }

  unSubscribe(unset : any){
    return this.http.post(this.baseUrl + '/Users/unset-subscription', unset, { headers: this.header });

  }

  setChannel(add:any){
    return this.http.post(this.baseUrl + '/Subscription/add-channel', add, { headers: this.header });

  }

  removeChannel(remove:any){
    return this.http.post(this.baseUrl + '/Subscription/remove-channel', remove, { headers: this.header });

  }
  setSubscription(create: any){
    return this.http.post(this.baseUrl + '/Users/set-subscription', create, { headers: this.header });
  }

  deleteAbonament(id: string){
    return this.http.delete(this.baseUrl + '/Subscription/' + id.toString(), { headers: this.header });
  }


  deleteChannel(id: string){
    return this.http.delete(this.baseUrl + '/Channel/' + id.toString(), { headers: this.header });
  }

}
