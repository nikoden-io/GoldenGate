import {inject, Injectable} from "@angular/core";
import {Store} from "@ngrx/store";
import {Observable} from "rxjs";

import {selectMessages} from "../domain/messages.selectors";
import {Message} from "../domain/message.entity";
import {addMessage, deleteMessage} from "../application/usecases";


@Injectable({providedIn: 'root'})
export class MessagesFacade {
  private readonly store: Store = inject(Store)

  readonly messages: Observable<Message[]> = this.store.select(selectMessages)

  addMessage(message: Message): void {
    this.store.dispatch(addMessage({message}))
  }

  deleteOne(id: string): void {
    console.log("DeleteOne triggered", id)
    this.store.dispatch(deleteMessage({id}))
  }
}
