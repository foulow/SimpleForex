import { Injectable } from '@angular/core';
import { Action, createAction, props } from '@ngrx/store';

// old method.
// export class ChangeCurrencyCode implements Action {
//   readonly type = CHANGE_CODE;

//   constructor(public payload: string) {}
// }

// export type Actions = ChangeCurrencyCode;

export const CHANGE_CODE = createAction(
  '[CURRENCY_CODE] Change',
  props<{ currencyCode: string }>()
);
