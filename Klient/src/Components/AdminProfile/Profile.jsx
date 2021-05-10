import React from 'react'
import { Component } from 'react';
import Api from '../API/AuthorizationApi'
import Swal from "sweetalert2"

export default class AdminProfile extends Component{

        constructor(){
                super();
                this.GetUsers();
                this.state={
                        users:[]
                }
        }

        GetUsers = async () => {
                let api  = new Api();
                const result =  await api.fetchUsers();
                this.setState({users:result})
        }
        BlockUser(id){
                let api = new Api();
                api.deleteAccount(id);
        }
        Active(id){
                let api = new Api();
                api.Active(id);
        }
        render(){
                return(
                        <table class="table table-dark">
                        <thead>
                        <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Surname</th>
                        <th scope="col">Email</th>
                        <th scope="col">Account</th>
                        </tr>
                        </thead>
                        <tbody>
                         {this.state.users.map(user=>(
                                 <tr>
                                 <td>{user.firstName}</td>
                                 <td>{user.lastName}</td>
                                 <td>{user.email}</td>
                                 <td>{user.statusOfVerification}</td>
                                 <td><button class="btn btn-danger" onClick={()=>this.BlockUser(user.id)}>Block</button>&nbsp;    |   
                                 &nbsp;&nbsp;<button class="btn btn-success" onClick={()=>this.Active(user.id)}>Active</button></td>
                                 </tr>
                         ))}
                        </tbody>
                        </table>
                );
        }
}