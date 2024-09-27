import {createAction, props} from "@ngrx/store";
import {Message} from "../../domain/message.entity";
import {messagesKey} from "../messages.state";

export const addMessage = createAction(
  `${messagesKey} Add Message`,
  props<{ message: Message }>()
)
