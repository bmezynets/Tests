import * as Yup from 'yup';
import API from "../API/UserAPI"
import React, { Component } from 'react';
import Swal from 'sweetalert2';
import Api from '../API/AuthorizationApi';
import jwt_decode from "jwt-decode";

export default function Login() {
        let initialValues = {
          Email: "",
          Password: "",
        };
        const validationSchema = Yup.object().shape({
                  Password: Yup.string()
                  .required("Required"),
                  Email: Yup.string().email("Invalid email").required("Required"),
              });
              
              function onSubmit(fields, { setSubmitting }) {  
                signIn(fields)
              }
              async function signIn(params) {
                try{
                    let api = new Api();
                    const response = await api.signIn(params);
                    console.log(response);
                    if (response.code===200) {
                      let decodedToken = jwt_decode(response.accessToken);  
                       let role =  decodedToken[
                          "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                        ]
                      sessionStorage.setItem("name","Hi, "+response.name);
                      sessionStorage.setItem("accessToken", response.accessToken);
                      sessionStorage.setItem("refreshToken", response.refreshToken);
                      switch (role) {
                        case "User":
                          setTimeout(()=>window.location.assign("http://localhost:3000/home"),2000);
                          break;
                          case "Teacher":
                            setTimeout(()=>window.location.assign("http://localhost:3000/home"),2000);
                            break;
                        case "Admin":
                          setTimeout(()=>window.location.assign("http://localhost:3000/home"),2000);
                          break;
                        default:
                          throw new Error("Bad response from server");
                      }
                    }
                  }
                catch(error){
                  //Swal.fire("OOps",error.message,"Bad password");
                }
              }
              return {
                initialValues,
                validationSchema,
                onSubmit,
              };
      }