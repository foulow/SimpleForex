import { Action, createReducer, on } from '@ngrx/store';
import { CurrencyPurchase } from '../models/currencyPurchase.model';
import { BUY_CURRENCY } from '../actions/currencyPurchase.actions';

const initialState: CurrencyPurchase = {
  amount: 0,
  currencyId: 1,
  userId: '',
};

// old method.
// export function CurrencyPurchaseReducer(
//   state: CurrencyPurchase[] = [initialState],
//   action: PurchaseActions.Actions
// ) {
//   switch (action.type) {
//     case PurchaseActions.BUY_CURRENCY:
//       return [...state, action.payload];
//     default:
//       return state;
//   }
// }

const _counterReducer = createReducer(
  initialState,
  on(BUY_CURRENCY, (state) => state)
);

export function currencyPurchaseReducer(
  state: CurrencyPurchase | undefined,
  action: Action
) {
  return _counterReducer(state, action);
}
