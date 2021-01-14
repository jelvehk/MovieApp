import React, {useState} from 'react'

const Search = (propsa) => {
  const [searchValue, setSearchValue] = useState("");

  const handleSearchInputChanges = (e) => {
    setSearchValue(e.target.value);
  }

  const resetInputField = () => {
    setSearchValue("");
  }

  const callSearchFunction = (e) => {
    e.preventDefault();
    propsa.search=(searchValue);
    resetInputField();
  }
 

  return (
    <div>
      <form className="search">
        <input
          value={searchValue}
          onChange={handleSearchInputChanges}
          type="text"
          placeholder="Search..."
        />
        <input  type="submit" value="SEARCH" />
      </form>
    </div>
  )
}

export default Search
