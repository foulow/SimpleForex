import { Injectable } from '@angular/core';
import { Action, createAction, props } from '@ngrx/store';
import { CurrencyPurchase } from '../models/currencyPurchase.model';

// old method.
// export class PurchaseCurrency implements Action {
//   readonly type = BUY_CURRENCY;

//   constructor(public payload: string) {}
// }

// export type Actions = PurchaseCurrency;

export const BUY_CURRENCY = createAction(
  '[CURRENCY_PURCHASE] Buy',
  props<{ currencyPurchase: CurrencyPurchase }>()
);
