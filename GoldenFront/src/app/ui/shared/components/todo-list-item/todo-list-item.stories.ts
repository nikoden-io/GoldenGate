import type {Meta, StoryObj} from '@storybook/angular';
import {TodoListItem} from "./todo-list-item.component";

const meta: Meta<TodoListItem> = {
  title: 'TodoListItem',
  component: TodoListItem,
  parameters: {
    layout: 'fullscreen',
  },
};

export default meta;
type Story = StoryObj<TodoListItem>;

export const Basic: Story = {};
