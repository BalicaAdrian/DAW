import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AlertComponent } from './alert/alert.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { appRoutingModule } from './app.routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AddComponent } from './add/add.component';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { CreateDetailsComponent } from './create-details/create-details.component';
import { SubscriptionsComponent } from './subscriptions/subscriptions.component';
import { ModalDetailComponent } from './subscriptions/modal-detail/modal-detail.component';
import { ShowallComponent } from './showall/showall.component';
import { SetChannelComponent } from './showall/set-channel/set-channel.component';
import { RemoveChannelComponent } from './showall/remove-channel/remove-channel.component';


@NgModule({
  imports: [
      BrowserModule,
      ReactiveFormsModule,
      HttpClientModule,
      CommonModule,
      appRoutingModule,
      NgbModule,



  ],
  declarations: [
      AppComponent,
      AddComponent,
      HomeComponent,
      LoginComponent,
      RegisterComponent,
      ProfileComponent,
      AlertComponent,
      EditProfileComponent,
      CreateDetailsComponent,
      SubscriptionsComponent,
      ModalDetailComponent,
      ShowallComponent,
      SetChannelComponent,
      RemoveChannelComponent
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { };
