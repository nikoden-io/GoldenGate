import {ActionReducer, createReducer, on} from "@ngrx/store";
import {initialMessagesState, messagesAdapter, MessagesState} from "./messages.state";
import {addMessage} from "./usecases/add-message.usecase";
import {deleteMessage} from "./usecases/delete-message.usecase";

export const messagesReducers: ActionReducer<MessagesState> = createReducer(
  initialMessagesState,
  on(addMessage, (state: MessagesState, {message}) => messagesAdapter.addOne(message, state)),
  on(deleteMessage, (state: MessagesState, {id}) => messagesAdapter.removeOne(id, state))
)
