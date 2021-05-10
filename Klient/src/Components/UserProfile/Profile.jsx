import React,{Component} from 'react'
import Api from '../API/CheckTestApi'
import API from '../API/AuthorizationApi'
import jwt_decode from "jwt-decode";
import { Progress } from 'reactstrap';
import { CircularProgressbar } from 'react-circular-progressbar';
import "react-circular-progressbar/dist/styles.css";
import ProgressProvider from "./ProgressProvider";
import style from '../UserProfile/Profile.css'
import {Tabs,Tab,Nav,Col,Row} from 'react-bootstrap'
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
                     this.monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
                }
                this.state = {
                        average:0,
                        text:[]
                      };
                this.GetResultsOfTest();
        }
        DeleteAccount = async()=>{
            let api=new API();
            await api.deleteAccount(this.id);
        }
        GetResultsOfTest = async () => {
                let api = new Api();
                console.log(this.id);
                var average = 0;
                var count = 0;
                const result =  await api.GetResultsOfTest(this.id);
                {result.data.map((item,index)=>{
                        count = index
                        average=average + parseInt(item.score)
                })}
                console.log(count);
                average = average/(count+1)
                console.log(result.data)
                this.setState({text:result.data}); 
                this.setState({average:average})       
        }
        render(){       
                return(
<Tab.Container id="left-tabs-example" defaultActiveKey="first">
  <Row>
    <Col sm={3}>
      <Nav variant="pills" className="flex-column">
      <div class="leftSide ml-7">
              <div>
            <h1>Profile</h1>
            <h2 class="ml-1" style={{fontSize:75+'px'}}>
              {sessionStorage.getItem("name").charAt(4)}</h2>
              <Nav.Link  eventKey="first" title="Results of Test">Results of tests
              <a href="" class="link"  onClick={()=>this.GetResultsOfTest()}></a>  
               </Nav.Link>
               <Nav.Link class="link" eventKey="second" title="Average Result">Average Result
               <a href=""></a>
               </Nav.Link>
               <Nav.Link class="link" style={{color:'red'}} eventKey="third" title="Delete Account">Delete Account
                <a href="" ></a>
                </Nav.Link>
           </div>
          </div>
                    
      </Nav>
    </Col>
    <Col sm={9}>
      <Tab.Content>
        <Tab.Pane eventKey="first">
        <div class="rightSide mr-8">
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
                <p style={{fontSize:25+'px'}} >What is left to pass : {61- item.score +'%'}</p>
                <br></br>
                <ProgressProvider valueStart={0} valueEnd={item.score}>
              {
              (value) =>              
              <CircularProgressbar value={value } text={`${value}%`} />}
                 </ProgressProvider>          </div>
                );}})
                
               }
                        </div>
        </Tab.Pane>
        <Tab.Pane eventKey="second">
                <div class="rightSideSecond mr-8">
                      <h1>Average Result</h1>
                      <ProgressProvider valueStart={0} valueEnd={this.state.average}>                              
              {(value) => <CircularProgressbar value={value} text={`${parseFloat(value).toFixed(1)}%`} />}
                 </ProgressProvider>  
                </div>
        </Tab.Pane>
        <Tab.Pane eventKey="third">
                <div class="rightSideSecond mr-8">
                      <h1>Delete Account</h1>
                      <button class="btn btn-danger" style={{width:200+"px",marginTop:100+'px'}}
                               onClick={()=>this.DeleteAccount()}>
                              <p style={{fontSize:25+'px'}}>Delete Account</p>
                              </button> 
                </div>
        </Tab.Pane>
      </Tab.Content>
    </Col>
  </Row>
</Tab.Container>
                )          
                }
        }
