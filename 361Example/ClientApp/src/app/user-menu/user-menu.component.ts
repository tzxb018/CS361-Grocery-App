import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'user-menu-component',
  templateUrl: './user-menu.component.html'
})
export class UserMenuComponent implements OnInit {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  ngOnInit() {



    //  getAllLists().done(function (data) {
    //    for (var i = 0; i < data.length; i++) {
    //      var contact = data[i];
    //      var editLink = `<a class="btn btn-warning" href="/Home/EditContact?id=${contact.Id}">Edit</a>`;
    //      var deleteButton = `<button class="btn btn-danger" onclick=deleteHandler(${contact.Id})>Delete</button>`;
    //      document.getElementById("#table-body").append(`<tr><td>${data[i].FirstName}</td><td>${data[i].LastName}</td><td>${data[i].EmailAddress}</td><td>${data[i].PhoneNumber}</td><td>${editLink}${deleteButton}</td></tr>`);
    //    }
    //  });
    //};

    //function deleteHandler(id) {
    //  deleteList(id).done(function () {
    //    resetTable();
    //  });
    //}

    //function resetTable() {
    //  $("#table-body").empty();
    //  setupTable();
    //}

    //resetTable();
    document.getElementById("table-body").innerHTML = "<tr><td>Name of List 1</td><td>2/4</td><td>10/16/2020</td><tr> ";

  }
}
