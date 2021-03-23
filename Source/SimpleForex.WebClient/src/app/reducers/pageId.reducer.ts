import { Action, createReducer, on } from '@ngrx/store';
import { CHANGE_PAGE } from '../actions/pageId.actions';

const initialState: string = '';

// old method.
// export function pageIdReducer(
//   state: string[] = [initialState],
//   action: PageIdActions.Actions
// ) {
//   switch (action.type) {
//     case PageIdActions.CHANGE_PAGE:
//       return [...state, action.payload];
//     default:
//       return state;
//   }
// }

const _counterReducer = createReducer(
  initialState,
  on(CHANGE_PAGE, (state) => state)
);

export function pageIdReducer(state: string | undefined, action: Action) {
  return _counterReducer(state, action);
}
