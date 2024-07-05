import styles from './TBody.module.css';
import { useState } from 'react';

function TBody({todos}) {
    const [todosWithUnchangedStatuses, setCompletedTodosStatus] = useState(todos);

    const toggleCompletion = (todoId) => {
        const todosWithUnchangedStatusesCopyRef = [...todosWithUnchangedStatuses];

        todosWithUnchangedStatusesCopyRef.forEach(t => {
            if(t._id === todoId) {
                t.isCompleted = !t.isCompleted;
            }
        })

        setCompletedTodosStatus(todosWithUnchangedStatusesCopyRef);
    };

    return (
        <tbody>
            {todos.map((todo) => (
                <tr key={todo._id} className={`${styles.todo} ${todo.isCompleted ? styles.isCompleted : ''}`} >
                    <td>{todo.text}</td>
                    {todo.isCompleted ? <td>Complete</td> : <td>Incomplete</td>}
                    <td className={styles.todoAction}>
                        <button className={`btn ${styles.todoBtn}`} onClick={() => toggleCompletion(todo._id)}>Change status</button>
                    </td>
                </tr>
            ))}
        </tbody>
    );
}

export default TBody;