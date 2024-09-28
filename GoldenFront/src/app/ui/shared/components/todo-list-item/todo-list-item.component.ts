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
  taskTitle: string = $localize`:Task title|Le titre d'une tâche 2d:Task title`
  isComplete = false
  isEditing = false
  isAdmin = false;
  ingredientList = [
    {name: $localize`:noodles|L'ingrédient pâtes:name`, quantity: 1},
    {name: $localize`:miso broth|Bouillon de miso:name`, quantity: 1},
    {name: $localize`:egg|Un oeuf:name`, quantity: 2},
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
