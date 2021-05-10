import SubjectManagerUtils from "../SubjectManager/SubjectManager.utils";
import React, {useEffect} from "react";
import TestManager from '../TestManager/TestManager.utils'
import Loader from "react-loader-spinner";
import style from "../SubjectManager/SubjectsStyle.css"
import edit from "../img/edit.png"
import plus from "../img/plus.png"
export default function SubjectManager(){
  const {data,fetchSubject,redirect,deleteSubject,isLoading,userRole} = SubjectManagerUtils();
  const {redirectToTests} = TestManager();

  useEffect(() => {fetchSubject()},[])
  
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
    ) :data&&userRole==="Admin"||userRole==="Teacher" ?

       <div class="grid-container-subjects">
       {data.map( item => (
         <div class="item" >
         <a class="icon" onClick={()=>redirect(item.id,item.name)}>
           <img class="edit"src={edit}></img>
           </a>
         <p class="SubjectTitle" key={item.id}>  {item.name}</p>
         <a  role="button" class="btn btn-info" onClick={()=>redirectToTests(item.id)}>Go to test</a>
         <br></br>
         <br></br>
         <a class="icon" onClick={()=>deleteSubject(item.id)} >
 <svg class="icon-delete" width="22" height="22" viewBox="0 0 1024 1024">
    <path d="M192 1024h640l64-704h-768zM640 128v-128h-256v128h-320v192l64-64h768l64 64v-192h-320zM576 128h-128v-64h128v64z"></path>
  </svg>
  </a>
         </div>
       ))}
       <a href="http://localhost:3000/registerSubject">
       <img class="plus" src={plus}></img>
       </a>
     </div>
      :  <div class="grid-container-subjects">
      {data.map( item => (
        <div class="item">
        <p class="SubjectTitle" key={item.id}>  {item.name}</p>
        <a  role="button " class="btn btn-info"  onClick={()=>redirectToTests(item.id)}>Go to test</a>
        </div>
      ))}
    </div>
    }
  </div>
    );
  }
      