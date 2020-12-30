import * as React from 'react';
import { Component } from 'react';

type IProps = {   
    id: number,
    title: string,
    userName: string,
    completed: boolean
}

function Post(props: IProps){

   return(

        <div className="border-bottom border-primary p-2">
            <div className="row px-0">
                <div className="col">
                    <h1 className="display-5">Post</h1>
                    <figcaption className="blockquote-footer m-2 fs-5">by {props.userName}</figcaption>
                </div>
                <div className="col-2">
                    <p>ID: {props.id}</p>                      
                </div>
            </div>
            <p>{props.title}</p>
        </div>

    );   
}

export default Post;