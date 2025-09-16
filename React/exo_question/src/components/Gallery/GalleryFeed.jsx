import { GalleryCard } from './GalleryCard';

export const GalleryFeed = ({ images, isLoading }) => {
  if (isLoading) {
    return <h2>Chargement...</h2>;
  }
  if (images.length > 0) {
    return (
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '1fr 1fr 1fr',
          gap: '12px',
        }}
      >
        {images.map((image) => (
          <GalleryCard image={image} key={image.id} />
        ))}
      </div>
    );
  } else {
    return <h2>Aucun Résultat trouvé</h2>;
  }
};
