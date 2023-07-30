import React, { useState } from "react";
import StarRating from "./StarRating";
import ReviewForm from "./ReviewForm";

interface Review {
  rating: number;
  reviewText: string;
}

const App: React.FC = () => {
  const totalStars = 5;
  const [text, setText] = useState<string>('');
  const [lastReview, setLastReview] = useState<Review | null>(null);
  const [selectedStars, setSelectedStars] = useState<number[]>([]);
  const [rating, setRating] = useState<number>(0);

  const handleStarClick = (starIndex: number) => {
    setSelectedStars([...Array(starIndex + 1).keys()]);
    setRating(starIndex + 1);
  };

  const handleSubmit = () => {
    if (rating !== 0 && text.trim() !== '') {
      const newReview: Review = {
        rating: rating,
        reviewText: text,
      };
      setLastReview(newReview);
      setRating(0);
      setText('');
      setSelectedStars([]);
    }
  };

  return (
    <div className="App">
      <h1>How nice was my reply?</h1>
      <div className="rating-container">
        <span style={{ float: 'right' }}>
          ({rating}/{totalStars})
        </span>
      </div>
      <StarRating
        totalStars={totalStars}
        rating={rating}
        handleStarClick={handleStarClick}
      />
      <ReviewForm text={text} setText={setText} handleSubmit={handleSubmit} />
      {lastReview && (
        <div className="review-container">
          <div className="review-icon">&#9679;</div>
          <div className="review-text">
            {lastReview.rating}/{totalStars}
          </div>
          <div className="review-text">
            {lastReview.reviewText}
          </div>
        </div>
      )}
    </div>
  );
};

export default App;
