import React, { useEffect ,useState} from 'react';
import TestManager from "../TestManager/TestManager.utils";
import TestQuestionManager from '../TestQuestionManager/TestQuestionManager.utils'
import Loader from "react-loader-spinner";
import plus from "../img/plus.png"
import edit from "../img/edit.png"
export default function AllTests(){
const {data,isLoading,userRole,redirectToEditTest,AllTests,deleteTest} = TestManager();
const{redirectToTestModify,redirectToStartTest}=TestQuestionManager();

useEffect(() => {AllTests()},[]);  

const [info,setInfo] =useState("")
const [name,setData] =useState()
const [id,setId] =useState(0)
const[style,setStyle]=useState("");
console.log(data);

function Change(info,name,id,typeOfTest){
  console.log(info);
  setInfo(info)
  setData(name)
  setId(id);
  sessionStorage.setItem("TypeTest",typeOfTest);
  sessionStorage.setItem("TestId",id)
}
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
    ):(data&&userRole==="Admin"||userRole==="Teacher"?
    <div class="grid-container-subjects">
    {data.map( item => (
      <div class="item">
                  <a class="icon" onClick={()=>redirectToEditTest(item.id,item.name,item.typeOfTest
                    ,item.additionalInfo,item.timeOfTest)}>
           <img class="edit"src={edit}  ></img>
           </a>
      <p class="SubjectTitle" key={item.id}>  {item.name}</p>
      <p style={{fontSize:25+'px'}}>{item.timeOfTest}min.</p>
      <a  role="button" class="btn btn-info" onClick={()=>redirectToTestModify(item.id,item.typeOfTest)} >Go ahead</a>
      <br></br>
      <br></br>
      <a class="icon" onClick={()=>deleteTest(item.id)}>
 <svg class="icon-delete"width="22" height="22" viewBox="0 0 1024 1024">
    <path d="M192 1024h640l64-704h-768zM640 128v-128h-256v128h-320v192l64-64h768l64 64v-192h-320zM576 128h-128v-64h128v64z"></path>
  </svg>
  </a>
      </div>
      
    ))}
     <a href="http://localhost:3000/registerTest">
       <img class="plus" src={plus}></img>
       </a>
  </div>:data?
  <div>
  <div class="test">
  {data.map( item => {

    if(item.id===parseInt(sessionStorage.getItem("TestId"))){
      if(info===""||name===""||id===null){
        setInfo(item.additionalInfo);
        setData(item.name);
        setId(item.id);
      }
      return(
      <div className={style}>
      <h1 class="title_test">About Test</h1>
       <p class="test_info" >{info}</p>
      <h1 class="title_test">How we score the result</h1>
      <p class="text_score">Every question has the different level of complexity. Easy, Medium and High.
Each of them is being evaluated differently depending on levels of complexity and threshold counted automaticaly
 to the each of test but should be <strong>61%</strong></p> 
         <div class="box">
            <h3 class="title_test">{name}</h3>
            <p class="title_test">Good Luck</p>
            <div class='container'>
               <span class='pulse-button' onClick={()=>redirectToStartTest(id)}>Start</span>
              </div>
         </div>
    </div>
      )
    }
})}
</div>
 <div class="item_list">
   <h1 class="title_item_list" >References</h1>
   {data.map( item => {
      if(item.id===parseInt(sessionStorage.getItem("TestId"))){
        return(
          <div class="choosed_test">
             <p class="text_test">{item.name}</p>
             <p>Good Luck</p>
             <a type="button" style={{width:170+'px',fontSize:17+'px'}} class="btn btn-info">
               Choose test</a>
          </div>
        )
      }else{
        return(
        <div class="item_test">
            <p class="text_test">{item.name}</p>
            <p>Good Luck</p>
            <a type="button" style={{width:170+'px',fontSize:17+'px'}} class="btn btn-info"
            onClick={()=>Change(item.additionalInfo,item.name,item.id,item.typeOfTest)}>Choose test</a>
    </div>
        );
        
      }
        
    
})}
</div>
</div>:<div></div>
    )}
  </div>
      );
}

