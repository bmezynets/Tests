import * as Yup from 'yup';
import API from "../API/AuthorizationApi"
import Swal from 'sweetalert2';


export default function EmailToReset() {
        let initialValues = {
          Email: ""

        };

const validationSchema = Yup.object().shape({
                Email: Yup.string().email("Invalid email").required("Required"),
            });
            
            function onSubmit(fields){
                Swal.fire({icon: 'success',
                title: 'Please check your email.',
                text: 'Confirm registration'});
                setTimeout(()=>window.location.assign("/home"),2000);  
                EmailResetPassword(fields);
            }
            async function EmailResetPassword(fields, setSubmitting) {
                try {
                  let api = new API();
                  api.EmailToResetPassword(fields);
                } catch (error) {
                  console.log(error);
                 }
              }
              return{
                      onSubmit,
                      validationSchema,
                      initialValues
              };
        }