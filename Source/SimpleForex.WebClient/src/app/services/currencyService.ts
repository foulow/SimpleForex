import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CurrencyPurchaseDTO } from '../models/currencyPurchaseDTO';
import { CurrencyQuotationDTO } from '../models/currencyQuotationDTO';

import { Action, Store } from '@ngrx/store';
import { state } from '@angular/animations';

interface AppStore {
  currencyCode: string;
  currencyQuotation: CurrencyQuotationDTO;
  currencyPurchase: CurrencyPurchaseDTO;
}

export const GET = 'GET';
export const POST = 'POST';
export const REFRESH = 'REFRESH';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  _currencyQuotation: CurrencyQuotationDTO | undefined;
  _currencyPurchase: CurrencyPurchaseDTO | undefined;
  _currencyCode: string;

  constructor(private http: HttpClient, private store: Store<AppStore>) {
    this._currencyQuotation = undefined;
    this._currencyPurchase = undefined;
    this._currencyCode = 'USD_ARS';

    // get call every time the state changes.
    this.store.subscribe((state) => {
      this._currencyQuotation = state.currencyQuotation;
      this._currencyPurchase = state.currencyPurchase;
      this._currencyCode = state.currencyCode;
    });
  }

  getCurrencyQuotation(): Observable<any> {
    return this.http.get('http://127.0.0.1:8080/api/currecies', {
      params: {
        code: this._currencyCode,
      },
    });
  }

  postCurrencyPurchase(): Observable<any> {
    return this.http.post(
      'http://127.0.0.1:8080/api/currecies',
      this._currencyPurchase
    );
  }
}

@Injectable({
  providedIn: 'root',
})
export class CurrencyServiceMock {
  constructor(private http: HttpClient) {}

  getCurrencyQuotation(currencyCode: string): Observable<CurrencyQuotationDTO> {
    return new Observable<CurrencyQuotationDTO>((observer) => {
      const currency: CurrencyQuotationDTO = {
        buy: 78.05,
        sell: 80.52,
        lastRequested: `Actualizado: ${new Date().toString()}`,
      };
      observer.next(currency);
    });
  }

  postCurrencyPurchase(
    currencyPurchase: CurrencyPurchaseDTO
  ): Observable<boolean> {
    return new Observable<boolean>((observer) => {
      console.log(currencyPurchase);
      observer.next(true);
    });
  }
}
