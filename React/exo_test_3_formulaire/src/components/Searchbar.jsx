import { useState } from 'react';

export const Searchbar = ({ onSearch }) => {
  const [search, setSearch] = useState('');
  const handleSearch = (e) => {
    e.preventDefault();
    let query = search.trim();
    if (query === '') return;

    onSearch(query);
  };

  return (
    <>
      <form onSubmit={(e) => handleSearch(e)} action="">
        <input
          type="text"
          name="search"
          id="searchInput"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          placeholder="Rechercher..."
        />
        <button
          id="searchButton"
          type="submit"
          {...(search.trim() === '' && { disabled: true })}
        >
          Rechercher
        </button>
      </form>
    </>
  );
};
