import React, { useMemo, useState } from "react";
import Api from '../API/TestQuestionsApi'
import TimeApi from '../API/TimeApi'
import Alert from 'react-bootstrap/Alert'
import jwt_decode from "jwt-decode";
import API from '../API/TestQuestionsApi'

export default function TestManager() {
 async function SendFile(filePath){
         let api = new Api();
         api.SendTestQuestions(filePath);
 }
 
 const[data,setdata] = useState([]);
 const [isLoading, setIsLoading] = useState(false);
 const [userRole,setRole] = useState();
 const[userId,setUserId]=useState();
 const[question,setQuestion]=useState();

 async function fetchTestQuestions() {
        try
        {
      let api = new Api();
      setIsLoading(true);
      let decoded=null;
      let role=null;
      let userId=null;
      if(sessionStorage.getItem("accessToken")!==null){
      decoded = jwt_decode(sessionStorage.getItem("accessToken"));
      role =  decoded[
          "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        ];
        userId=decoded[
          "sub"
        ] ;
       }
       console.log("decode",decoded);
      setRole(role);
      setUserId(userId);
      const res = await api.fetchTestQuestions(userId);
      console.log(res);
      setdata(res);
      setIsLoading(false);
      console.log(data);

        }
        catch(error)
        {
            console.log(error);
        }
    }
    async function redirectToEditTestQuestionsAnswer(id,subjectName,option){
      console.log(subjectName);
      let api = new API();
      sessionStorage.setItem("QuestionId",id);
      const result =  await api.GetTestQuestion();
      console.log(result);
      var arr = ['Test','OptionA','OptionB','OptionC']; 
      var index=0;  
      sessionStorage.setItem("SubjectName",subjectName);
         option.map((item,index)=>(
          sessionStorage.setItem(arr[index+1],item.option)
         ))
        sessionStorage.setItem('isCorrectA',result.data.isCorrectA);
        sessionStorage.setItem('isCorrectB',result.data.isCorrectB);
        sessionStorage.setItem('isCorrectC',result.data.isCorrectC);
        if(parseInt(sessionStorage.getItem("TypeTest"))== 0){
         window.location.assign("/editTestQuestions/"+id);
        }
        else if(parseInt(sessionStorage.getItem("TypeTest"))== 1){
        window.location.assign("/editTestQuestionsSingle/"+id);
      }

    }
    async function redirectToTests(){
      window.location.assign("/tests/"+sessionStorage.getItem("TestId"));
    }

    async function redirectToDeletedQuestions(){
      window.location.assign("/showDeletedQuestions/"+sessionStorage.getItem("TestId"));
    }
    async function redirectToTestModify(id,type){
      sessionStorage.setItem("TestId",id);
      sessionStorage.setItem("TypeTest",type)
      window.location.assign("/showTestModify/"+sessionStorage.getItem("TestId"));
    }
    async function redirectToStartTest(id){
      localStorage.clear();
      if(sessionStorage.getItem("accessToken")===null){
          setTimeout(()=>window.location.assign("/login"),200);
      }
      else{
        let decoded=null;
        let role=null;
        let userId=null;
        if(sessionStorage.getItem("accessToken")!==null){
        decoded = jwt_decode(sessionStorage.getItem("accessToken"));
        role =  decoded[
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
          ];
          userId=decoded[
            "sub"
          ] ;
         }
      let api = new TimeApi();
      await api.registerTime(userId);
      sessionStorage.setItem("TestId",id);
      sessionStorage.setItem("NumberOfQuestion",0);
      window.location.assign("/test/"+sessionStorage.getItem("TestId"));
      }
    }
    async function redirectToAddQuestion(){
      if(parseInt(sessionStorage.getItem("TypeTest"))== 0)
      {
      window.location.assign("/addTestQuestion");
      }
      else if(parseInt(sessionStorage.getItem("TypeTest"))==1)
      {
      window.location.assign("/addTestQuestionSingleTest");
      }
    }
    async function deleteTestQuestion(id){
      let api = new Api();
      api.DeleteTestQuestion(id);
    }
    async function restoreTestQuestion(id){
      let api = new Api();
      api.restoreTestQuestion(id);
      window.location.reload(false);
        }
    async function fetchDeletedQuestions(){
      try
      {
    let api = new Api();
    setIsLoading(true);
    let decoded=null;
    let role=null;
if(sessionStorage.getItem("accessToken")!==null){
 decoded = jwt_decode(sessionStorage.getItem("accessToken"));
role =  decoded[
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
      ]; 
     }
    setRole(role);
    const res = await api.showDeletedQuestions (sessionStorage.getItem("TestId"));
    console.log(res);
    setdata(res);
    setIsLoading(false);
    console.log(data);

      }
      catch(error)
      {
          console.log(error);
      }
    }
 return {
   SendFile,fetchTestQuestions,restoreTestQuestion,redirectToTestModify,redirectToEditTestQuestionsAnswer,
  redirectToDeletedQuestions, deleteTestQuestion,redirectToTests,fetchDeletedQuestions,data,isLoading,userRole,userId,
  redirectToAddQuestion,redirectToStartTest
};
}