import styles from './LoadingSpinner.module.css';

function LoadingSpinner() {
    return (
        <div className={styles.loadingContainer}>
          <div className={styles.loadingSpinner}>
            <span className={styles.loadingSpinnerText}>Loading</span>
          </div>
        </div>
    );
}

export default LoadingSpinner;