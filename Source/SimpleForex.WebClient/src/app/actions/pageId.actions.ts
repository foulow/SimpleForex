import { Injectable } from '@angular/core';
import { Action, createAction, props } from '@ngrx/store';

// old method.
// export class ChangePageId implements Action {
//   readonly type = CHANGE_PAGE;

//   constructor(public payload: string) {}
// }

// export type Actions = ChangePageId;

export const CHANGE_PAGE = createAction(
  '[PAGE_ID] Change',
  props<{ pageId: string }>()
);
