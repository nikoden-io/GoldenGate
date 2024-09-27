import {createEntityAdapter, EntityAdapter, EntityState} from "@ngrx/entity";
import {Message} from "../domain/message.entity";

export const messagesKey = '[Messages]'

export interface MessagesState extends EntityState<Message> {
  loading: []
}

export const selectId = ({id}: Message) => id

export const sortComparer = (a: Message, b: Message): number => a.publishDate.toString().localeCompare(b.publishDate.toString())

export const messagesAdapter: EntityAdapter<Message> = createEntityAdapter({selectId, sortComparer})

export const initialMessagesState: MessagesState = messagesAdapter.getInitialState({loading: []})
