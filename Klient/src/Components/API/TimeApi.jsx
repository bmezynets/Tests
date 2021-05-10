import Swal from "sweetalert2"
import Api from "./Api";
import axios from 'axios'

export default class TImeApi extends Api{

        constructor()
        {
          super();
        }

        async registerTime(userId){
                
                try{   
                        const time ={
                        UserId:parseInt(userId),
                        TestId : sessionStorage.getItem("TestId") 
                         }
                    const registeredTime = await this.baseAxios
                    .post('https://localhost:44323/api/time',time)
                        }catch (error) {
                                Swal.fire("Oops...","Time not set")
                              }
        }

}