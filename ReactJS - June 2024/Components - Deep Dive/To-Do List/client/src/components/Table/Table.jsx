import TBody from './TBody/TBody';
import THead from './THead/THead';
import styles from './Table.module.css';

function Table({todos}) {
    return (
        <table className={styles.table}>
          <THead></THead>
          <TBody todos={todos}></TBody>
        </table>
    );
}

export default Table;