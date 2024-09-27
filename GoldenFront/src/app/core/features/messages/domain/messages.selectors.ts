import {createFeatureSelector, createSelector, MemoizedSelector} from "@ngrx/store";
import {AppState} from "../../../shared/store/store.app-state";
import {Message} from "./message.entity";
import {MessagesState} from "../application/messages.state";

export const selectMessagesFeature: MemoizedSelector<AppState, MessagesState> = createFeatureSelector<MessagesState>('messages')

export const selectMessages: MemoizedSelector<AppState, Message[]> = createSelector(
  selectMessagesFeature,
  ({entities}: MessagesState): Message[] => Object.values(entities) as Message[]
)
