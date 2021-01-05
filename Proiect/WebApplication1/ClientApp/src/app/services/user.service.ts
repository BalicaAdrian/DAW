import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = "https://localhost:44383/api"

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get(`${this.apiUrl}/users/all`);
  }

  register(user: User) {
      return this.http.post(`${this.apiUrl}/Auth/register`, user);
  }

  delete(id: number) {
      return this.http.delete(`${this.apiUrl}/users/${id}`);
  }
}
