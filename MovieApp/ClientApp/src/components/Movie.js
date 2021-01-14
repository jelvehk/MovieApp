import React from 'react'
import img from "../images/1.jpg";
const DEFAULT_PLACEHOLDER_IMAGE = "./images/1.jpg";

const Movie = (movieEntity) => {
    const movie = movieEntity.movie;
  
   // const poster = movie.poster === 'N/A' ? DEFAULT_PLACEHOLDER_IMAGE : movie.poster;
    const poster = img;
    return (
        <div className="movie" id={movie.id} >
            <p>{movie.title} ( {movie.year})</p>
      <div>
      <img
          width="200"
          alt={movie.title} 
          src={poster}
        />
      </div>
    </div>
    )

}

export default Movie
