import { Component, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { DataService } from '../data.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./bg.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class NewAccountComponent {

  // holds all the glists for the component
  public allUsers: User[];
  public selectedUser: User;
  public login: number;

  constructor(private loginService: LoginService, private router: Router) {
    document.body.classList.add('bg');

    this.refreshTable();
  }

  //func to refresh table
  async refreshTable() {

    const result = await this.loginService.getAllUser().toPromise();
    this.allUsers = result;

  }



  emailValid(email) {
    for (const user of this.allUsers) {
      if (!email.includes("@") && !email.includes(".com")) {
        document.getElementById("feedback").innerHTML = "Invalid email input, please use another email.";
        return false;
      }
      if (email == user.email) {
        document.getElementById("feedback").innerHTML = "Email already exist, please log in or use another email.";
        return false;
      }
      return true;
    }
  }

  createNewUser() {
    const newEmailForm = document.getElementById("newEmail") as HTMLInputElement;
    const newEmail = newEmailForm.value;
    const newPasswordForm1 = document.getElementById("newPassword1") as HTMLInputElement;
    const newPassword1 = newPasswordForm1.value;
    const newPasswordForm2 = document.getElementById("newPassword2") as HTMLInputElement;
    const newPassword2 = newPasswordForm2.value;

    const newUser = {
      email: newEmail,
      password: newPassword1,
    };

    if (this.emailValid(newEmail) == true) {
      if (newPassword1 == newPassword2) {
        this.loginService
          .insertUser(newUser)
          .subscribe(user => this.allUsers.push(user));

        alert("New user " + newEmail + " created!\nLogin to confirm account creation!");
        this.router.navigate(['/']);
      } else {
        document.getElementById("feedback").innerHTML = "Passwords do not match, please re-enter the passwords.";
      }
    }




  }

}

interface User {
  email: string;
  password: string;
}
