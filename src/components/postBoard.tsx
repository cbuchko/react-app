import { ReactComponent } from '*.svg';
import * as React from 'react';
import { Component } from 'react';
import Post from './post';

class PostBoard extends Component {

    render(){

        return(
            <React.StrictMode>
                <Post/>
                <Post/>
                <Post/>
                <Post/>
            </React.StrictMode>
        );
    }

}

export default PostBoard;