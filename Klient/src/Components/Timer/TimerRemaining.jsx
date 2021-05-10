import React, { useState, useEffect,Component } from 'react';
import jwt_decode from "jwt-decode";
import {
  HubConnectionBuilder,
  HubConnectionState,
  HubConnection,
  HttpTransportType,
  LogLevel
} from '@microsoft/signalr';
import Api from '../API/CheckTestApi'
import TimeUI from './TimerUI'
export default class TimeRemaining extends Component
{
 // const [counter, setCounter] = React.useState(60);

  // Second Attempts
  // React.useEffect(() => {
  //    counter>0 && setInterval(() => {
  //       setCounter((time)=>time-1);
  //     }, 1000);
  // }, []);
  // async function CheckTest(){
  //   let api = new Api();
  //   let list = new Array();
  //   if(localStorage.length-1===0){
  //     var obj = JSON.stringify({
  //       QuestionId:sessionStorage.getItem("QuestionId"),
  //       UserId:props.userId,
  //       isCorrectA:false,
  //       isCorrectB:false,
  //       isCorrectC:false
  //     })
  //     list.push(JSON.parse(obj))
  //   }
  //   api.SendToCheckTest(list); 
  // }
  constructor(props){
    super();
    let userId=null;
    if(sessionStorage.getItem("accessToken")!==null){
      let decoded=null;
      let role=null;
      decoded = jwt_decode(sessionStorage.getItem("accessToken"));
     role =  decoded[
             "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
           ];
           userId=decoded[
             "sub"
           ] ;
          }
    this.state={
      minutes:0,
      seconds:0,
      userId: userId
    }
  
  }
          componentDidMount() {
            const hubConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:44323/timer')
            .configureLogging(LogLevel.Information)
            .withAutomaticReconnect()  
            .build();
          console.log(this.userId);
         hubConnection.start().then(()=>hubConnection.invoke('CheckDatesAndShow',this.state.userId))
       
       hubConnection.on('sendToAll', (minutes,seconds) => {
        console.log("Time" , minutes);
        this.setState({minutes:minutes,seconds:seconds,userId:this.state.userId});
      });
      }
           
      
    render(){
      if(this.state.minutes!==0){
        return(
            <TimeUI minutes={this.state.minutes} seconds={this.state.seconds} userId={this.state.userId}></TimeUI>
        );
      }
            return(
                      <div >
                        <button>Click</button>
                      </div>
              );

            }

}