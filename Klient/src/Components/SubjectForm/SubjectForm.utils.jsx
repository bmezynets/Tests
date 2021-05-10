import * as Yup from 'yup';
import API from "../API/SubjectApi"


export default function SubjectManager() {
        let initialValues = {
          Name: "",
        };

        const validationSchema = Yup.object().shape({
          Name: Yup.string()
                  .min(1, "Too short!")
                  .max(17, "Too long!")
                  .required("Required"),
              });
              
  function onSubmit(fields, { setSubmitting }) {
    console.log(fields);
    createSubject(fields, setSubmitting);  
  }
  async function createSubject(fields, setSubmitting) {
    try {
      let api = new API();
      api.createSubject(fields);
      setSubmitting(false);
    } catch (error) {
      console.log(error);
     }
  }
              return {
                initialValues,
                validationSchema,
                onSubmit,
              };
            }