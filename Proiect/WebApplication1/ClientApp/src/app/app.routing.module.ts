import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './add/add.component';
import { AuthGuard } from './helpers/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { ShowallComponent } from './showall/showall.component';
import { SubscriptionsComponent } from './subscriptions/subscriptions.component';


const routes: Routes = [
    { path: 'users', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'add', component: AddComponent, canActivate: [AuthGuard]},
    { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
    { path: 'subscriptions', component: SubscriptionsComponent, canActivate: [AuthGuard]},
    { path: 'showall', component: ShowallComponent, canActivate: [AuthGuard]},
    // otherwise redirect to home
    { path: '**', redirectTo: 'subscriptions' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
