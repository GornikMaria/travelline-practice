import React from "react";

interface ReviewFormProps {
  text: string;
  setText: React.Dispatch<React.SetStateAction<string>>;
  handleSubmit: () => void;
}

const ReviewForm: React.FC<ReviewFormProps> = ({ text, setText, handleSubmit }) => {
  return (
    <div>
      <textarea
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="What could we improve?"
      />
      <button className="send-button" onClick={handleSubmit}>
        Send
      </button>
    </div>
  );
};

export default ReviewForm;
