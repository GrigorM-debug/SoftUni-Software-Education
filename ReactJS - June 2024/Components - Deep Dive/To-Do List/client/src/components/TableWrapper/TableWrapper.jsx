import LoadingSpinner from '../LoadingSpinner/LoadingSpinner';
import Table from '../Table/Table';
import styles from './TableWrapper.module.css';
import {useState, useEffect} from 'react';

function TableWrapper() {
    const [todos, setTodos] = useState([]);
    const [loading, setLoading] = useState(false);
    
    useEffect(() => {
        setLoading(true);

        fetch("http://localhost:3030/jsonstore/todos")
            .then(response => response.json())
            .then(data => {
                setTodos(Object.values(data))
                setLoading(false);
            })
            .catch(err => {
                console.error('Error fetching todos:', err);
                setLoading(false);
            })
    }, []);

    return (
        <div className={styles.tableWrapper}>
            {loading ? <LoadingSpinner /> : <Table todos={todos} />}
        </div>
    );
}

export default TableWrapper;