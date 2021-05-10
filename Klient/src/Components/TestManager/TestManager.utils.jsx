import React, { useMemo, useState } from "react";
import{useParams} from "react-router-dom"
import Api from '../API/TestApi'
import jwt_decode from "jwt-decode";

export default function TestManager() {

        const[isLoading,setIsLoading] = useState(false);
        const[data,setdata] = useState([]);
        const[userRole,setRole]=useState();

        //const { id } = useParams();

        async function AllTests(){
                
                let api = new Api();
                setIsLoading(true);
                let res = await api.AllTests(sessionStorage.getItem("SubjectId"));
                let decoded=null;
                let role = null;
                if(sessionStorage.getItem("accessToken")!==null){
                  decoded = jwt_decode(sessionStorage.getItem("accessToken"));
                 role =  decoded[
                         "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                       ]; 
                       console.log(role);
                 }
                  setRole(role);
                 setdata(res);
                console.log(res);
                setIsLoading(false);

        }
        async function deleteTest(id){
                let api = new Api();
                api.DeleteTest(id);
              }
        async function redirectToEditTest(id,name,type,info,time){
                sessionStorage.setItem("TestName",name);
                sessionStorage.setItem("TypeTest",type);
                sessionStorage.setItem("Time",time);
                sessionStorage.setItem("Info",info)
             window.location.assign("/editTest/"+id);
        }
        async function redirectToTests(id){
                sessionStorage.setItem("SubjectId",id);
                window.location.assign("/tests/"+id);
           }
           async function redirectToAddQuestions(id){
                sessionStorage.setItem("TestId",id);
                window.location.assign("/addTestQuestions/"+id);
           }
        return{redirectToEditTest,userRole,redirectToTests,AllTests,deleteTest,redirectToAddQuestions,isLoading,data};
}