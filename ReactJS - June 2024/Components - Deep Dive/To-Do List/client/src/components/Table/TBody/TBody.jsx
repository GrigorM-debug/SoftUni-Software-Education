import styles from './TBody.module.css';
import { useState } from 'react';

function TBody({todos}) {
    const [completedTodos, setCompletedTodos] = useState(todos.map(todo => todo.isCompleted));

    const toggleCompletion = (index) => {
        const newCompletedTodos = [...completedTodos];
        newCompletedTodos[index] = !newCompletedTodos[index];
        setCompletedTodos(newCompletedTodos);
    };

    return (
        <tbody>
            {todos.map((todo, index) => {
                <tr key={todo._id} className={`${styles.todo} ${completedTodos[index] ? styles.isCompleted : ''}`} >
                    <td>{todo.text}</td>
                    {completedTodos[index] ? <td>Complete</td> : <td>Incomplete</td>}
                    <td className={styles.todoAction}>
                        <button className={`btn ${styles.todoBtn}`} onClick={() => toggleCompletion(index)}>Change status</button>
                    </td>
                </tr>
            })}
        </tbody>
    );
}

export default TBody;