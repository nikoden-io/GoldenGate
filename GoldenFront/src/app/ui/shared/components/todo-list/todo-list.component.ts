import {Component} from "@angular/core";
import {TodoListItem} from "../todo-list-item/todo-list-item.component";
import {environment} from "../../../../../environments/environment";

@Component({
  standalone: true,
  imports: [TodoListItem],
  selector: 'todo-list',
  templateUrl: 'todo-list.component.html',
  styleUrl: 'todo-list.component.scss'
})

export class TodoList {
  public envDescription = environment.description
}
