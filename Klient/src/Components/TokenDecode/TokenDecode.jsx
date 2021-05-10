
import jwt_decode from "jwt-decode";
import useState from 'react-dom'

export default function TokenDecode(){
 //const[role,setRole] = useState("");
       async function decodeToken(){
                let decoded = jwt_decode(sessionStorage.getItem("accessToken"));
               let role =  decoded[
                        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                      ];
                      console.log(role);
                      
                      
        }
        return {decodeToken};
}