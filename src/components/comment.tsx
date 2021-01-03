import * as React from "react";
import { Component } from "react";

type IProps = {
  body: string;
  email: string;
};

function Comment(props: IProps) {
  return (
    <div className="m-2 mx-4">
      {props.body}
      <p className="font-weight-bold text-lowercase">
        <b>{props.email}</b>
      </p>
    </div>
  );
}

export default Comment;
