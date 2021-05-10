import React, {useEffect} from "react";
import Loader from "react-loader-spinner";
import style from "../SubjectManager/SubjectsStyle.css"
import edit from "../img/edit.png"
import back from "../img/back.png"
import TestQuestions from '../TestQuestionManager/TestQuestionManager.utils'
import styleTest from '../TestQuestionManager/TestQuestion.css'
export default function ShowDeletedQuestion(){
        const {redirectToTestModify,fetchDeletedQuestions,data,isLoading,userRole,
                restoreTestQuestion} = TestQuestions();
          useEffect(() => {fetchDeletedQuestions()},[]);  
          console.log(data);
        return(
                <div>
                {isLoading ? (
                  <div class="loader">
                    <Loader
                     type="TailSpin"
                     color="#00BFFF"
                     height={100}
                     width={100}
                   ></Loader>
                  </div>
                ) :
                   data&&userRole==="Teacher"?
                   <div class="grid-container-test">
                     <h1 style={{margin:20+'px'}}>Deleted Questions</h1>
                   {data.map( (item,index) => (
                     <div class="item-test" >
                   <p class="number" key={item.id}>{index+1}</p>
                   <p class="question" >{item.question}</p>
                      {item.option.map(items=>(
                     <div class="answers">
                      <label class="answer" for={items}>{items.option}</label>
                     </div>
                      ))} 
                     <br></br>
                     <br></br>
                     <a type="button" class="btn btn-info" onClick={()=>restoreTestQuestion(item.questionId)} >Restore</a>
                     </div>
                   ))}
                   <a type="button" class="btn btn-info" id="confirm" onClick={()=>window.location.assign("/showTestModify/"+sessionStorage.getItem("TestId"))}>
                           Back To test</a>
                 </div>
                  :<div style={{marginTop:15+'%'}}>
                    <p style={{fontSize:35+'px'}}>
                    You don't have deleted questions
                    </p>
                  </div>
                }
              </div>
                );
}