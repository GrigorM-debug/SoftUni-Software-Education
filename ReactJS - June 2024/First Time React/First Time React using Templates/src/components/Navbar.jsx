function Navbar() {
    return (
        <div id="sticky-wrapper" className="sticky-wrapper" style={{height: '154px'}}>
            <nav className="navbar navbar-expand-lg">
                <div className="container">
                <a className="navbar-brand d-flex align-items-center" href="index.html">
                    <img
                    src="/images/coffee-beans.png"
                    className="navbar-brand-image img-fluid"
                    alt="Barista Cafe Template"
                    />
                    Barista
                </a>
                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon" />
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ms-lg-auto">
                    <li className="nav-item">
                        <a className="nav-link click-scroll" href="#section_1">
                        Home
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link click-scroll" href="#section_2">
                        About
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link click-scroll" href="#section_3">
                        Our Menu
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link click-scroll" href="#section_4">
                        Reviews
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link click-scroll" href="#section_5">
                        Contact
                        </a>
                    </li>
                    </ul>
                    <div className="ms-lg-3">
                    <a
                        className="btn custom-btn custom-border-btn"
                        href="reservation.html"
                    >
                        Reservation
                        <i className="bi-arrow-up-right ms-2" />
                    </a>
                    </div>
                </div>
                </div>
            </nav>
        </div>
    );
}

export default Navbar;
