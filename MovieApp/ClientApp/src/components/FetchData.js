import React, { Component } from 'react';
import "../Styles/App.css";
import Header from "./Header";
import Movie from "./Movie";
import Search from "./Search";

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { movies: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }


    static renderMovie(movies) {
        
      
        const list = movies.map((movieobj, key) => <Movie key={key} movie={movieobj} />);
            
    return (
   
        <div className="App">
      
            <div className="movies">
                {list}
            
            </div>
        </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderMovie(this.state.movies);
    
    return (
      <div>
       
        {contents}
      </div>
    );
  }

    async searchMovieById(id) {
        const response = await fetch('GetMovieById', id);
        const data = await response.json();
        this.setState({ movies: data, loading: false });
    }

}
