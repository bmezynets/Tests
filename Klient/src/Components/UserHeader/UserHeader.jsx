import React from 'react'
import Nav from 'react-bootstrap/Nav'
import NavDropdown from 'react-bootstrap/NavDropdown'
import Api from '../API/SubjectApi'
import Navbar from 'react-bootstrap/NavBar'
import logIn from '../img/logIn.png'
import details from '../img/details.png'
import logOut from '../img/shutDown.png'
import jwt_decode from "jwt-decode";
import {Component} from 'react'
import style from "../UserHeader/UserHeader.css"
import RegisterUser from '../RegisterForm/RegisterForm'
import SerwerError from '../Errors/SerwerError'
import {Input} from "reactstrap";
class UserHeader extends Component{
  constructor(props){
    super();
     let decoded=null;
      this.role=null;
     if(sessionStorage.getItem("accessToken")!==null){
      decoded = jwt_decode(sessionStorage.getItem("accessToken"));
     this.role =  decoded[
             "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
           ]; 
     }
     this.state={
       subjects:[],
       height:0,
       search:""
     }
     this.GetSubjectTests();
  }
  GetSubjectTests = async () => {
    let api = new Api();
    console.log(this.id);
    const result =  await api.fetchSubjectsTests();
    console.log(result)
    this.setState({subjects:result});
}
 redirectToSubjects(){
   if(this.role==="Admin"||this.role==="Teacher"){
     window.location.assign("/subjects");
   }
   else{
     this.setState({height:100})
   }
 }
 redirect(subjectId,testId,typeOfTest){
  sessionStorage.setItem("SubjectId",subjectId);
  sessionStorage.setItem("TestId",testId)
  sessionStorage.setItem("TypeTest",typeOfTest)
  window.location.assign("/tests/"+subjectId);
}
onChange=e=>{
  this.setState({search:e.target.value})
}
switchProfile(){
  if(this.role==="Teacher"){
    window.location.assign("/teacherProfile");
  }else if(this.role==="Admin"){
    window.location.assign("/adminProfile")
  }else if(this.role==="User"){
    window.location.assign("/myProfile")
  }
}
  render(){
    if(this.state.subjects==null||this.state.subjects==undefined){
           window.location.assign("/errorConnection")
    }else{
    return(   
    <div class="main_header">
    {sessionStorage.getItem("accessToken")!==null&&this.role==="Admin"?(
        <Navbar collapseOnSelect expand="lg" style={{background:"RGBA(12,29,44,1)"}} variant="dark">
        <Navbar.Brand href="/home" style={{fontSize: 40 + 'px',color:'#ffebee'}}>Testex</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="/home" class="links">Home</Nav.Link> 
            
            <div id="myNav" style={{height:this.state.height+'%'}} class="overlay">
                
            <a  rol="button"  class="closebtn" onClick={()=>this.setState({height:0})}>&times;</a>
                
            <Input icon="search"
                            id="search"
                            placeholder='Find your test'
                            onChange={this.onChange}
                            /> 
      
             <div class="grid-container-subject-test">
                 { this.state.subjects.map(item=>(
                   <div>
                     <p class="SubjectName">{item.name}</p>
                     {item.tests.map(items=>{
                       if(items.name.toLowerCase().indexOf(this.state.search.toLowerCase())===-1){
                         return(
                          <div class="deleted_item">
                          <a class="TestsName" onClick={()=>this.redirect(item.id,items.id,items.typeOfTest)}>{items.name}</a>
                          </div>
                        
                         );
                        }
                       return(
                       <div class="exist_item">
                         <a class="TestsName" onClick={()=>this.redirect(item.id,items.id,items.typeOfTest)}>{items.name}</a>
                         </div>
                       );
        })}
                   </div>
                 ))}
             </div>
      
      </div>
            <NavDropdown class="links" title="" id="collasible-nav-dropdown">Info
              <NavDropdown.Item href="/3.1">Contacts</NavDropdown.Item>
              <NavDropdown.Item href="#action/3.2">Problems</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">FeedBack</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Nav>     
          <p style={{color:"white",fontSize:20+'px',marginRight:150+'px',marginTop:10+'px'}}>
            {sessionStorage.getItem("name")}
          </p>
          </Nav>
        
          <Nav>
            <a class="link-logo" onClick={()=>this.switchProfile()}><img class="details" src={details}></img></a>
            <a class="link-logo" href="/home"><img class="logOut" src={logOut} 
            onClick={()=>{
              sessionStorage.clear();
            }}
            ></img></a>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
       
    ):<div></div>   
    }  
    {sessionStorage.getItem("accessToken")!==null&&this.role==="User"
   ||sessionStorage.getItem("accessToken")!==null&&this.role==="Teacher" ? (
      <div>
  <Navbar collapseOnSelect expand="lg" style={{background:"RGBA(12,29,44,1)"}} variant="dark">
  <Navbar.Brand href="#home" style={{fontSize: 40 + 'px',color:'#ffebee'}}>Testex</Navbar.Brand>
  <Navbar.Toggle aria-controls="responsive-navbar-nav" />
  <Navbar.Collapse id="responsive-navbar-nav">
    <Nav className="mr-auto">
      <Nav.Link href="/home" class="links">Home</Nav.Link> 

      <Nav.Link rol="button" onClick={()=>this.redirectToSubjects()}>What to learn?</Nav.Link>

      <div id="myNav" style={{height:this.state.height+'%'}} class="overlay">
          
      <a  rol="button"  class="closebtn" onClick={()=>this.setState({height:0})}>&times;</a>
          
      <Input icon="search"
                      id="search"
                      placeholder='Find your test'
                      onChange={this.onChange}
                      /> 

       <div class="grid-container-subject-test">
           { this.state.subjects.map(item=>(
             <div>
               <p class="SubjectName">{item.name}</p>
               {item.tests.map(items=>{
                 if(items.name.toLowerCase().indexOf(this.state.search.toLowerCase())===-1){
                   return(
                    <div class="deleted_item">
                    <a class="TestsName" onClick={()=>this.redirect(item.id,items.id,items.typeOfTest)}>{items.name}</a>
                    </div>
                  
                   );
                  }
                 return(
                 <div class="exist_item">
                   <a class="TestsName" onClick={()=>this.redirect(item.id,items.id,items.typeOfTest)}>{items.name}</a>
                   </div>
                 );
  })}
             </div>
           ))}
       </div>

</div>
      <NavDropdown class="links" title="" id="collasible-nav-dropdown">Info
        <NavDropdown.Item href="/3.1">Contacts</NavDropdown.Item>
        <NavDropdown.Item href="#action/3.2">Problems</NavDropdown.Item>
        <NavDropdown.Divider />
        <NavDropdown.Item href="#action/3.4">FeedBack</NavDropdown.Item>
      </NavDropdown>
    </Nav>
    <Nav>     
    <p style={{color:"white",fontSize:20+'px',marginRight:150+'px',marginTop:10+'px'}}>
      {sessionStorage.getItem("name")}
    </p>
    </Nav>
  
    <Nav>
      <a class="link-logo" onClick={()=>this.switchProfile()}><img class="details" src={details}></img></a>
      <a class="link-logo" href="/home"><img class="logOut" src={logOut} 
      onClick={()=>{
        sessionStorage.clear();
      }}
      ></img></a>
    </Nav>
  </Navbar.Collapse>
</Navbar>
      </div>
    ) :sessionStorage.getItem("accessToken")===null ? 
      <div>
  <Navbar collapseOnSelect expand="lg" style={{background:"RGBA(12,29,44,1)"}} variant="dark">
  <Navbar.Brand href="#home" style={{fontSize: 40 + 'px',color:'#ffebee'}}>Testex</Navbar.Brand>
  <Navbar.Toggle aria-controls="responsive-navbar-nav" />
  <Navbar.Collapse id="responsive-navbar-nav">
    <Nav className="mr-auto">
      <Nav.Link href="/home" class="links">Home</Nav.Link> 
    
      <Nav.Link rol="button" onClick={()=>this.setState({height:100})}>What's learn?</Nav.Link>

      <div id="myNav" style={{height:this.state.height+'%'}} class="overlay">
          
      <a  rol="button"  class="closebtn" onClick={()=>this.setState({height:0})}>&times;</a>
          
      <Input icon="search"
                      id="search"
                      placeholder='Find your test'
                      onChange={this.onChange}
                      /> 

       <div class="grid-container-subject-test">
           { this.state.subjects.map(item=>(
             <div>
               <p class="SubjectName">{item.name}</p>
               {item.tests.map(items=>{
                 if(items.name.toLowerCase().indexOf(this.state.search.toLowerCase())===-1){
                   return(
                    <div class="deleted_item">
                    <a class="TestsName" onClick={()=>this.redirect(item.id,items.id)}>{items.name}</a>
                    </div>
                  
                   );
                  }
                 return(
                 <div class="exist_item">
                   <a class="TestsName" onClick={()=>this.redirect(item.id,items.id)}>{items.name}</a>
                   </div>
                 );
  })}
             </div>
           ))}
       </div>

</div>
      <NavDropdown class="links" title="" id="collasible-nav-dropdown">Info
        <NavDropdown.Item href="/3.1">Contacts</NavDropdown.Item>
        <NavDropdown.Item href="#action/3.2">Problems</NavDropdown.Item>
        <NavDropdown.Divider />
        <NavDropdown.Item href="#action/3.4">FeedBack</NavDropdown.Item>
      </NavDropdown>
    </Nav>
    <Nav>
      <a class="link-logo" href="http://localhost:3000/login"><img class="logo" src={logIn}></img></a>
    </Nav>
  </Navbar.Collapse>
</Navbar>
      </div>:<div></div>
    
    }
    </div>
    );
  }
  }
}

export default UserHeader;