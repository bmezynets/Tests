import React,{Component} from 'react'
import { Container } from 'react-bootstrap'
import Carousel from 'react-bootstrap/Carousel'
import html from '../img/html.png'
import css from '../img/css.png'
import Css from '../Home/Home.css'
import sql from '../img/sql.png'
import react from '../img/react.png'
import slideLog from '../img/slide-log.png'
import phone from '../img/phone.png'
export default class Home extends Component{

  constructor(props){
    super();
    this.styles = props.style;
  }
  render(){
        return(
          <div class="homePage">
            <div id="backSlide">
                <Carousel>
                <Carousel.Item class="carousel-item active"  data-interval="0.01">         
                        <Carousel.Caption class={this.styles} style={{top:50 + '%'}}>
           
                                 <div class ="grid-container">
                              <div>
                                <img class="slider-image" src="https://cdn.worldvectorlogo.com/logos/c--4.svg"></img>
                              </div>
                              <div>
                                <img class="slider-image" src={html}></img>
                              </div>
                              <div>
                                <img class="slider-image" src="https://image.flaticon.com/icons/png/512/136/136527.png"></img>
                              </div>
                              <div>
                                <img class="slider-image" src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/306px-ISO_C%2B%2B_Logo.svg.png"></img>
                              </div>
                              <div>
                                <img class="slider-image" src={sql}></img>
                              </div>
                              <div>
                                <img class="slider-image" src={react}></img>
                              </div>

                              </div>        
                                 <div class="text">      
                                <h2 class="title">Best tests from <br></br> professional programmers</h2>
                                <h4>Over 100 different tests to check your skills</h4>
                                <p class="slide-button">Start your trip with us:)</p> 
                              </div>  
                        </Carousel.Caption>
                </Carousel.Item >
                    <Carousel.Item class="carousel-item"  data-interval="0.5">
                         <Carousel.Caption class={this.styles} >
                           <img class="slide-logo" src={slideLog}></img>
                         <div class="text">      
                                <h2 class="title">You can learn anything</h2>
                                <h4>Build a deep,<br></br>solid understanding in the myriad<br></br>of the programming languages</h4>
                        </div> 
                         </Carousel.Caption>
                    </Carousel.Item>
        
        </Carousel>
        
        </div>


        <h1 style={{color:"whitesmoke"}}>We offer</h1>
        <div class="grid-container-home">
          <div class="item-home">
             <h2>C#</h2>
          </div>
          <div class="item-home">
             <h2>C++</h2>
          </div>
          <div class="item-home">
             <h2>HTML</h2>
          </div>
          <div class="item-home">
             <h2>CSS</h2>
          </div>
          <div class="item-home">
             <h2>Java</h2>
          </div>
          <div class="item-home">
             <h2>Kotlin</h2>
          </div>
        </div>
        </div>
        )
        }
      }
