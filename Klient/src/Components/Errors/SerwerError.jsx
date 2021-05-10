import React from 'react'
import { Component } from 'react'
import serwerError from '../img/500_error_page.png'

export default class SerwerError extends Component
{
   render(){
           return(
                <div>
                        <img src={serwerError}/>
                        <h2 style={{color:"whitesmoke"}}>OOOps! There was internal serwer error.</h2>
                        <h4>Don't worry, our development team have automaticaly been notified<br></br>
                        of this issue and they are working on it.<br></br>
                         Please try again in a few minutes.</h4>
                </div>
           );
   }
}