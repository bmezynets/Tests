import React, { useEffect,Component } from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom";
import { Formik, Field, Form, ErrorMessage } from "formik";
import RegisterFormUser from '../RegisterForm/RegisterForm.utils'
import style from '../RegisterForm/RegisterForm.css'
const {
  initialValues,
  validationSchema,
  onSubmit,
} = RegisterFormUser();
export default class RegisterUser extends Component{
    isTrue = false;
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
            <h1>Register</h1>

            <label>First Name</label>
            <Field
              name="Name"
              className={
                "form-control" +
                (errors.Name && touched.Name ? " is-invalid" : "")
              }
            />
            <ErrorMessage
              name="Name"
              component="div"
              className="invalid-feedback"
            />

            <label>Last Name</label>
            <Field
              name="Surname"
              type="text"
              className={
                "form-control" +
                (errors.Surname && touched.Surname ? " is-invalid" : "")
              }
            />
            <ErrorMessage
              name="Surname"
              component="div"
              className="invalid-feedback"
            />

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
              type="password"
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
            <br></br>
            <Field as="select" name="RoleOfUser" class="form-control">
                            <option value="0">User</option>
                            <option value="1">Teacher</option>
                          </Field>
                          <ErrorMessage
              name="RoleOfUser"
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
            </div>
          </Form>
        );
            }
      }
    </Formik>
  );
}
 
}