function PersonReview(props) {
    return (
        <div className="reviews-block">
            <div className="reviews-block-image-wrap d-flex align-items-center">
            <img
                src={props.imageUrl}
                className="reviews-block-image img-fluid"
                alt=""
            />
            <div className="">
                <h6 className="text-white mb-0">{props.name}</h6>
                <em className="text-white"> {props.role}</em>
            </div>
            </div>
            <div className="reviews-block-info">
            <p>
                {props.review}
            </p>
            <div className="d-flex border-top pt-3 mt-4">
                <strong className="text-white">
                {props.rating} <small className="ms-2">Rating</small>
                </strong>
                <div className="reviews-group ms-auto">
                <i className="bi-star-fill" />
                <i className="bi-star-fill" />
                <i className="bi-star-fill" />
                <i className="bi-star-fill" />
                <i className="bi-star" />
                </div>
            </div>
            </div>
        </div>
    );
}

export default PersonReview;