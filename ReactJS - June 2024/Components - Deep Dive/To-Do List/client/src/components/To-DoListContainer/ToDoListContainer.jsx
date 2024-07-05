import AddButton from '../AddButton/AddButton';
import TableWrapper from '../TableWrapper/TableWrapper';
import styles from './ToDoListContainer.module.css';

function ToDoListContainer() {
    return (
        <section className={styles.todoListContainer}>
            <h1>Todo List</h1>
            <AddButton></AddButton>
            <TableWrapper></TableWrapper>
        </section>
    );
}

export default ToDoListContainer;