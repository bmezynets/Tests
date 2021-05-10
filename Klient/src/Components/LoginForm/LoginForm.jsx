import React, { useEffect,Component } from "react";
import { Link } from "react-router-dom";
import { Formik, Field, Form, ErrorMessage } from "formik";
import Login from '../LoginForm/Login.utils'
import style from '../LoginForm/Login.css'

const {
        initialValues,
        validationSchema,
        onSubmit,
      } = Login();

export default class LoginUser extends Component{
        isTrue = false;
     // constructor(){
     //   i
     // }
         constructor(props){
           super();
           this.styles = props.style;
         }
    render(){
      return (
    
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          enableReinitialize
          onSubmit={onSubmit}
        >
          {({ errors, touched }) => {
            return (
              <Form className={this.styles}>
                <h1>Sign in</h1>

                <label>Email</label>
                <Field
                  name="Email"
                  type="text"
                  className={
                    "form-control" +
                    (errors.email && touched.email ? " is-invalid" : "")
                  }
                />
                <ErrorMessage
                  name="Email"
                  component="div"
                  className="invalid-feedback"
                />
    
                <label>Password</label>
                <Field
                  name="Password"
                  className={
                    "form-control" +
                    (errors.Password && touched.Password
                      ? " is-invalid"
                      : "")
                  }
                />
                <ErrorMessage
                  name="Password"
                  component="div"
                  className="invalid-feedback"
                />
                <div className="pt-3">
                  <button
                    type="submit"
                    className="btn btn-primary"
                  >
                    Save
                  </button>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <a role="button " class="btn btn-danger" href="http://localhost:3000/home">     
              Cancel
              </a>
                  <br></br>
                  <a style={{color:"green"}}href="http://localhost:3000/register">
                If dont't have an account
              </a>
              <br></br>
              <a style={{color:"red"}}href="http://localhost:3000/reset">
                 Forgot password
              </a>
                </div>
              </Form>
            );
                }
          }
        </Formik>
      );
    }
}