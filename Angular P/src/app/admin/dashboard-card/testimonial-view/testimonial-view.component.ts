import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-testimonial-view',
  templateUrl: './testimonial-view.component.html',
  styleUrls: ['./testimonial-view.component.css']
})
export class TestimonialViewComponent implements OnInit {

  constructor(public dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {

  }

}
