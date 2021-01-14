import React, { Component } from 'react';
import Header from "./components/Header";
import Movie from "./components/Movie";
import Search from "./components/Search";
import "./Styles/App.css";
import './custom.css'

export default class App extends Component {
    static displayName = App.name;
    constructor(props) {
        super(props);
        this.state = { movies: [], loading: true };
    }

    componentDidMount() {
        this.populateAllMovies();
    }
  

    static renderMovieContent(movies) {
       
      const search = searchValue => {
          const response = fetch("GetMovies");
          const data = response.json();
          this.setState({ movies: data, loading: false });
      }
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
            : App.renderMovieContent(this.state.movies);
    return (
    
        
        <div className="App">
            <div className="Nav">
                <Header text="Movie App" />
                <Search search="1"/>
            </div>
            <p className="App-intro"> Get best prices for movies and films</p>
            <div className="movies">
                {contents}
            </div>
        </div>
    
    );
    }

    async populateAllMovies() {
        const response = await fetch('Movie');
        const data = await response.json();
        this.setState({ movies: data, loading: false });
    }
   }
