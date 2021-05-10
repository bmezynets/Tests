import React from "react"
import * as Yup from 'yup';
import { Formik, Field, Form, ErrorMessage } from "formik";
import Api from '../API/TestQuestionsApi'
import Swal from "sweetalert2"

export default function AddTestQuestionSingleTest(){
        let initialValues = {
        Question: "dfgdfg",
        OptionA: "dfg",
        OptionB: "dfg",
        OptionC: "dfg",
        isCorrectOptionA: false,
        isCorrectOptionB: false,
        isCorrectOptionC: false,
        TypeOfQuestion:"1",
        SubjectId:sessionStorage.getItem("SubjectId"),
        TestId:sessionStorage.getItem("TestId")
      };
       function singleSelection(a,b,c){

          initialValues.isCorrectOptionA = a;
          initialValues.isCorrectOptionB = b;
          initialValues.isCorrectOptionC = c;       
      }
      const validationSchema = Yup.object().shape({
        Question: Yup.string()
                .min(1, "Too short!")
                .max(20, "Too long!")
                .required("Required"),
                OptionA: Yup.string()
                .required("Required"),
                OptionB: Yup.string()
                .required("Required"),
                OptionC: Yup.string()
                .required("Required"),


            });
            
            function onSubmit(fields) {
              try{
                    createTest(fields); 
                }  
              catch(error){
                  console.log("error");
          } 
              }
              async function alert(){
                Swal.fire({icon: 'warning',
                title:'Warning',
                 text:'Please set a true answer'});
                  
              }
              async function alertChooseOne(){
                Swal.fire({icon: 'warning',
                title:'Warning',
                 text:'Please set the one true answer'});
                  
              }
              async function createTest(fields) {
                try {
                  if(fields.isCorrectOptionA==false&&fields.isCorrectOptionB==false
                    &&fields.isCorrectOptionC==false){
                   alert();
                  }else if(fields.isCorrectOptionA==true&&fields.isCorrectOptionB==true
                    &&fields.isCorrectOptionC==true||fields.isCorrectOptionA==false&&
                    fields.isCorrectOptionB==true
                    &&fields.isCorrectOptionC==true
                    ||fields.isCorrectOptionA==true&&
                    fields.isCorrectOptionB==false
                    &&fields.isCorrectOptionC==true
                    ||fields.isCorrectOptionA==true&&
                    fields.isCorrectOptionB==true
                    &&fields.isCorrectOptionC==false){
                      alertChooseOne();
                  }
                  else{
                  let api = new Api();
                  api.registerQuestion(fields);
                  }
                } catch (error) {
                  console.log(error);
                 }
              }
              return (
                <Formik 
                  validationSchema={validationSchema}
                  initialValues={initialValues}
                  onSubmit={onSubmit}
                >
                   {({ errors, touched }) => {
            return (
                      <Form className="upsertformTestQuestion">
                      <h1>Add Test Question</h1>
                      
                      <label>Title</label>
                      <Field
                        name="Question"
                        className={
                          "form-control" +
                          (errors.Question && touched.Question ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="Question"
                        component="div"
                        className="invalid-feedback"
                      /> 
                      <div style={{float:"left" ,width:49+'%'}}>
                       <label>First Answer</label>
                      <Field
                        name="OptionA"
                        className={
                          "form-control" +
                          (errors.OptionA && touched.OptionA ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="OptionA"
                        component="div"
                        className="invalid-feedback"
                      />
                      <br></br>
                         <Field 
                      type="checkbox"
                        onClick={()=>singleSelection(true,false,false)}
                        name="isCorrectOptionA"
                        className={
                          "info" +
                          (errors.isCorrectOptionA && touched.isCorrectOptionA ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="isCorrectOptionA"
                        component="div"
                        className="invalid-feedback"
                      />
                      </div>
                      <div style={{float:"right",width:49+'%'}}>
                      <label>Second Answer</label>
                      <Field
                        name="OptionB"
                        className={
                          "form-control" +
                          (errors.OptionB && touched.OptionB ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="OptionB"
                        component="div"
                        className="invalid-feedback"
                      />
                      <br></br>
                       <Field
                        name="isCorrectOptionB"
                        type="checkbox"
                         onClick={()=>singleSelection(false,true,false)}
                        className={
                          "info" +
                          (errors.isCorrectOptionB && touched.isCorrectOptionB ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="isCorrectOptionB"
                        component="div"
                        className="invalid-feedback"
                      />
                      </div>
                       <label>Third Answer</label>
                      <Field
                        name="OptionC"
                        className={
                          "form-control" +
                          (errors.OptionC && touched.OptionC ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="OptionC"
                        component="div"
                        className="invalid-feedback"
                      />
                      <br></br>
                      <Field
                        name="isCorrectOptionC"
                        onClick={()=>singleSelection(false,false,true)}
                        type="checkbox"
                        className={
                          "info" +
                          (errors.isCorrectOptionC && touched.isCorrectOptionC ? " is-invalid" : "")
                        }
                      />
                      <ErrorMessage
                        name="isCorrectOptionC"
                        component="div"
                        className="invalid-feedback"
                      />
                      <Field as="select" style={{float:"right",width:49+'%'}}
                      name="TypeOfQuestion" class="form-control">
                                <option value="1">Easy</option>
                                <option value="2">Medium</option>
                                <option value="3">Hard</option>
                              </Field>
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
            );
          }
        }
              </Formik>
              );
              
}
              