import Swal from "sweetalert2"
import Api from "./Api";
import axios from 'axios'
export default class AuthorizationApi {

  constructor()
  {
  }
  async fetchUsers() {
    try {
       const res = await axios.get('https://localhost:44323/api/authorize/getUsers');     
      return res.data;
    } catch (error) {
      Swal.fire("Oops...", "You don't have anyone users", "error");
    }
  }

  async signIn(params) {
        try {
          const response = await axios.post(
            "https://localhost:44323/api/authorize/signIn",
             params
          );
          Swal.fire("Success", "Success", "success");
                    return response.data;
        } catch (error) {
          Swal.fire("OOps","Password/Login not correct","Bad password");
        }
      }
  async  confirmRegistration(id) {
      try {
        console.log("code");
        const response = await axios.patch(
          "https://localhost:44323/api/authorize/"+id);
          return response.data;
    }catch(error){
      console.log(error);
    }     
  }
  async  EmailToResetPassword(fields) {
    try {
      console.log(fields.Email);
      const response = await axios.post(
        "https://localhost:44323/api/authorize",fields);
        return response.data;
      }catch(error){
    console.log(error);
      }   
  }
  async sendPassword(fields) {
    try {
      const response = await axios.patch(
        "https://localhost:44323/api/authorize/forgotPassword/"+fields.code,fields);
        return response.data;
      }catch(error){
    console.log(error);
      }   
  }
  delete = async (id) => {
    let api = new Api();
    await axios.patch(
      "https://localhost:44323/api/authorize/delete/"+id,parseInt(id))
      }  
  async deleteAccount(id){
    try {
    Swal.fire({
          title: 'Are you sure?',
          text: "You won't be able to delete account!",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
          if (result.isConfirmed) {
            this.delete(id);
            Swal.fire(
              'Deleted!',
              'Your account has been deleted.',
              'success'
            )
          }
          window.location.reload(false);
  
        })    
     } catch (error) {
       Swal.fire("Oops...", "You can't delete account", "error");
     }
  }
  async Active(id){
    try{
      await axios.patch(
        "https://localhost:44323/api/authorize/active/"+id,parseInt(id)) 
         window.location.reload(false);
            }  
    catch(error){
      Swal.fire("Oops...", "You can't activate account", "error");
    }
  }
}
