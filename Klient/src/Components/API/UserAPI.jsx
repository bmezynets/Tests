import Swal from "sweetalert2"
import Api from "./Api"
import axios from 'axios'
export default class UserApi{
  
  constructor(){
  }

        async createUser(params) {
            try {
             
              await axios.post('https://localhost:44323/api/authorize/register',params)
              Swal.fire("Success", "Email has been sent. Please confirm your registration", "success");
            } catch (error) {
              window.location.assign("/errorConnection")
            }
            setTimeout(()=>window.location.assign("/home"),2000);  
          }  
        }    