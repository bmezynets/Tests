import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label, Form, FormGroup } from 'reactstrap';
import Api from '../API/FeedBackApi'
import Swal from "sweetalert2"

const ModalExample = (props) => {
    const {
      buttonLabel,
      className
    } = props;
  
    const [modal, setModal] = useState(true);
    const [unmountOnClose, setUnmountOnClose] = useState(true);
    const[text,setText]=useState("");
    const toggle = () => setModal(!modal);
    const changeUnmountOnClose = e => {
            console.log(e.target.value);
        setUnmountOnClose(e.target.value);
        setText(e.target.value);
    }
  function SendFeedBack() {
          let api = new Api();
          if(text===""){
                Swal.fire("OOps","Please type some words","Bad password");
          }else{
          api.SendFeedBack(text);
          setModal(false);
          }
  }
    return (
        <div>
            <Modal isOpen={modal} modalTransition={{ timeout: 2000 }} backdropTransition={{ timeout: 1700 }}toggle={toggle} className={className} unmountOnClose={unmountOnClose}>
                <ModalHeader toggle={toggle}>FeedBack</ModalHeader>
                <ModalBody>
                <Input type="textarea"
                    onChange={changeUnmountOnClose}
                    placeholder="Please write some words about this test.
                    Also if you have problems in the test please write here about this."  rows={5} />
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={()=>SendFeedBack()}>Send</Button>{' '}
                    <Button color="secondary" onClick={toggle}>Cancel</Button>
                </ModalFooter>
            </Modal>
        </div>
    );
}

export default ModalExample;