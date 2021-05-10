import React from 'react'
import Api from '../API/CheckTestApi'
import css from './Timer.css'
export default function Timer(time){


const [minutes, setMinutes] = React.useState(parseInt(time.minutes));
const [seconds, setSeconds] = React.useState(parseInt(time.seconds));

async function CheckTest(){
        let api = new Api();
        let list = new Array();
        console.log(time);
        if(localStorage.length-2===0){
          var obj = JSON.stringify({
            QuestionId:sessionStorage.getItem("QuestionId"),
            UserId:time.userId,
            isCorrectA:false,
            isCorrectB:false,
            isCorrectC:false
          })
          list.push(JSON.parse(obj))
        }
        console.log(localStorage.length)
        if(localStorage.length>2){
                for(var i = localStorage.length-2 ;i>0;i--)
                {
                  list.push(JSON.parse(localStorage.getItem(i-1)))
                }
                api.SendToCheckTest(list);
                  
        }
        console.log(list);
        api.SendToCheckTest(list); 
      }
        // Third Attempts
        React.useEffect(() => {
          const minute =
            minutes >= 0 && setInterval(() => setSeconds(seconds - 1), 1000);
            if(seconds===0){
                    setMinutes(minutes-1);
                    setSeconds(60);
            }
            if(minutes==0&&seconds==0){
                CheckTest();
                setMinutes(0);
                    setSeconds(0);
            }
          return () => clearInterval(minute);
        }, [minutes,seconds]);
      
        return (
          <div >
            <div><p class="timer">{minutes}m {seconds}s</p> </div>
          </div>
        );
}
      