import React,{useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import UserHeader from './Components/UserHeader/UserHeader';
import jwt_decode from "jwt-decode";
import Home from './Components/Home/Home';
import RegisterForm from './Components/RegisterForm/RegisterForm'
import LoginForm from './Components/LoginForm/LoginForm'
import ConfirmRegistration from './Components/ConfirmRegistration/ConfirmRegistration'
import EmailToReset from './Components/EmailToResetPassword/EmailToResetPassword'
import ForgetPassword from './Components/ForgetPassword/ForgetPassword'
import Subject from './Components/SubjectForm/SubjectForm'
import AllSubjects from './Components/SubjectManager/AllSubjects'
import EditSubject from './Components/SubjectManager/EditSubject'
import AddTest from './Components/TestManager/RegisterTest'
import AllTests from './Components/TestManager/AllTests'
import EditTest from './Components/TestManager/EditTest'
import AddTestQuestions from './Components/TestQuestionManager/AddTestQuestions'
import ShowTestToModify from './Components/TestQuestionManager/ShowTestModify'
import EditTestQuestionAnswer from './Components/TestQuestionManager/EditTestQuestionAnswer'
import EditTestQuestionAnswerSingleTest from './Components/TestQuestionManager/EditTestQuestionsSingleTest'
import DeletedQuestions from './Components/TestQuestionManager/DeletedQuestions'
import AddTestQuestion from './Components/TestQuestionManager/AddTestQuestion'
import AddTestQuestionSingleTest from './Components/TestQuestionManager/AddTestQuestionSingleTest'
import StartTest from './Components/TestQuestionManager/StartTest'
import RewiewTest from './Components/TestQuestionManager/RewiewTest'
import Result from './Components/Results/ResultOfTest'
import MyProfile from './Components/UserProfile/Profile'
import AllFiles from './Components/FileManager/AllFiles'
import Timer from './Components/Timer/TimerRemaining'
import SerwerError from './Components/Errors/SerwerError'
import TeacherProfile from './Components/TeacherProfile/Profile'
import Footer from './Components/Footer/Footer'
import AdminProfile from './Components/AdminProfile/Profile'
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
let decoded=null;
let role=null;
if(sessionStorage.getItem("accessToken")!==null){
 decoded = jwt_decode(sessionStorage.getItem("accessToken"));
role =  decoded[
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
      ]; 
}
  let userRole = role;
  let isLoggedIn = sessionStorage.getItem("isLoggedIn");
console.log(userRole);
function App() {
  return (
    <Router>
       {
       isLoggedIn,
         ( userRole==="User"&&
           <div>
             <Switch>
        <Route path="/registerSubject">
        <UserHeader></UserHeader>
            <Subject style="upsertformsShow"></Subject>
            <Footer></Footer>

        </Route>
        <Route path="/myProfile">
        <UserHeader></UserHeader>
            <MyProfile></MyProfile>
            <Footer></Footer>

        </Route>
        <Route path="/result">
        <UserHeader></UserHeader>
        <Result style="upsertResultShow"></Result>
        <Footer></Footer>
        </Route>
        <Route path="/rewiewTest">
        <UserHeader></UserHeader>
        <RewiewTest style="upsertResultShow"></RewiewTest>
        </Route>
        <Route path="/test/:id">
        <UserHeader></UserHeader>
       <StartTest ></StartTest>
       <Footer></Footer>
        </Route>
        <Route path="/timer">
        <UserHeader ></UserHeader>
        <Timer ></Timer>
        <Footer></Footer>
        </Route>
        <Route path="/home">
        <UserHeader ></UserHeader>
        <Home style="backSlide"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/login">
        <UserHeader></UserHeader>
        <LoginForm style="upsertformsShow"></LoginForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/tests/:id">
        <UserHeader></UserHeader>
        <AllTests ></AllTests>
        </Route>
        <Route path="/reset">
        <UserHeader></UserHeader>
        <EmailToReset style="upsertformsShow"></EmailToReset>
        <Footer></Footer>
        </Route>
        <Route path="/register">
        <UserHeader></UserHeader>
        <RegisterForm style="upsertformShow"></RegisterForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/forgotPassword/:id">
        <UserHeader></UserHeader>
        <ForgetPassword style="upsertformsShow"></ForgetPassword>
        <Footer></Footer>
        </Route>
        <Route path="/confirm/:code">
        <UserHeader></UserHeader>
        <ConfirmRegistration style="upsertformShow"></ConfirmRegistration>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/subjects">
        <UserHeader></UserHeader>
        <AllSubjects></AllSubjects>
        <Footer></Footer>
        </Route>
        <Route path="/errorConnection">
         <SerwerError></SerwerError>
        </Route>
        
             </Switch>
           </div>
         )|| ( userRole==="Teacher"&&
           <div>
                         <Switch>
        <Route path="/registerSubject">
        <UserHeader></UserHeader>
        <Subject style="upsertformsShow"></Subject>
        <Footer></Footer>
        </Route>
        
        <Route path="/teacherProfile">
        <UserHeader></UserHeader>
            <TeacherProfile></TeacherProfile>
            <Footer></Footer>
        </Route>
        <Route path="/allFiles">
        <UserHeader></UserHeader>
            <AllFiles></AllFiles>
            <Footer></Footer>
        </Route>
        <Route path="/forgotPassword/:id">
        <UserHeader></UserHeader>
        <ForgetPassword style="upsertformsShow"></ForgetPassword>
        <Footer></Footer>
        </Route>
        <Route path="/registerTest">
        <UserHeader></UserHeader>
        <AddTest style="upsertformsShow"></AddTest>
        </Route>
        <Route path="/tests/:id">
        <UserHeader></UserHeader>
        <AllTests ></AllTests>
        </Route>
        <Route path="/editTest/:id">
        <UserHeader></UserHeader>
        <EditTest ></EditTest>
        <Footer></Footer>
        </Route>
        <Route path="/addTestQuestions">
        <UserHeader></UserHeader>
            <AddTestQuestions style="upsertformsShow"></AddTestQuestions>
            <Footer></Footer>
        </Route>
        <Route path="/addTestQuestionSingleTest">
        <UserHeader></UserHeader>
            <AddTestQuestionSingleTest style="upsertformsShow"></AddTestQuestionSingleTest>
            <Footer></Footer>
        </Route>
        <Route path="/addTestQuestion">
        <UserHeader></UserHeader>
            <AddTestQuestion style="upsertformsShow"></AddTestQuestion>
            <Footer></Footer>
        </Route>
        <Route path="/showTestModify/:id">
        <UserHeader></UserHeader>
            <ShowTestToModify style="upsertformsShow"></ShowTestToModify>
        </Route>
        <Route path="/showDeletedQuestions/:id">
        <UserHeader></UserHeader>
            <DeletedQuestions style="upsertformsShow"></DeletedQuestions>
        </Route>
        <Route path="/editTestQuestions/:id">
        <UserHeader></UserHeader>
            <EditTestQuestionAnswer style="editTestQuestionsforms"></EditTestQuestionAnswer>
            <Footer></Footer>
        </Route>
        <Route path="/editTestQuestionsSingle/:id">
        <UserHeader></UserHeader>
            <EditTestQuestionAnswerSingleTest style="editTestQuestionsforms"></EditTestQuestionAnswerSingleTest>
            <Footer></Footer>
        </Route>
             <Route path="/editSubject/:id">
        <UserHeader></UserHeader>
            <EditSubject></EditSubject>
            <Footer></Footer>
        </Route>
        <Route path="/home">
        <UserHeader></UserHeader>
        <Home style="backSlide"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/login">
        <UserHeader></UserHeader>
        <LoginForm style="upsertformsShow"></LoginForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/register">
        <UserHeader></UserHeader>
        <RegisterForm style="upsertformShow"></RegisterForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/confirm/:code">
        <UserHeader></UserHeader>
        <ConfirmRegistration style="upsertformShow"></ConfirmRegistration>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/reset">
        <UserHeader></UserHeader>
        <EmailToReset style="upsertformsShow"></EmailToReset>
        <Footer></Footer>
        </Route>
        <Route path="/subjects">
        <UserHeader></UserHeader>
        <AllSubjects></AllSubjects>
        <Footer></Footer>
        </Route>
        <Route path="/errorConnection">
         <SerwerError></SerwerError>
        </Route>
        </Switch>
           </div>
         ) ||(userRole==="Admin"&&
         <div>
           <Route path="/home">
           <UserHeader></UserHeader>
            <Home style="backSlide"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
           <Route path="/adminProfile">
           <UserHeader></UserHeader>
            <AdminProfile></AdminProfile>
            <Footer></Footer>
           </Route>
         </div>
         )
         ||
            <Switch>
              
              <Route exact path="/">
        <UserHeader></UserHeader>
        <Home style="backSlide"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/home">
        <UserHeader></UserHeader>
        <Home style="backSlide"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/errorConnection">
         <SerwerError></SerwerError>
        </Route>
        <Route path="/reset">
        <UserHeader></UserHeader>
        <EmailToReset style="upsertformsShow"></EmailToReset>
        <Footer></Footer>
        </Route>
        <Route path="/forgotPassword/:id">
        <UserHeader></UserHeader>
        <ForgetPassword style="upsertformsShow"></ForgetPassword>
        <Footer></Footer>
        </Route>
        <Route path="/login">
        <UserHeader></UserHeader>
        <LoginForm style="upsertformsShow"></LoginForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/tests/:id">
        <UserHeader></UserHeader>
        <AllTests ></AllTests>
        </Route>
        <Route path="/register">
        <UserHeader></UserHeader>
        <RegisterForm style="upsertformShow"></RegisterForm>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/confirm/:code">
        <UserHeader></UserHeader>
        <ConfirmRegistration style="upsertformShow"></ConfirmRegistration>
        <Home style="blur"></Home>
        <Footer style="contentFooterHome"></Footer>
        </Route>
        <Route path="/subjects">
        <UserHeader></UserHeader>
        <AllSubjects></AllSubjects>
        <Footer></Footer>
        </Route>
        </Switch>
}
      
    </Router>
       
  );
}


export default App;
