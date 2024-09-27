import {Observable} from "rxjs";

export interface IMessageService {
  deleteMessage(id: string): Observable<void>
}
