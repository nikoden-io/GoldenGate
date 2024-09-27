import {createAction, props} from "@ngrx/store";
import {messagesKey} from "../messages.state";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import {inject} from "@angular/core";
import {MessagesApiService} from "../../infrastructure/messages-api.service";
import {catchError, map, mergeMap} from "rxjs";


export const deleteMessage$ = createEffect(
  (action$: Actions = inject(Actions), messagesApiService: MessagesApiService = inject(MessagesApiService)) => {
    return action$.pipe(
      ofType(deleteMessage),
      mergeMap(({id}) =>
        messagesApiService.deleteMessage(id).pipe(
          map(() => {
            console.log("Success in deleteMessage$")
            return deleteMessageSuccess()
          }),
          catchError(() => {
            console.log("Error in deleteMessage$")
            return [deleteMessageError()]
          })
        )
      )
    )
  },
  {functional: true}
)


export const deleteMessage = createAction(
  `${messagesKey} Delete Message`,
  props<{ id: string }>()
)

export const deleteMessageSuccess = createAction(
  `${messagesKey} Delete Message Success`
)

export const deleteMessageError = createAction(
  `${messagesKey} Delete Message Error`
)
