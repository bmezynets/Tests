import React from 'react'
import { Form, Formik,Field,ErrorMessage } from "formik";
import { useParams } from "react-router-dom";
import API from "../API/SubjectApi"
import Swal from 'sweetalert2';
import {Button } from "reactstrap";
import { useEffect } from 'react';
import * as Yup from 'yup';

export default function EditSubject() {
  const { id } = useParams();
        let initialValues = {
          Code: id,
          name:sessionStorage.getItem("SubjectName")
        }
        const validationSchema = Yup.object().shape({
          name: Yup.string()
                  .min(1, "Too short!")
                  .max(17, "Too long!")
                  .required("Required"),
              }
              
              )
        function onSubmit(fields){
                try{
                        console.log(fields);
                        EditSubject(fields);
                }
                catch(error){
                        console.log("error");
                }  
        }
        async function EditSubject(fields){
            let api = new API();
            api.EditSubject(fields);
        }
        return (

                <Formik 
                  onSubmit={onSubmit}
                  initialValues={initialValues}
                  validationSchema={validationSchema}
                >
                                          {({ errors, touched }) => {
                        return(
                      <Form class="editSubject">
                        <h1>Edit Subject</h1>
                        <br></br>
                        <Field
                                name="name"
                                className={
                                  "form-control" +
                                  (errors.name && touched.name ? " is-invalid" : "")
                                }
                              />
                              <ErrorMessage
                                name="name"
                                component="div"
                                className="invalid-feedback"
                              />
                        <div className="pt-3">
                          <button
                            type="submit"
                            className="confirm btn btn-primary"
                          >
                            Edit
                        </button>
                        </div>
                      </Form>
                        )}}
                </Formik>
              );

}