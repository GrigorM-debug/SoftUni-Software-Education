import styles from './AddButton.module.css';

function AddButton() {
    return (
        <div className={styles.addBtnContainer}>
            <button className="bnt">+ Add new Todo</button>
        </div>
    );
}

export default AddButton;