import TestManager from '../TestQuestionManager/TestQuestionManager.utils';
import React, {useEffect} from "react";
import Loader from "react-loader-spinner";


export default function Rewiew(){
  let list = new Array();
  
 const {fetchTestQuestions,data,isLoading,userRole} = TestManager();
 useEffect(() => {fetchTestQuestions()},[]);  
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
        ):(data&&userRole==="User"? 
        <div class="grid-container-Starttest">
        {data.map( (item,index) => {
          console.log(index);
            let i = index;
            let a = JSON.parse(localStorage.getItem(i));
            console.log(a);
         return( 
          <div class="item-Starttest">
            <p class="number" key={item.id}>{index+1}</p>
            <p class="question">{item.question}</p>
           {item.option.map((items,index)=>{
             if(index===0){
           
            
            if(items.isCorrect==true)
            {
              return(
                <div class="answers">
           <p class="answer_true">{items.option}</p>
           </div>
                    )             
            }
            if(a==undefined||a==null)
            {
              return(
                <div></div>
              )
            }
            else if(a.isCorrectA!==items.isCorrect){
              return(
                <div class="answers">
           <p class="answer_false">{items.option}</p>
           </div>
                    )   
            
          }
        }
          if(index===1){
            if(items.isCorrect==true){
              return(
                <div class="answers">
                    <p class="answer_true">{items.option}</p>
                 </div> 
              )
            }
            if(a==undefined||a==null)
            {
              return(
                <div></div>
              )
            }
            if(a.isCorrectB!==items.isCorrect){
              return(
                <div class="answers">
           <p class="answer_false">{items.option}</p>
           </div>
                    )   
            }
          }
          if(index===2){
            if(items.isCorrect==true){
              return(
                <div class="answers">
          <p class="answer_true">{items.option}</p>
                 </div> 
                   )
            }
            if(a==undefined||a==null)
            {
              return(
                <div></div>
              )
            }
            if(a.isCorrectC !==items.isCorrect)
            {
              return(
                <div class="answers">
           <p class="answer_false">{items.option}</p>
                 </div>
               )             
            }
          }
           if(items.isCorrect==true){
               return(
           <p class="answer_true">{items.option}</p>
               )
             }
             else{
               return(
                <div class="answers">
              <p class="answer">{items.option}</p>
              </div>
               ) 
            }
        }

        )}
            </div>
        )          
      } 
)}
<button style={{marginLeft:50+'%',marginTop:30+'px',fontSize:30+'px'}}class="btn btn-info" 
onClick={()=>window.location.assign("/result")}
>Back</button>
    </div>
     :<div>   </div>
         )
         
     }
   </div>
   );
        }

