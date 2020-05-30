import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  date: Date;

  constructor() { }

  ngOnInit(): void {
    this.getCurrentDate();
  }

  getCurrentDate(): void {
    this.date = new Date(Date.now());
  }

}
