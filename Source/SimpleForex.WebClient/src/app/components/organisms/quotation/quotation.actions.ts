import { createAction } from '@ngrx/store';

// quotation reducer actions.
export const increment = createAction('[Quotation Component] Increment');
export const decrement = createAction('[Quotation Component] Decrement');
export const reset = createAction('[Quotation Component] Reset');

// currencyService actions for the quotation component.
export const GET = createAction('[Quotation Component] GET');
