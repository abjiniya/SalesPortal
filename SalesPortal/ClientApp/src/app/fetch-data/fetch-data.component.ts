import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public quotations: Quotation[];
  searchText;
  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Quotation[]>('https://localhost:4001/API/Quotation/Get').subscribe(result => {
      
      console.log(result);
      this.quotations = result;
    }, error => console.error(error));
  }
}


interface Quotation {
  number: number;
  price: number;
  description: string;
  productName: string;
  customerName: string;
  dealerName: string;
  dateOfQuotation: string;
  validUntil: string;
}
