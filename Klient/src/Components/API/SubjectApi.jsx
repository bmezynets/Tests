  import Swal from "sweetalert2"
  import Api from "./Api";
  import axios from 'axios'
  import jwt_decode from "jwt-decode";

  export default class SubjectApi extends Api{

  constructor()
  {
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
  async createSubject(params) {
        try {
                await this.baseAxios.post('https://localhost:44323/api/subject/registerSubject/'+this.id,params)
                Swal.fire({icon: 'success',
                title: 'You have added subject',
                title:'You have added subject'});
                setTimeout(()=>window.location.assign("/subjects"),1000);
              } catch (error) {
                Swal.fire("Oops...","Something wrong")
              }
  }
  
  async fetchSubjects() {
    
    try {
       if(this.role==="User"){
       const res = await this.baseAxios.get('https://localhost:44323/api/subject/getAll'); 
       return res.data;
       }else if(this.role==="Teacher"){
        const res = await this.baseAxios.get('https://localhost:44323/api/subject/getTeacherSubjects/'+this.id); 
        return res.data;
       }
    } catch (error) {
      Swal.fire("Oops...", "You don't have anyone subject", "error");
    }
  }
  async fetchSubjectsTests() {
    try {
       const res = await this.baseAxios.get('https://localhost:44323/api/subject/getAllTests');     
      return res.data;
    } catch (error) {
      Swal.fire("Oops...", "You don't have anyone subject", "error");
    }
  }
  
  async EditSubject(fields) {
    try {
       const res = await this.baseAxios.patch('https://localhost:44323/api/subject/editSubject/'+fields.Code,fields)  
       Swal.fire({icon: 'success',
                title: 'You have edit subject',
                title:'You have edit subject'});
                setTimeout(()=>window.location.assign("/subjects"),1000);
   
      return res.data;
    } catch (error) {
      Swal.fire("Oops...", "You don't have anyone subject", "error");
    }
  }
  delete = async (id) => {
    let api = new Api();
    await this.baseAxios.delete('https://localhost:44323/api/subject/delete/'+id) ;
  }    
  async DeleteSubject(id){
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
          try{ 
          this.delete(id);
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          )
          setTimeout(()=>window.location.assign("/subjects"),1000);
          }catch(Exception){
            Swal.fire("Oops...", "You don't have anyone subject", "error");
          
          }
        }

      })
    
  
}
}