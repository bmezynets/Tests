import { render } from "@testing-library/react";
import Nav from 'react-bootstrap/Nav'
import css from './Footer.css'
import NavDropdown from 'react-bootstrap/NavDropdown'
import Navbar from 'react-bootstrap/NavBar'
import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, Form, FormGroup } from 'reactstrap';

// reactstrap components
// import {
//
// } from "reactstrap";

// Core Components
export default function Example (props){
       console.log(props.style);
  const [modal, setModal] = useState(false);
  const [unmountOnClose, setUnmountOnClose] = useState(true);
  const[text,setText]=useState("");
  const[style,setStyle]=useState("contentFooter");
    const toggle = () => setModal(!modal);
  const changeUnmountOnClose = e => {
          console.log(e.target.value);
      setUnmountOnClose(e.target.value);
      setText(e.target.value);
  }
 // if(props.style!==undefined||props.style!==null){
  //  setStyle("contentFooterHome");
 // }
  return (
    <div>
          <div className={props.style===undefined||props.style===null?style:props.style}>
        <Navbar collapseOnSelect expand="lg" style={{background:"RGBA(12,29,44,1)"}} variant="dark">
        <Navbar.Brand href="#home">&#169; Testex.com </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link onClick={()=>setModal(true)}>Contact with us</Nav.Link>
            <Nav.Link href="#link">|&nbsp;&nbsp;&nbsp;&nbsp;Find us</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
      </div>
       <div>
       <Modal isOpen={modal} modalTransition={{ timeout: 200 }} backdropTransition={{ timeout: 100 }}toggle={toggle}  unmountOnClose={unmountOnClose}>
           <ModalHeader toggle={toggle}>Contact with us</ModalHeader>
           <ModalBody>
               You can contact with Admin with details below<br></br>
               Email : admin@admin.com
           </ModalBody>
       </Modal>
   </div>
   </div>
  );
        }


