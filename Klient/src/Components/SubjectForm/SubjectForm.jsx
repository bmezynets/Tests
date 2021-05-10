import React,{Component} from 'react'
import { Formik, Field, Form, ErrorMessage } from "formik";
import SubjectForm from '../SubjectForm/SubjectForm.utils'
 

const {
        initialValues,
        validationSchema,
        onSubmit,
      } = SubjectForm();

export default class Subject extends Component{
    
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
                          <h1>Add Subject</h1>
              
                          <label>Title</label>
                          <Field
                            name="Name"
                            maxlenght="6"
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
