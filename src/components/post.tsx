import * as React from "react";
import { Component } from "react";
import PostContent from "./postContent";
import Comment from "./comment";

type IProps = {
  id: number;
  title: string;
  userName: string;
  completed: boolean;
};

interface CommentObject {
  postId: number;
  id: number;
  name: string;
  email: string;
  body: string;
}

interface IState {
  postComments: CommentObject[];
  commentsVisible: boolean;
}

class Post extends Component<IProps, IState> {
  state = {
    postComments: [
      {
        postId: 0,
        id: 0,
        name: "None",
        email: "None",
        body: "None",
      },
    ],
    commentsVisible: false,
  };
  async componentDidMount() {
    const commentsResponse = await fetch(
      "https://jsonplaceholder.typicode.com/comments?postId=" + this.props.id
    );
    const postComments = await commentsResponse.json();

    this.setState({ postComments });
  }

  render() {
    return (
      <div className="border-bottom border-primary p-2">
        <PostContent
          id={this.props.id}
          title={this.props.title}
          userName={this.props.userName}
          completed={this.props.completed}
        />
        <button
          onClick={this.commentState}
          type="button"
          className="btn btn-outline-secondary"
        >
          {this.state.commentsVisible ? "Hide Comments" : "Show Comments"}
        </button>

        {this.state.commentsVisible &&
          this.state.postComments.map((comment) => (
            <Comment body={comment.body} email={comment.email} />
          ))}
      </div>
    );
  }

  /*
  * Flip whether the comments should be visible or not
  */
  private commentState = () => {
    this.setState({ commentsVisible: !this.state.commentsVisible })
  }
}

export default Post;
