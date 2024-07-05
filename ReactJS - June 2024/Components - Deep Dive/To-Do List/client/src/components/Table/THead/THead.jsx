import styles from './THead.module.css';

function THead() {
    return (
        <thead>
            <tr>
              <th className={styles.tableHeaderTask}>Task</th>
              <th className={styles.tableHeaderStatus}>Status</th>
              <th className={styles.tableHeaderAction}>Action</th>
            </tr>
        </thead>
    );
}

export default THead;