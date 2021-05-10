import React from 'react'
import { Formik, Field, Form, ErrorMessage } from "formik";
import Swal from 'sweetalert2';
import * as Yup from 'yup';
import { useParams } from "react-router-dom";
import API from "../API/AuthorizationApi"
import css from "../ForgetPassword/ForgetPassword.css"
export default function ForgotPassword()
{
        const { id } = useParams();
        
        let initialValues = {
                Password: "",
                ConfirmPassword:"",
                code:id
              };
              const validationSchema = Yup.object().shape({
                              Password: Yup.string()
                              .min(6,"Too short!")
                              .required("Required"),
                              ConfirmPassword: Yup.string()
                              .min(6,"Too short!")
                              .required("Required")
                          });
                          function onSubmit(fields){
                                  if(fields.Password===fields.ConfirmPassword)
                                  {
                                  sendPassword(fields);
                                  }
                                   else{
                                  Swal.fire("Oops...", "Try again password weren't same", "error");
                                }
                          }
                          async function sendPassword(fields){
                                  let api = new API();
                                  api.sendPassword(fields);
                                  Swal.fire("Success","Your password changed","success")
                                  setTimeout(()=>window.location.assign("/login"),1000);
                          }

           return(
                <Formik 
                onSubmit={onSubmit}
                validationSchema={validationSchema}
                initialValues={initialValues}
                >
                                {({ errors, touched }) => {
                                  return(
                    <Form class="FormPassword">
                      <h2>Reset Password</h2>
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
            <label>Confirm Password</label>
            <Field
              name="ConfirmPassword"
              type="password"
              className={
                "form-control" +
                (errors.Password && touched.Password
                  ? " is-invalid"
                  : "")
              }
            />
            <ErrorMessage
              name="ConfirmPassword"
              component="div"
              className="invalid-feedback"
            />
                      <div className="pt-3">
                        <button
                          type="submit"
                          className="confirm btn btn-primary"
                        >
                          Confirm
                      </button>
                      </div>
                    </Form>
                    
                    );
                    }
                    }
              </Formik>
           );
}
