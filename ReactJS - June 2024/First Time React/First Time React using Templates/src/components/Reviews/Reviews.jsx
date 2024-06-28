import PersonReview from "./PersonReview";

function Reviews() {
    return (
        <section
            className="reviews-section section-padding section-bg"
            id="section_4"
        >
            <div className="container">
            <div className="row justify-content-center">
                <div className="col-lg-12 col-12 text-center mb-4 pb-lg-2">
                <em className="text-white">Reviews by Customers</em>
                <h2 className="text-white">Testimonials</h2>
                </div>
                <div className="timeline">
                <div className="timeline-container timeline-container-left">
                    <div className="timeline-content">
                        <PersonReview imageUrl="images/reviews/young-woman-with-round-glasses-yellow-sweater.jpg" name="Sandra" role="Customers" review="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." rating="4.5"></PersonReview>
                    </div>
                </div>
                <div className="timeline-container timeline-container-right">
                    <div className="timeline-content">
                        <PersonReview imageUrl="images/reviews/senior-man-white-sweater-eyeglasses.jpg" name="Don" role="Customers" review="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." rating="4.5"></PersonReview>
                    </div>
                </div>
                <div className="timeline-container timeline-container-left">
                    <div className="timeline-content">
                        <PersonReview imageUrl="images/reviews/young-beautiful-woman-pink-warm-sweater-natural-look-smiling-portrait-isolated-long-hair.jpg" name="Olivia" role="Customers" review="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." rating="4.5"></PersonReview>
                    </div>
                </div>
                </div>
            </div>
            </div>
        </section>
    );
}

export default Reviews;