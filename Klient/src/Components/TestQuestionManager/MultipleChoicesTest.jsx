import { Formik, Field, Form, ErrorMessage } from "formik";
import React, {useEffect} from "react";
import Api from '../API/CheckTestApi'
import { useState } from 'react';
import TestManager from './TestQuestionManager.utils'
import Swal from "sweetalert2"
import Timer from '../Timer/TimerRemaining'
import * as Yup from 'yup';

export default function SingleSelectionTest(props){
        let[ans_one,setFirstChecked]=useState(false)
        let[ans_second,setSecondChecked]=useState(false)
        let[ans_third,setThirdChecked]=useState(false)
        let[questionId,setId]=useState();
        let initialValues={
          QuestionId:sessionStorage.getItem("QuestionId"),
          UserId:props.userId,
          isCorrectA:ans_one,
          isCorrectB:ans_second,
          isCorrectC:ans_third
       };

        function NextQuestion(){
          if(initialValues.isCorrectA!==false
            ||initialValues.isCorrectB!==false
            ||initialValues.isCorrectC!==false){
        let number = sessionStorage.getItem("NumberOfQuestion");
        sessionStorage.setItem("PreviousQuestion",number);
        ++number;
        sessionStorage.setItem("NumberOfQuestion",number);
            }
            else{
              Swal.fire({icon: 'warning',
              title:'Warning',
               text:'Please set a true answer'});
            }

      }
  
      function PreviousQuestion(){
        let number = sessionStorage.getItem("NumberOfQuestion");
        sessionStorage.setItem("PreviousQuestion",number);
        --number;
        if(number<0){
          sessionStorage.setItem("NumberOfQuestion",number);
         }
        else{
         sessionStorage.setItem("NumberOfQuestion",number);
        }
      }
             function singleSelection(a){
             if(a===1){
              setFirstChecked(true);
             }
             else if(a==2){
              setSecondChecked(true);
             }
             else if(a==3){
              setThirdChecked(true);
             }  
               }

               function onSubmit(fields){
                let api = new Api();
                    let obj = JSON.stringify(fields);
                    if(parseInt(sessionStorage.getItem("NumberOfQuestion"))===-1){
                      sessionStorage.setItem("NumberOfQuestion",0)
                    }
                    else{
                      if(parseInt(sessionStorage.getItem("NumberOfQuestion"))
                      <parseInt(sessionStorage.getItem("PreviousQuestion"))){
                      
                      localStorage.setItem("xcvxc",obj);

                      }
                      else{
                        if(initialValues.isCorrectA!==false
                          ||initialValues.isCorrectB!==false
                          ||initialValues.isCorrectC!==false){
                        localStorage.setItem(parseInt(sessionStorage.getItem("NumberOfQuestion")-1),obj);
                          }
                      }

                    }
                    if(parseInt(localStorage.getItem("CountOfQuestions")) 
                    === parseInt(sessionStorage.getItem("NumberOfQuestion"))){
                      Swal.fire({
                        title: 'Are you ready to finish the test?',
                        icon: 'warning',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Finished'
                      }).then((result) => {
                        if (result.isConfirmed) {
                          Swal.fire(
                            'Finished!',
                            'Your test has been finished.',
                            'success'
                          )
                          let list = new Array();
                          for(var i = localStorage.length-2 ;i>0;i--)
                          {
                            list.push(JSON.parse(localStorage.getItem(i-1)))
                          }
                          api.SendToCheckTest(list);
                          }
                          
                          else{
                            sessionStorage.setItem("NumberOfQuestion",sessionStorage.getItem("NumberOfQuestion")-1)
                          }
                     
                   })
                   }
                   else{

                    sessionStorage.setItem("NumberOfQuestion",sessionStorage.getItem("NumberOfQuestion"))
                    let question = localStorage.getItem(sessionStorage.getItem("NumberOfQuestion"));
                    let ques = JSON.parse(question);
                    console.log(ques);
                    if(ques===null){
                      setFirstChecked(false);
                      setSecondChecked(false);
                      setThirdChecked(false); 
                    }
                    else{
                    setFirstChecked(ques.isCorrectA);
                    setSecondChecked(ques.isCorrectB);
                    setThirdChecked(ques.isCorrectC);
                    setId(ques.QuestionId); 
                    }     
                  }
                  
                 }

      return(
        <div>
        <div>
           <Timer userId={props.userId}></Timer>
        </div>
        <div class="grid-container-Starttest">
        {props.data.map( (item,index) => {
             
            
                if(index===parseInt(sessionStorage.getItem("NumberOfQuestion"))){
                  sessionStorage.setItem("QuestionId",item.questionId);
                                          
         return( 
           
         <div class="item-Starttest" >
           <Formik
            initialValues={initialValues}
            onSubmit={onSubmit}
            enableReinitialize={true}
           > 
                              {({ errors, touched }) => {
                                return(
             <Form>
               <p class="number" >{index+1}</p>
                <p class="question-test" >{item.question}</p>
                {item.option.map( (items,index_items) =>{
                  if(index_items===0){
                 return(
                 <div class="answers-test">
                      <label class="answer-test">{items.option}</label>
                     <Field 
                      type="checkbox"
                      onClick={()=>singleSelection(1)}
                        name="isCorrectA"
                        className={
                          "info-test" +
                          (errors.isCorrectA && touched.isCorrectA ? " is-invalid" : "")
                        }
                      />                
               </div>
                 )
                  }
                  if(index_items===1){
                   return( 
                   <div class="answers-test">
                    <label class="answer-test">{items.option}</label>
                    <Field 
                      type="checkbox"
                        onClick={()=>singleSelection(2)}
                        name="isCorrectB"
                        className={
                          "info-test" +
                          (errors.isCorrectB && touched.isCorrectB ? " is-invalid" : "")
                        }
                      />
                      
                  
                 </div>
                   )
                    }
                    if(index_items===2){
                     return( <div class="answers-test">
                          <label class="answer-test">{items.option}</label>
                          <Field
                        type="checkbox"
                        onClick={()=>singleSelection(3)}
                        name="isCorrectC"
                        className={
                          "info-test" +
                          (errors.isCorrectC && touched.isCorrectC ? " is-invalid" : "")
                        }
                      />
                    
                   </div>
                     )
                      }
                })}
              <br></br>
              <button
               style={{border:0+'px',paddingBottom:15+'px'}}
               id="buttonPrevious"
               onClick={()=>PreviousQuestion()}
             >
               Previous
             </button>
     
          <button 
               style={{border:0+'px',paddingBottom:15+'px'}}
               type="submit"
               id="buttonNext"
               onClick={()=>NextQuestion()}
             >
               Next
             </button>
            
             </Form>
                                );
              }        
            }        
           </Formik>
     </div>
        )          
      } 
})}
    </div>
    </div>
      )

}