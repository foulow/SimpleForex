import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CurrencyPurchase } from '../models/currencyPurchase.model';
import { CurrencyQuotation } from '../models/currencyQuotation.model';

import { Action, Store } from '@ngrx/store';
import { state } from '@angular/animations';
import { AppState } from '../app.state';
import {
  GET_CURRENCY,
  SET_CURRENCY,
} from '../actions/currencyQuotation.actions';

export const GET = 'GET';
export const POST = 'POST';
export const REFRESH = 'REFRESH';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  currenciesQuotation: Observable<CurrencyQuotation[]>;
  currencyQuotation: Observable<CurrencyQuotation>;
  currencyPurchase: Observable<CurrencyPurchase>;
  currencyCode: Observable<string>;

  constructor(private http: HttpClient, private store: Store<AppState>) {
    this.currencyCode = this.store.select('currencyCode');
    this.currenciesQuotation = this.store.select('currenciesQuotations');
    this.currencyQuotation = this.store.select('currencyQuotations');
    this.currencyPurchase = this.store.select('currencyPurchase');
  }

  public getCurrencyQuotation(
    currencyCode: string
  ): Observable<CurrencyQuotation> {
    return this.getCurrency(currencyCode);
  }

  public refreshQuotation(currencyCode: string): Observable<CurrencyQuotation> {
    return this.getCurrency(currencyCode);
  }

  private getCurrency(currencyCode: string): Observable<CurrencyQuotation> {
    var promise = this.http.get('http://127.0.0.1:8080/api/currecies', {
      params: {
        code: currencyCode,
      },
    });

    promise.subscribe((observer) => {
      const currency = observer.valueOf() as CurrencyQuotation;
      this.store.dispatch(SET_CURRENCY({ currency: currency }));
    });

    return promise as Observable<CurrencyQuotation>;
  }

  public postCurrencyPurchase(): Observable<any> {
    return this.http.post(
      'http://127.0.0.1:8080/api/currecies',
      this.currencyPurchase
    );
  }
}

@Injectable({
  providedIn: 'root',
})
export class CurrencyServiceMock {
  constructor(private http: HttpClient) {}

  public getCurrencyQuotation(
    currencyCode: string
  ): Observable<CurrencyQuotation> {
    return new Observable<CurrencyQuotation>((observer) => {
      const currency: CurrencyQuotation = {
        code: 'USD_ARS',
        sellPrice: 80.52,
        purchasePrice: 78.05,
        updatedOn: `Actualizado: ${new Date().toString()}`,
        id: 1,
      };
      observer.next(currency);
    });
  }

  public postCurrencyPurchase(
    currencyPurchase: CurrencyPurchase
  ): Observable<boolean> {
    return new Observable<boolean>((observer) => {
      console.log(currencyPurchase);
      observer.next(true);
    });
  }
}
