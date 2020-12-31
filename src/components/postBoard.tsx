import * as React from 'react';
import { Component } from 'react';
import Post from './post';

interface PostObject {
    userId: number,
    id: number,
    title: string,
    userName: string,
    completed: boolean
}

interface IState {
    userPosts: PostObject[],
    boardLength: number
}

class PostBoard extends Component<{}, IState>{

    state = {
        userPosts: [{
            userId: 0,
            id: 0,
            title: "None",
            userName: "None",
            completed: false
        }],
        boardLength: 4
    };

    componentDidMount(){
        this.refreshPosts();
    }

    async refreshPosts(){
        console.log("hello world")
        const postsResponse = await fetch('https://jsonplaceholder.typicode.com/posts');
        const postsJson = await postsResponse.json();

        const usersResponse = await fetch('https://jsonplaceholder.typicode.com/users');
        const usersJson = await usersResponse.json();

        let userPosts = shuffle(postsJson).slice(0,this.state.boardLength)

        /*
        * Compare user ids from posts and users to correctly identified what user
        * authored each post.
        */
        for(var i = 0; i < userPosts.length; i++){
            for(var j = 0; j < usersJson.length; j++){
                if(userPosts[i].userId === usersJson[j].id){
                    userPosts[i].userName = usersJson[j].name;
                }
            }
        }
        
        this.setState({userPosts});
    }

    render(){

        return(
            <div className="container-sm px-0 w-50 p-2">
                {this.state.userPosts.map(post => (
                    <Post 
                        key={post.id}
                        userName={post.userName} 
                        id={post.id} 
                        title={post.title} 
                        completed={post.completed}
                    />
                ))}
                <button className="btn btn-primary m-2" onClick={() => this.refreshPosts()}>Refresh</button>
            </div>
        );
    }

}

function shuffle(array: PostObject[]) {
    var currentIndex = array.length, temporaryValue, randomIndex;
  
    // While there remain elements to shuffle...
    while (0 !== currentIndex) {
  
      // Pick a remaining element...
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex -= 1;
  
      // And swap it with the current element.
      temporaryValue = array[currentIndex];
      array[currentIndex] = array[randomIndex];
      array[randomIndex] = temporaryValue;
    }
  
    return array;
}

export default PostBoard;