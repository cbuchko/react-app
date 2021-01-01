import * as React from 'react';
import { Component } from 'react';

type IProps = {   
    id: number,
    title: string,
    userName: string,
    completed: boolean
}

class PostContent extends Component<IProps, {}> {

    render(){

        return(           
            <React.StrictMode>
                <div className="row px-0">
                    <div className="col">
                        <h1 className="display-5">Post</h1>
                        <figcaption className="blockquote-footer m-2 fs-5">by {this.props.userName}</figcaption>
                    </div>
                    <div className="col-2">
                        <p>ID: {this.props.id}</p>                      
                    </div>
                </div>
                <p>{this.props.title}</p>
            </React.StrictMode>           
        );
    }
}

export default PostContent;