import Swal from "sweetalert2"
import Api from "./Api";
import axios from 'axios'
import jwt_decode from "jwt-decode";

export default class TestApi extends Api{

        constructor(){
                super();
                let decoded=null;
                this.id=null;
                this.role="";
               if(sessionStorage.getItem("accessToken")!==null){
                decoded = jwt_decode(sessionStorage.getItem("accessToken"));
               this.id =  decoded[
                       "sub"
                     ]; 
                     this.role =  decoded[
                      "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                    ]; 
                  }
        }
        async AllTests(id){
                try{
                  if(this.role==="User"||sessionStorage.getItem("accessToken")==null){
                const res = await this.baseAxios.get('https://localhost:44323/api/test/'+id)
                return res.data;
                  }else if(this.role==="Teacher"){
                    const res = await this.baseAxios
                    .get('https://localhost:44323/api/test/teachersTests/'+id)
                    return res.data;
                  }
                }
                catch (error) {
                        Swal.fire("Oops...", "You don't have anyone test", "error");
                      }
        }
        async registerTest(field){
                try{
                        const res = await this.baseAxios.post('https://localhost:44323/api/test/register/'+this.id,field)
                        Swal.fire({icon: 'success',
                        title: 'You have added test',
                        title:'You have added test'});
                        setTimeout(()=>window.location.assign("/tests/"+sessionStorage.getItem("TopicId")),1000);
                        return res.data;
                        }catch (error) {
                                Swal.fire("Oops...","Something wrong")
                              }
        }
         
        async EditTest(fields) {
                try {
                        console.log(fields);
                   const res = await this.baseAxios.patch('https://localhost:44323/api/test/editTest',fields)  
                   Swal.fire({icon: 'success',
                            title: 'You have edit test',
                            title:'You have edit test'});
                            setTimeout(()=>window.location.assign("/tests/"+sessionStorage.getItem("TopicId")),1000);
               
                  return res.data;
                } catch (error) {
                  Swal.fire("Oops...", "You don't have anyone test", "error");
                }
              }
              delete = async (id) => {
                let api = new Api();
                await this.basAxios.delete('https://localhost:44323/api/test/'+id)  
              }   
              async DeleteTest(id){
                try {
                   Swal.fire({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
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
                        'Your file has been deleted.',
                        'success'
                      )
                      setTimeout(()=>window.location.assign("/tests/"+sessionStorage.getItem("SubjectId")),1000);
                    }
            
                  })
                        
               } catch (error) {
                 Swal.fire("Oops...", "You don't have anyone subject", "error");
               }
              
}
}