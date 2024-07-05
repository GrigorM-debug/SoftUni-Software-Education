import ToDoListContainer from '../To-DoListContainer/ToDoListContainer';
import styles from'./Main.module.css';

function Main() {
    return (
        <main className={styles.main}>
            <ToDoListContainer></ToDoListContainer>
        </main>
    );
}

export default Main;