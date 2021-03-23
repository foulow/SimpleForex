import { Action, createReducer, on } from '@ngrx/store';
import { CurrencyQuotation } from '../models/currencyQuotation.model';
import {
  ADD_CURRENCY,
  GET_CURRENCIES,
  GET_CURRENCY,
  SET_CURRENCY,
} from '../actions/currencyQuotation.actions';

const initialState: CurrencyQuotation = {
  id: 0,
  code: '',
  sellPrice: 0,
  purchasePrice: 0,
  updatedOn: '',
};

// old method.
// export function currencyQuotationReducer(
//   state: CurrencyQuotation[] = [initialState],
//   action: QuotationActions.Actions
// ) {
//   switch (action.type) {
//     case QuotationActions.GET_CURRENCY:
//       return [...state, action.payload];
//     default:
//       return state;
//   }
// }

const _currencyReducer = createReducer(
  initialState,
  on(GET_CURRENCY, (state) => state),
  on(SET_CURRENCY, (state, params) => (state = params.currency))
);

export function currencyQuotationReducer(
  state: CurrencyQuotation | undefined,
  action: Action
) {
  return _currencyReducer(state, action);
}

const _currenciesReducer = createReducer(
  [initialState],
  on(GET_CURRENCIES, (state) => state),
  on(ADD_CURRENCY, (state, params) => [...state, params.currency])
);

export function currenciesQuotationReducer(
  state: CurrencyQuotation[] | undefined,
  action: Action
) {
  return _currenciesReducer(state, action);
}
