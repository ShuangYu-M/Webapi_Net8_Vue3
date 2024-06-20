<template>
  <div class="container">
    <h1>学生信息管理系统</h1>
    <button @click="fetchStudents">读取</button>
    <button @click="createStudent">创建</button>
    <table class="table">
      <thead>
        <tr>
          <th>姓名</th>
          <th>年龄</th>
          <th>操作</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="student in students" :key="student.id">
          <td>{{ student.name }}</td>
          <td>{{ student.age }}</td>
          <td>
            <button @click="updateStudent(student)">更新</button>
            <button @click="deleteStudent(student.id)">删除</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
//使用ref所定义的数据取值时需要加上value
//但是用ref定义的对象类型就可以直接进行替换操作，这个时候页面上还是响应式数据
import { ref } from "vue"; //可以定义：基本类型、对象类型的响应式数据

//使用reactive定义的对象不能直接绑定新的对象，可以用Object.assign(原对象,新对象)进行替代
import { reactive } from "vue"; //只能定义：对象类型的响应式数据

//axios
import axios from "axios";

//引入配置好的axios实例
import request from "@/api/request";

let students = ref([]);
// let students = reactive([]);

//查询
async function fetchStudents() {
  /* get请求
      const params = {这里存放的是一些参数，主要将这些参数携带在url之后传递给后端}
      const config = {这里存放的是有关请求头的一些参数，例如：token}
      axios.get(url,params,config).then(res => {
          console.log("axios的get请求方法！");
      });
  
      */

  //使用配置好的axios实例
  const response = await request.get("v1/GetStudent");
  console.log(response);
  console.log(response.data.message);
  students.value=response.data.data;

  const loginCode = await request.get("v2/loginCode");
  console.log(loginCode);
  console.log(loginCode.data.message);


  //reactive需要用这种写法把原本的对象给替换掉
//   Object.assign(students, response.data.data);
}

//新增
async function createStudent() {
  /* post请求

      //const params = {这里存放的是一些参数，主要将这些参数携带在url之后传递给后端}
      const params = {id=1,name="张三"}
      //const config = {这里存放的是有关请求头的一些参数，例如：token}
      const config = {headers:{token:'hello_Vue3'}}

      axios.post(url,params,config).then(res => {
          console.log("axios的post请求方法！");
      });
  
      */

  const response = await request
    .post("v1/insertUser", {
      students: [
        { Id: "3", Name: "Vue3" },
        { Id: "8", Name: ".net8.0" },
        { Id: "7", Name: "WebApi" },
      ],
    })
    .then((res) => {
      console.log(res);
      console.log(res.data.message);
    });
  fetchStudents();
}

//修改
async function updateStudent(student) {
  /* put请求
      const params = {这里存放的是一些参数，主要将这些参数携带在url之后传递给后端}
      const config = {这里存放的是有关请求头的一些参数，例如：token}
      axios.post(url,params,config).then(res => {
          console.log("axios的put请求方法！");
      });
  
      */

  const response = await request
    .put("v1/updateUser", {
        Id: student.id,
        Name: "update"+student.id,
      
    })
    .then((res) => {
      console.log(res);
      console.log(res.data.message);
    });
  fetchStudents();
}

//删除
async function deleteStudent(id) {
  /* delete请求
      const params = {这里存放的是一些参数，主要将这些参数携带在url之后传递给后端}
      const config = {这里存放的是有关请求头的一些参数，例如：token}
      axios.delete(url,params,config).then(res => {
          console.log("axios的delete请求方法！");
      });
  
      */

  const response = await request
    .delete("v1/deleteUser/"+id)
    .then((res) => {
      console.log(res);
      console.log(res.data.message);
    })
    .catch((error)=>{
        console.log(error);
    });
  fetchStudents();
}
</script>

<style>
.container {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  font-family: Arial, sans-serif;
}

.table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

.table th,
.table td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}

.table th {
  background-color: #f2f2f2;
}

.table tr:nth-child(even) {
  background-color: #f9f9f9;
}

button {
  padding: 10px 15px;
  margin-right: 5px;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}
</style>
