import React, { useState } from "react";
import axios from "axios";
import Swal from "sweetalert2"
import TestManager from "../TestQuestionManager/TestQuestionManager.utils"
import AllFiles from "../FileManager/AllFiles";

export const FileUpload = () => {
  const [file, setFile] = useState();
  const [fileName, setFileName] = useState();
  const{SendFile}=TestManager();
  const saveFile = (e) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  const uploadFile = async (e) => {
    console.log(file);
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("SubjectId", sessionStorage.getItem("SubjectId"));
    SendFile(formData);
  };

  return (
    <div>
    <div style={{marginTop:50+'px'}}>
      <h1 style={{color:"whitesmoke",fontSize:30+"px"}}>Please choose file with your questions</h1>
      <input type="file" onChange={saveFile}/>
      <button class="btn btn-success" onClick={uploadFile}>Upload File</button>
    </div>
    <AllFiles></AllFiles>

    </div>
  );
};
export default FileUpload;