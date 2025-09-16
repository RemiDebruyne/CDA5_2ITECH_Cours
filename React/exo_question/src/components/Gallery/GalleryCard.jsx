export const GalleryCard = ({ image }) => {
  return (
    <div
    // style={{
    //   width: '250px',
    // }}
    >
      <img
        src={image.url}
        alt={image.title}
        style={{ objectFit: 'contain', width: '300px', height: '200px' }}
      />
      <div
        style={{
          display: 'flex',
          flexDirection: 'column',
        }}
      >
        <h2>{image.title}</h2>
        <p>auteur: {image.author}</p>
        {image.categories.map((category, index) => (
          <div key={index}>{category}</div>
        ))}
      </div>
    </div>
  );
};
