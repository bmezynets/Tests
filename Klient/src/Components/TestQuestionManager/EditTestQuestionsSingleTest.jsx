import React from 'react'
import { Form, Formik,Field,ErrorMessage } from "formik";
import API from "../API/TestQuestionsApi"
import style from '../TestQuestionManager/TestQuestion.css'
import Api from '../API/Api';

export default function EditTestQuestionSingleTest() {
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
        function singleSelection(a,b,c){

                initialValues.isCorrectA = a;
                initialValues.isCorrectB = b;
                initialValues.isCorrectC = c;       
            }
        async function EditTestQuestion(fields){
            let api = new API();
            api.EditTestQuestion(fields);
        }
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
                        class="form-control"
                          />
                           <ErrorMessage
                          name="optionA"
                          component="div"
                       className="invalid-feedback"
                          />
                              <Field
                        type="checkbox"
                        onClick={()=>singleSelection(true,false,false)}
                        name="isCorrectA"
                        maxLength = "9"
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
                        class="form-control"
                          />
                           <ErrorMessage
                          name="optionB"
                          component="div"
                       className="invalid-feedback"
                          />
                              <Field
                        type="checkbox"
                        onClick={()=>singleSelection(false,true,false)}
                        name="isCorrectB"
                        maxLength = "9"
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
                        maxLength = "9"
                        class="info"
                          />
                           <ErrorMessage
                          name="isCorrectC"
                          onClick={()=>singleSelection(false,false,true)}
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