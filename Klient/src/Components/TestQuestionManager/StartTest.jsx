import TestManager from '../TestQuestionManager/TestQuestionManager.utils';
import React, {useEffect} from "react";
import Loader from "react-loader-spinner";
import Api from '../API/CheckTestApi'
import Result from '../Results/Result.utils';
import { useState } from 'react';
import SingleSelectionTest from './SingleSelectionTest'
import MultipleChoicesTest from './MultipleChoicesTest'

export default function Start(){
  const {fetchTestQuestions,data,isLoading,userRole,userId} = TestManager();
  console.log(userId);
  useEffect(() => {fetchTestQuestions()},[]);
  console.log(data);  
  localStorage.setItem("CountOfQuestions",data.length);
  localStorage.setItem("xcvxc","obj");

  var test;
  if(parseInt(sessionStorage.getItem("TypeTest"))==0){
    test = <MultipleChoicesTest data={data} userId={userId} />
  }
  if(parseInt(sessionStorage.getItem("TypeTest"))==1){
    test = <SingleSelectionTest data={data} userId={userId} />
  }

        return(
               <div>
                       {test}
                    
                    </div>
                
              );
        
}