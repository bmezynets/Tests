import React,{useState} from 'react'
import { Form, Formik,Field,ErrorMessage } from "formik";
import { useParams } from "react-router-dom";
import API from "../API/TestApi"
import css from './Test.css'
import * as Yup from 'yup';

export default function EditTest() {

const{id} = useParams();
const[automatic,setAutomatic]=useState(false);

        let initialValues = {
                Id:id,
                TypeOfTest:sessionStorage.getItem("TypeTest"),
                Name:sessionStorage.getItem("TestName"),
                TimeOfTest:sessionStorage.getItem("Time"),
                AdditionalInfo:sessionStorage.getItem("Info"),
                AutomaticCountTime:false,
              }
              function ChooseTypeOfCountTime(){
                return(
                automatic==false?setAutomatic(true):setAutomatic(false)
                );
              }
              const validationSchema = Yup.object().shape({
                Name: Yup.string()
                        .min(1, "Too short!")
                        .max(17, "Too long!")
                        .required("Required"),
                                    
                AdditionalInfo: Yup.string()
                        .min(10, "Too short!")
                        .max(100, "Too long!")
                        .required("Required"),
  
               } )
                  
        function onSubmit(fields){
                try{
                        console.log(fields);
                        EditTest(fields);
                }
                catch(error){
                        console.log("error");
                }  
        }
        async function EditTest(fields){
            let api = new API();
            api.EditTest(fields);
        }
        return (

                <Formik 
                  onSubmit={onSubmit}
                  initialValues={initialValues}
                  validationSchema={validationSchema}
                >
                                          {({ errors, touched }) => {
return(
                      <Form class="upsertformsShowTest">
                        <h1>Edit Test</h1>
                        <br></br>
                        <Field
                                name="Name"
                                className={
                                  "form-control" +
                                  (errors.Name && touched.Name ? " is-invalid" : "")
                                }
                              />
                              <ErrorMessage
                                name="Name"
                                component="div"
                                className="invalid-feedback"
                              />
                          <br></br>
                          <label>Addtional info</label>
                          <Field
                                name="AdditionalInfo"
                                placeHolder="Type something about test"
                                className={
                                  "form-control"}
                              />
                              <ErrorMessage
                                name="AdditionalInfo"
                                component="div"
                                className="invalid-feedback"
                              />
                          <br></br>
                          <label>Choose type of test</label>

                          <Field as="select" name="TypeOfTest" class="form-control">
                            <option value="0">Multiple choises of test</option>
                            <option value="1">Single test selection</option>
                          </Field>
                          <label>Time of Test</label>
                          <Field
                                disabled={automatic==true?true:false}
                                name="TimeOfTest"
                                placeHolder="Enter time of test"
                                className={
                                  "form-control" +
                                  (errors.TimeOfTest && touched.TimeOfTest ? " is-invalid" : "")
                                }
                              />
                                    <label>Automatic counter time for test</label>
                               <Field 
                      type="checkbox"
                        name="AutomaticCountTime"
                        onClick={()=>ChooseTypeOfCountTime()}
                        className={
                          "radio" +
                          (errors.AutomaticCountTime && touched.AutomaticCountTime ? " is-invalid" : "")
                        }
                      />
                        <div className="pt-3">
                          <button
                            type="submit"
                            className="confirm btn btn-primary"
                          >
                            Edit
                        </button>
                        </div>
                      </Form>
)}}            
                </Formik>
              );

}