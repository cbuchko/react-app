import * as React from 'react';
import { Component } from 'react';

type MyProps = {
    userId: number,
    id: number,
    title: string,
    completed: boolean
}

class Post extends Component<MyProps, {}> {

    render(){

        return(
            <div className="container-sm border-bottom border-primary px-0 w-50 p-2">
                <div className="row px-0">
                    <div className="col">
                        <h1 className="display-5">Post</h1>
                        <figcaption className="blockquote-footer m-2 fs-5">by {this.props.userId}</figcaption>
                    </div>
                    <div className="col-2">
                        <p>ID: {this.props.id}</p>                      
                    </div>
                </div>
                <p>{this.props.title}</p>
            </div>
        );
    }
}

export default Post;