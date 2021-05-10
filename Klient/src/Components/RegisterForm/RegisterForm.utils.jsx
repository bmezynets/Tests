import * as Yup from 'yup';
import API from "../API/UserAPI"
import Swal from 'sweetalert2';
import React, { Component } from 'react';

export default function RegisterFormUser() {
        let initialValues = {
          Name: "",
          Surname: "",
          Email: "",
          Password: "",
          RoleOfUser:"0",
        };

        const validationSchema = Yup.object().shape({
          Name: Yup.string()
                  .min(3, "Too short!")
                  .max(20, "Too long!")
                  .required("Required"),
                  Surname: Yup.string()
                  .min(3, "Too short!")
                  .max(20, "Too long!")
                  .required("Required"),
                  Password: Yup.string()
                  .min(6,"Too short!")
                  .required("Required"),
                  Email: Yup.string().email("Invalid email").required("Required"),
              });
              
  function onSubmit(fields, { setSubmitting }) {
    Swal.fire({icon: 'success',
    title: 'Please check your email.',
    text: 'Confirm registration'});
    console.log(fields);
       createUser(fields, setSubmitting);  
  }
  async function createUser(fields, setSubmitting) {
    try {
      let api = new API();
      api.createUser(fields);
      setSubmitting(false);
    } catch (error) {
      console.log(error);
     }
  }
              return {
                initialValues,
                validationSchema,
                onSubmit,
              };
            }