import React,{Component} from 'react'
import Api from '../API/FeedBackApi'
import API from '../API/AuthorizationApi'
import jwt_decode from "jwt-decode";
import { Progress } from 'reactstrap';
import { CircularProgressbar } from 'react-circular-progressbar';
import "react-circular-progressbar/dist/styles.css";
import ProgressProvider from '../UserProfile/ProgressProvider';
import style from '../TeacherProfile/Profile.css'
import {Tabs,Tab,Nav,Col,Row} from 'react-bootstrap'
export default class Profile extends Component{
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
                this.state={
                        feedbacks:[]
                }
                this.GetFeedBacks();
        }
        DeleteAccount = async()=>{
            let api=new API();
            await api.deleteAccount(this.id);
        }
        GetFeedBacks = async () => {
                let api = new Api();
                console.log(this.id);
                const result =  await api.GetFeedBacks();
                this.setState({feedbacks:result})   
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
              <Nav.Link  eventKey="first" title="Results of Test">FeedBacks
              <a href="" class="link"  onClick={()=>this.GetResultsOfTest()}></a>  
               </Nav.Link>
               <button class="btn btn-danger" style={{width:200+"px",marginTop:30+'px'}}
                               onClick={()=>this.DeleteAccount()}>
                              <p style={{fontSize:23+'px'}}>Delete Account</p>
                              </button> 
           </div>
          </div>
                    
      </Nav>
    </Col>
 <Col>
     <div class="rightSide mr-8">
               <Col>
                <div class="list_tests">
                          <p style={{fontSize:30+'px',fontFamily: 
                "Arial,sans-serif",fontWeight:400,width:100+'%'}}>Your Tests</p>
                          <Nav  variant="pills" className="flex-column">
                          <div>
                        {this.state.feedbacks.map(item=>(
                                <div>
                                      <Nav.Link  class="link"
                                      eventKey={item.id} title="Results of Test">
                                              {item.name}
                                      </Nav.Link>
                                      <p></p>
                                      </div>         
                        ))}
                        </div>
                        </Nav>
               </div>
               </Col>
               <Row>
         <div class="list_feedBacks">
                <p 
                style={{fontSize:30+'px',fontFamily: 
                "Arial,sans-serif",fontWeight:400}}>FeedBacks</p>
                <Col sm={9}>
                   <Tab.Content>     
                {this.state.feedbacks.map(item=>(
                        
                        <Tab.Pane eventKey={item.id}>
                                <div>
                        {item.feedBacks.map(feedbacks=>(                                
                                   <div class="comment">
                                   <p class="postTime">{feedbacks.postTime}</p>
                                   <p class="postedBy"><strong>Posted By :</strong> {feedbacks.name.split("Hi,")}</p>
                                   <p class="feedBack"><strong>Comment :</strong> {feedbacks.comment}</p>
                                   </div>
                        ))}
                        </div>
                        </Tab.Pane>
                        
                        
                ))}
                        </Tab.Content>
                         </Col>
         </div>
         </Row>
         
     </div>
    </Col>
  </Row>
</Tab.Container>
                )          
                }
        }
