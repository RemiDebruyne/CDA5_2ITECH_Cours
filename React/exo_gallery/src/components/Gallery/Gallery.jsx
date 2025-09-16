import { useEffect, useState } from 'react';
import { IMAGES } from '../../assets/gallery';
import { CATEGORIES } from '../../assets/gallery';
import { GalleryCard } from './GalleryCard';
import { GalleryCategoryFilter } from './GalleryCategoryFilter';
import { GalleryFeed } from './GalleryFeed';

export const Gallery = () => {
  const [selectedCategories, setSelectedCategories] = useState([]);
  const [filteredImages, setFilteredImages] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isError, setIsError] = useState(false);

  const handleOnCategorySelect = (selectedCategory) => {
    setSelectedCategories(() => {
      if (selectedCategory === 'toutes') {
        return [];
      }
      if (!selectedCategories.includes(selectedCategory)) {
        return [...selectedCategories, selectedCategory];
      } else {
        return selectedCategories.filter(
          (category) => category != selectedCategory
        );
      }
    });
  };

  useEffect(() => {
    setTimeout(() => setIsLoading(false), 3000);
    try {
      if (isError) {
        console.log('ERRREUR');

        throw new Error();
      }

      setFilteredImages(() => {
        if (selectedCategories.length > 0) {
          const images = [];

          IMAGES.map((image) => {
            if (
              image.categories.some((category) =>
                selectedCategories.includes(category)
              )
            ) {
              images.push(image);
            }
          });
          return images;
        }

        return IMAGES;
      });
    } catch {
      setFilteredImages([]);
    }
  }, [selectedCategories, isLoading, isError]);

  return (
    <>
      <div
        style={{
          height: '100vph',
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          alignItems: 'center',
          marginInline: 'auto',
        }}
      >
        <div>
          <div style={{ display: 'flex', alignItems: 'center', gap: '24px' }}>
            <h1>Galeries d'images</h1>
            <button
              onClick={() => setIsError(!isError)}
              style={{ height: '4rem' }}
            >
              Erreur
            </button>
          </div>
          <p>Filter par catégories</p>
          <GalleryCategoryFilter
            //   categories={availableCategories()}
            categories={CATEGORIES}
            onClick={handleOnCategorySelect}
          />
        </div>
        <GalleryFeed images={filteredImages} isLoading={isLoading} />
      </div>
    </>
  );
};
