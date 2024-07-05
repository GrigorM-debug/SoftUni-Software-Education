import styles from './Header.module.css';

function Header() {
    return (
        <header className={styles.navigationHeader}>
            <span className={styles.navigationLogo}>
                <img src="/images/todo-icon.png" alt="todo-logo" />
            </span>
            <span className="spacer"></span>
            <span className={styles.navigationDescription}>Todo List</span>
        </header>
    );
}

export default Header;
