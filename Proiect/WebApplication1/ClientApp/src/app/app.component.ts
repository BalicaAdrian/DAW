import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './models/User';
import { AuthentificationService } from './services/authentification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  currentUser: User;
  constructor(
    private router: Router,
    private authenticationService: AuthentificationService
) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
}

logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
}
}
