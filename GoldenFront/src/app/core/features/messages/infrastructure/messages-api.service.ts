import {inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

import {IMessageService} from "../domain/IMessageService";

@Injectable({providedIn: 'root'})
export class MessagesApiService implements IMessageService {
  private readonly http: HttpClient = inject(HttpClient)

  deleteMessage(id: string): Observable<void> {
    console.log("MessagesApiService: deleteMessage triggered", id)
    return this.http.delete<void>(`/api/messages/${id}`)
  }
}
