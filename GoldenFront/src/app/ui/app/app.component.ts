import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {TodoList} from "../shared/components/todo-list/todo-list.component";
import {TodoListItem} from "../shared/components/todo-list-item/todo-list-item.component";
import {AppMessenger} from "../shared/components/app-messenger/app-messenger.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TodoList, TodoListItem, AppMessenger],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'GoldenFront';
}
