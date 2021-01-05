import { Component } from '@angular/core';
import { User } from '../models/User';
import { AuthentificationService } from '../services/authentification.service';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  currentUser: User;
    users = [];

    constructor(
        private authenticationService: AuthentificationService,
        private userService: UserService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loadAllUsers();
    }

    deleteUser(id: number) {
        this.userService.delete(id)
            .pipe(first())
            .subscribe(() => this.loadAllUsers());
    }

    private loadAllUsers() {
      this.userService.getAll().subscribe((data: any[]) => {
        this.users = data;

      },
        (er: Error) => {
          console.log('err', er);
        });
    }
}
