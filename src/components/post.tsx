import * as React from 'react';
import { Component } from 'react';


class Post extends Component {

    state = {
        userData: {
            userID: 0,
            id: 0,
            title: "None",
            completed: false

        }
    };

    componentDidMount(){
        const min = 1;
        const max = 100;
        const rand = Math.floor(min + Math.random() * (max - min));

        fetch('https://jsonplaceholder.typicode.com/posts/' + rand)
        .then(response => response.json())
        .then(json => {
            let userData = {...this.state.userData, userID: json.userId, id: json.id, title: json.title, completed: json.completed}
            this.setState({userData})
        });
      
    }

    render(){

        return(
            <div className="container-sm border-bottom border-primary px-0 w-50 p-2">
                <div className="row px-0">
                    <div className="col">
                        <h1 className="display-5">Post</h1>
                        <figcaption className="blockquote-footer m-2 fs-5">by {this.state.userData.userID}</figcaption>
                    </div>
                    <div className="col-2">
                        <p>ID: {this.state.userData.id}</p>
                        
                    </div>
                </div>
                <p>{this.state.userData.title}</p>
            </div>
        );
    }
}

export default Post;