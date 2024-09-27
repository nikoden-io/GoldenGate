import {Component, inject, OnInit} from "@angular/core";
import {v4 as uuidV4} from 'uuid';

import {MessagesFacade} from "../../../../core/features/messages/infrastructure/messages.facade";
import {Message} from "../../../../core/features/messages/domain/message.entity";

@Component({
  selector: 'app-messenger',
  templateUrl: './app-messenger.component.html',
  styleUrls: ['./app-messenger.component.scss'],
  standalone: true
})

export class AppMessenger implements OnInit {
  private readonly messagesFacade: MessagesFacade = inject(MessagesFacade)

  addMessage(): void {
    const message: Message = {
      id: uuidV4(),
      publishDate: new Date(),
      label: 'My first message',
      content: "This is my first message in Angular using NgRx in Standalone mode"
    }
    this.messagesFacade.addMessage(message)
  }

  deleteMessageFacade(id: string): void {
    this.messagesFacade.deleteOne(id)
  }

  ngOnInit(): void {
    this.addMessage()
  }
}
