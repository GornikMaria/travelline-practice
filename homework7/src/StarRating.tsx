import React from "react";

interface StarRatingProps {
  totalStars: number;
  rating: number;
  handleStarClick: (starIndex: number) => void;
}

const StarRating: React.FC<StarRatingProps> = ({ totalStars, rating, handleStarClick }) => {
  const stars = Array.from({ length: totalStars });

  return (
    <div>
      {stars.map((_, index) => (
        <span
          key={index}
          className={`star ${index < rating ? "selected" : ""}`}
          onClick={() => handleStarClick(index + 1)}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            width="24"
            height="24"
            fill={index < rating ? "yellow" : "none"}
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
  );
};

export default StarRating;
