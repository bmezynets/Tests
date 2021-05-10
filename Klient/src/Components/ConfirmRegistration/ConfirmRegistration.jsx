import React,{Component} from 'react'
import { Form, Formik } from "formik";
import Css from '../ConfirmRegistration/ConfirmRegistration.css'
import { useParams } from "react-router-dom";
import API from "../API/AuthorizationApi"
import Swal from 'sweetalert2';


export default function ConfirmRegistration() {

        const { code } = useParams();
      
        let initialValues = {
          id: code
        }
      
      
        function onSubmit(fields){
                try{
                confirm(fields);
                Swal.fire({icon: 'success',
    title: 'Account active',
   });
                setTimeout(()=>window.location.assign("/login"),2000);  
                }
                catch(error){
                        console.log("error");
                }  
        }
      
     
        async function confirm(fields){
                try{
                var api = new API();
                console.log(fields);
                api.confirmRegistration(fields.id);
        }catch(error){
             console.log(error);
        }
}
        return (

                <Formik 
                  onSubmit={onSubmit}
                  initialValues={initialValues}
                >
                      <Form class="form">
                        <h1>Confirm you Registration</h1>
                        <div className="pt-3">
                          <button
                            type="submit"
                            className="confirm btn btn-primary"
                          >
                            Confirm
                        </button>
                        </div>
                      </Form>
                </Formik>
              );
}

