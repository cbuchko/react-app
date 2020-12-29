import { ReactComponent } from '*.svg';
import * as React from 'react';
import { Component } from 'react';
import Post from './post';

interface PostObject {
    userId: number,
    id: number,
    title: string,
    completed: boolean
}

interface IState {
    userPosts: PostObject[]
}

class PostBoard extends Component<{}, IState>{

    state = {
        userPosts: [{
            userId: 0,
            id: 0,
            title: "None",
            completed: false
        }]
    };

    componentDidMount(){
     
        fetch('https://jsonplaceholder.typicode.com/posts')
        .then(response => response.json())
        .then(json => {
            let userPosts = json;
            this.setState({userPosts});
        });
      
    }

    render(){

        return(
            <React.StrictMode>
                {this.state.userPosts.map(post => (
                    <Post 
                        userId={post.userId} 
                        id={post.id} 
                        title={post.title} 
                        completed={post.completed}
                    />
                ))}
            </React.StrictMode>
        );
    }

}

export default PostBoard;