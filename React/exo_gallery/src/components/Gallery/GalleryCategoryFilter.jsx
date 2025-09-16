export const GalleryCategoryFilter = ({ categories, onClick }) => {
  return categories.map((category, index) => (
    <button key={index} onClick={() => onClick(category)}>
      {category}
    </button>
  ));
};
