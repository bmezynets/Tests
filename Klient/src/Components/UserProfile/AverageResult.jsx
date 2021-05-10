import React,{Component} from 'react'
import Api from '../API/CheckTestApi'
import jwt_decode from "jwt-decode";
import { Progress } from 'reactstrap';
import { CircularProgressbar } from 'react-circular-progressbar';
import "react-circular-progressbar/dist/styles.css";
import ProgressProvider from "./ProgressProvider";
import style from '../UserProfile/Profile.css'
export default class UserProfile extends Component{
        constructor(){
                super();
                let decoded=null;
                this.id=null;
               if(sessionStorage.getItem("accessToken")!==null){
                decoded = jwt_decode(sessionStorage.getItem("accessToken"));
               this.id =  decoded[
                       "sub"
                     ];

                }
                this.GetResultsOfTest();
        }
        GetResultsOfTest = async () => {
                let api = new Api();
                console.log(this.id);
                const result =  await api.GetResultsOfTest(this.id);
                console.log(result.data)
                this.setState({text:result.data});        
        }
        render(){
               
                        
                if(this.state.text.length===0){
                        return(
                                <div>
                                <div class="rightSide"><p style={{marginTop:20+'%',fontSize:35+'px'}}>You don't have results of tests</p></div>

                                <div class="leftSide">
                                <h1>Profile</h1>
                        <h2 class="oneSymbol" style={{fontSize:75+'px'}}>
                        {sessionStorage.getItem("name").charAt(4)}</h2>
                        <a href="" style={{fontSize:30+'px'}} onClick={()=>this.GetResultsOfTest()}>Results of tests</a>
                        <br></br>
                        <a href=""style={{fontSize:30+'px'}} >Average Result</a>
                        <br></br>
                        <a href=""style={{fontSize:30+'px',color:'red'}} >Delete Account</a>
                        </div>
                                </div>
                        )
                }
                else{
                return(
                        <div>
                        <div class="rightSide">
                {this.state.text.map(item =>
                 {
                         if(item.score>61){
                                 return(
                 <div>
                <div class="item_result">
                <span class="result">{item.dateTime}  {this.monthNames[item.month-1]}</span>
                </div>
                <div class="item_result">
                <span class="result">Test : {item.nameOfTest}</span>
                
                </div>
                <p style={{color:'green',fontSize:30+'px'}}>Done</p>
                <br></br>
                <ProgressProvider valueStart={0} valueEnd={item.score}>
              {(value) => <CircularProgressbar value={value} text={`${value}%`} />}
                 </ProgressProvider>          </div>
                                 );}
                         else{
                         return(
                <div>
                <div class="item_result">
                <span class="result">{item.dateTime}  {this.monthNames[item.month-1]}</span>
                </div>
                <div class="item_result">
                <span class="result">Test : {item.nameOfTest}</span>
                </div>
                <p style={{color:'red',fontSize:25+'px'}}>Loose</p>
                <p style={{fontSize:25+'px'}} >To pass the test you needed {61- item.score +'%'}</p>
                <br></br>
                <ProgressProvider valueStart={0} valueEnd={item.score}>
              {(value) => <CircularProgressbar value={value} text={`${value}%`} />}
                 </ProgressProvider>          </div>
                );}})
               }
                        </div>
                        <div class="leftSide">
                                <h1>Profile</h1>
                        <h2 class="oneSymbol" style={{fontSize:75+'px'}}>
                        {sessionStorage.getItem("name").charAt(4)}</h2>
                        <a href="" style={{fontSize:30+'px'}} onClick={()=>this.GetResultsOfTest()}>Results of tests</a>
                        <br></br>
                        <a href=""style={{fontSize:30+'px'}} >Average Result</a>
                        <br></br>
                        <a href=""style={{fontSize:30+'px',color:'red'}} >Delete Account</a>
                        </div>
                        </div>
                    
                );
        }
                
        }
}
