import { useState } from "react";
interface Review {
  rating: number;
  reviewText: string;
}

const App: React.FC = () => {
  const [text, setText] = useState<string>('');
  const [lastReview, setLastReview] = useState<Review | null>(null);

  const [selectedStars, setSelectedStars] = useState<number[]>([]);
  const totalStars = 5;
  const [rating, setRating] = useState(0);

  const handleStarClick = (starIndex: number) => {
    setSelectedStars([...Array(starIndex + 1).keys()]);
    setRating(starIndex + 1);
  };

  const handleSubmit = () => {
    if (rating !== null && text.trim() !== '') {
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
    <div>
    {Array.from({ length: totalStars }).map((_, index) => (
          <span
            key={index}
            className={`star ${selectedStars.includes(index) ? "selected" : ""}`}
            onClick={() => handleStarClick(index)}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 24 24"
              width="24"
              height="24"
              fill={selectedStars.includes(index) ? "yellow" : "none"}
              stroke="yellow"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
              className="feather feather-star"
            >
              <polygon points="12 2 15.09 8.18 22 9.27 17 14 18.18 21 12 17.77 5.82 21 7 14 2 9.27 8.91 8.18 12 2" />
            </svg>
          </span>
        ))}
      </div>
      <textarea
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="What could we improve?"
      />
      <button className="send-button" onClick={handleSubmit}>Send</button>
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
