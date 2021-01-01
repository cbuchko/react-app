import * as React from 'react';
import { Component } from 'react';

type IProps = {   
    body: string
}

function Comment(props: IProps){

    return(
        <div className="m-2 mx-4">
            {props.body}
        </div>
    )
}

export default Comment;