import { Injectable } from '@angular/core';
import { Action, createAction, props } from '@ngrx/store';
import { CurrencyQuotation } from '../models/currencyQuotation.model';

// old method.
// export class GetCurrency implements Action {
//   readonly type = GET_CURRENCY;

//   constructor(public payload: string) {}
// }

// export type Actions = GetCurrency;

export const GET_CURRENCY = createAction('[CURRENCY_QUOTATION] Get');

export const SET_CURRENCY = createAction(
  '[CURRENCY_QUOTATION] Set',
  props<{ currency: CurrencyQuotation }>()
);

export const GET_CURRENCIES = createAction('[CURRENCY_QUOTATION] Query');

export const ADD_CURRENCY = createAction(
  '[CURRENCY_QUOTATION] Add',
  props<{ currency: CurrencyQuotation }>()
);
