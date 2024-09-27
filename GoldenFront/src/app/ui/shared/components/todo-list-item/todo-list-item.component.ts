import {Component} from "@angular/core";
import {FormsModule} from "@angular/forms";
import {NgClass, NgIf} from "@angular/common";

@Component({
  standalone: true,
  selector: 'todo-list-item',
  templateUrl: './todo-list-item.component.html',
  imports: [
    FormsModule,
    NgClass,
    NgIf
  ]
})
export class TodoListItem {
  taskTitle: string = 'Task title'
  isComplete = false
  isEditing = false
  isAdmin = false;
  ingredientList = [
    {name: 'noodles', quantity: 1},
    {name: 'miso broth', quantity: 1},
    {name: 'egg', quantity: 2},
  ];

  
  switchAdminMode() {
    this.isAdmin = !this.isAdmin
  }

  completeTask() {
    this.isComplete = true
  }

  incompleteTask() {
    this.isComplete = false
  }

  updateTaskTitle(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    this.taskTitle = inputElement.value;
  }
}
