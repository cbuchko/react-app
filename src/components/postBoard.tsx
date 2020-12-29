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

    async componentDidMount(){
     
        const response = await fetch('https://jsonplaceholder.typicode.com/posts');
        const json = await response.json();
        this.setState({ userPosts: json});
    }

    render(){

        return(
            <React.StrictMode>
                {this.state.userPosts.map(post => (
                    <Post 
                        key={post.id}
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