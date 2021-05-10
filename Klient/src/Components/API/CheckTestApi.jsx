import Swal from "sweetalert2"
import Api from "./Api";
export default class TestQuestionApi extends Api{

  constructor()
  {
    super();
  }
  async SendToCheckTest(fields) {
        try {
           const res = await this.baseAxios.post
           ('https://localhost:44323/api/checkTest/'+sessionStorage.getItem("TestId"),fields); 
           console.log(res.status);
           if(res.status==200){
             window.location.assign("/result")
           }
           return res.status;
        } catch (error) {
          Swal.fire("Oops...", "Problem with writing test", "error");
        }
      }
      async GetResultOfTest(userId){
        try{            
          const res = await this.baseAxios.get(
            'https://localhost:44323/api/checkTest/'+userId
          )
          return res;
        }catch(error){
          Swal.fire("Oops...", "Please try again", "error");

        }
      }
      async GetResultsOfTest(userId){
        try{            
          const res = await this.baseAxios.get(
            'https://localhost:44323/api/checkTest/profile/'+userId
          )
          return res;
        }catch(error){
          Swal.fire("Oops...", "Please try again", "error");

        }
      }
}