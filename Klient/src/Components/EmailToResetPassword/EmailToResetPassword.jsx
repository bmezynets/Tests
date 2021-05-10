import { render } from '@testing-library/react'
import React,{Component} from 'react'
import { Formik, Field, Form, ErrorMessage } from "formik";
import EmailToReset from '../EmailToResetPassword/EmailToResetPassword.utils'


const{
        initialValues,
        validationSchema,
        onSubmit
} =EmailToReset();

export default class EmailToResetPassword extends Component{
        constructor(props){
                super();
                this.styles = props.style;
              }


        render(){
                return(
                        <Formik
                        initialValues={initialValues}
                        validationSchema={validationSchema}
                        onSubmit={onSubmit}
                      >
                                    {({ errors, touched }) => {
                          return (
                            <Form className={this.styles}>
                              <h2>Account Recovery</h2>
                              <p style={{fontSize:16+'px',fontWeight:400,lineHeight:1.5,letterSpacing:1}}>Recover your account<br></br>Please enter your email</p>
                              <Field
                                name="Email"
                                className={
                                  "form-control" +
                                  (errors.Email && touched.Email
                                    ? " is-invalid"
                                    : "")
                                }
                              />
                              <ErrorMessage
                                name="Email"
                                component="div"
                                className="invalid-feedback"
                              />
                              <div className="pt-3">
                                <button
                                 style={{fontSize:20+'px'}}
                                  type="submit"
                                  className="btn btn-primary"
                                >
                                  Send
                                </button>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <a role="button " style={{fontSize:20+'px'}} class="btn btn-danger" href="http://localhost:3000/home">     
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