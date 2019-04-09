import { Component, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModel } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  data: any;
  keyword: '';

  @ViewChild('tKeyword') tKeyword: NgModel;

  constructor(private http: HttpClient){}
  ngOnInit(): void {
    this.http.get('/api/spots')
    .subscribe((value: any) => {
      this.data = value;
    });
  }

  ngAfterViewInit(): void {
    this.tKeyword.valueChanges
    .pipe(
      debounceTime(500)
    )
    .subscribe(k => {
      this.http.get('/api/spots?k=' + k)
      .subscribe((value: any) => {
        this.data = value;
      });
    });

  }
}
