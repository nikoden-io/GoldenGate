import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";

import {IMessageService} from "../../domain/IMessageService";

@Injectable({providedIn: 'root'})
export class MessagesMockService implements IMessageService {
  deleteMessage(id: string): Observable<void> {
    console.log(`Mock service: deleteMessage triggered with id: ${id}`);
    return of(void 0);
  }
}
