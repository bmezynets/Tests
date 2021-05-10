import React,{ Component } from "react";
import Api from "../API/FileApi";
import css from "../FileManager/Files.css"
import excel from "../img/excel.png"
import HowToFillMultipleTest from "./HowToFillMultipleTest";
import HowToFillSingleTest from './HowToFillSingleTest'
export default class AllFiles extends Component{
   constructor(){
           super();
           this.state={
                   files:[],
                   height:0
           }
           this.howFill = 0;
           if(parseInt(sessionStorage.getItem("TypeTest"))==0){
                   this.howFill = <HowToFillMultipleTest></HowToFillMultipleTest>
           }
           if(parseInt(sessionStorage.getItem("TypeTest"))==1){
             this.howFill = <HowToFillSingleTest></HowToFillSingleTest> 
           }
           this.GetAllTestFiles();

   }
   GetAllTestFiles =async () => {
         let api = new Api();
         var result = await api.fetchAllTestFiles();
         console.log(result);
         if(result===undefined){
                 return(
                         <div>You don't have files</div>
                 )
         }
         this.setState({files:result});
   }
   DownloadFile =async (id) => {
        let api = new Api();
        var result = await api.DownloadTestFile(id);
        console.log(result);
        if(result===undefined){
                return(
                        <div>You don't have files</div>
                )
        }
  }
        render(){
                return(
                        <div>
                   <div class="grid-container-files"> 
                           {this.state.files.map(item=>{
                                   if(item.typeOfTest===parseInt(sessionStorage.getItem("TypeTest"))){
                                           return(
                   <div class="item-file">
                           <img class="excel" src={excel}></img>
                           <p style={{color:"#007bff",fontSize:30+"px"}}>{item.fileName.split(/(?=[A-Z])/).join(" ")}</p>
                           <p class="info_download">This is an example of multiple choices test. You can download this file
                              and fill it out. If you don't know how to fill it you just need to click the button 
                              <strong> " How to fill "</strong> and find out.</p>
                           <button type="button" class="btn btn-info" href="" onClick={()=>this.DownloadFile(item.id)}>Download</button>
                           
                           <button style={{marginLeft:20+'px'}}type="button" href="" class="btn btn-warning"
                            onClick={()=>this.setState({height:100})}>
                                   How to fill??</button>                   
                               </div>
                           )}})}
                    </div>
                    <div id="myNav" style={{height:this.state.height+'%'}} class="overlay">
                    <a  rol="button"  class="closebtn" onClick={()=>this.setState({height:0})}>&times;</a>
                            <h1 style={{color:"whitesmoke",fontSize:35+"px",marginTop:30+'px'}}>
                                    How to fill in test
                            </h1>
                            <h3 style={{color:"whitesmoke",fontSize:30+"px"}}>Okay... let's start<br></br></h3>

                               {this.howFill}
                         </div>
                    </div>
                );
        }
}