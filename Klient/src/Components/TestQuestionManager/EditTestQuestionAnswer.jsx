import React from 'react'
import { Form, Formik,Field,ErrorMessage } from "formik";
import API from "../API/TestQuestionsApi"
import style from '../TestQuestionManager/TestQuestion.css'
import Api from '../API/Api';

export default function EditTestQuestion() {
        let initialValues = {
          Question:sessionStorage.getItem("SubjectName"),
          optionA:sessionStorage.getItem("OptionA"),
          optionB:sessionStorage.getItem("OptionB"),
          optionC:sessionStorage.getItem("OptionC"),
          isCorrectA:sessionStorage.getItem("isCorrectA")==='false'?false:true,
          isCorrectB:sessionStorage.getItem("isCorrectB")==='false'?false:true,
          isCorrectC:sessionStorage.getItem("isCorrectC")==='false'?false:true,
        }
        function onSubmit(fields){
                try{
                        console.log(fields);
                        EditTestQuestion(fields);
                }
                catch(error){
                        console.log("error");
                }  
        }
        async function EditTestQuestion(fields){
            let api = new API();
            api.EditTestQuestion(fields);
        }
        //if(parseInt(sessionStorage.getItem("TypeTest"))== 0){
        return (
            
                <Formik 
                  onSubmit={onSubmit}
                  initialValues={initialValues}
                >
                      <Form class="upsertformTestQuestion">
                        <h1>Edit Question</h1>
                        <br></br>
                        <label>Question</label>
                        <Field
                        name="Question"
                        maxLength = "15"
                        class="form-control"
                          />
                           <ErrorMessage
                          name="Question"
                          component="div"
                       className="invalid-feedback"
                          />
                          <div style={{float:"left" ,width:47+'%'}}>
                        <label>First Answer</label>
                            <Field
                        name="optionA"
                        maxLength = "15"
                        class="form-control"
                          />
                           <ErrorMessage
                          name="optionA"
                          component="div"
                       className="invalid-feedback"
                          />
                              <Field
                        type="checkbox"
                        name="isCorrectA"
                        maxLength = "15"
                        class="info"
                          />
                           <ErrorMessage
                          name="isCorrectA"
                          component="div"
                       className="invalid-feedback"
                          />
                          </div>
                          <div style={{float:"left" ,paddingLeft:20+'px',width:49+'%'}}>
                          <label>Second Answer</label>
                            <Field
                        name="optionB"
                        maxLength = "15"
                        class="form-control"
                          />
                           <ErrorMessage
                          name="optionB"
                          component="div"
                       className="invalid-feedback"
                          />
                              <Field
                        type="checkbox"
                        name="isCorrectB"
                        maxLength = "15"
                        class="info"
                          />
                          </div>
                           <ErrorMessage
                          name="isCorrectB"
                          component="div"
                       className="invalid-feedback"
                          />
                          <label>Third Answer</label>
                            <Field
                        name="optionC"
                        maxLength = "15"
                        class="form-control"
                          />
                           <ErrorMessage
                          name="optionC"
                          component="div"
                       className="invalid-feedback"
                          />
                              <Field
                              type="checkbox"
                        name="isCorrectC"
                        maxLength = "15"
                        class="info"
                          />
                           <ErrorMessage
                          name="isCorrectC"
                          component="div"
                       className="invalid-feedback"
                          />
                        <button
                          type="submit"
                          className="btn btn-primary"
                        >
                          Save
                        </button>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <a role="button " class="btn btn-danger" onClick={
                          ()=>window.location.assign('/showTestModify/'+sessionStorage.getItem('TestId'))} >     
                        Cancel
                        </a> 
                      </Form>
                </Formik>
              );
                          } 
      //  }