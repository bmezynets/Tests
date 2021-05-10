
import Api from '../API/CheckTestApi'
import React, { useMemo, useState } from "react";
import { Redirect } from 'react-router-dom';

export default function Result(){
     async function redirectToRewiew(){
             window.location.assign("/rewiewTest");
     }
     return {redirectToRewiew};
}