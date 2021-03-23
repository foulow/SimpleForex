import { Action, createReducer, on } from '@ngrx/store';
import { CHANGE_CODE } from '../actions/currencyCode.actions';

const initialState: string = '';

// old method.
// export function CurrencyCodeReducer(
//   state: string[] = [initialState],
//   action: CurrencyCodeActions.Actions
// ) {
//   switch (action.type) {
//     case CurrencyCodeActions.CHANGE_CODE:
//       return [...state, action.payload];
//     default:
//       return state;
//   }
// }

const _counterReducer = createReducer(
  initialState,
  on(CHANGE_CODE, (state) => state)
);

export function currencyCodeReducer(state: string | undefined, action: Action) {
  return _counterReducer(state, action);
}
