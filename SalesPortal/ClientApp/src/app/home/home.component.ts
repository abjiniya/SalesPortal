import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public quotations: Quotation[];
  searchText;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Quotation[]>('https://localhost:4001/API/Quotation/GetData').subscribe(result => {

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
