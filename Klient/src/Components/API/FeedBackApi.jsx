import Swal from "sweetalert2"
import Api from "./Api";
import jwt_decode from "jwt-decode";

export default class FeedBackApi extends Api{

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
  async SendFeedBack(text){
        try {
                const fields ={
                        TestId : sessionStorage.getItem("TestId"), 
                        UserId:parseInt(this.id),
                        Text:text,
                        Name:sessionStorage.getItem("name")
                         }
                         console.log(fields);
                const res = await this.baseAxios.post
                ('https://localhost:44323/api/feedBack',JSON.parse(JSON.stringify(fields))); 
                Swal.fire("Success", "Thank you for the your comment", "success");

                return res.status;
             } catch (error) {
               Swal.fire("Oops...", "Problem with writing feedback", "error");
             }
           }
  async GetFeedBacks(){
    const res = await this.baseAxios.get
                ('https://localhost:44323/api/feedBack/'+this.id);
                console.log(res.data);
                return res.data;
  }         
}