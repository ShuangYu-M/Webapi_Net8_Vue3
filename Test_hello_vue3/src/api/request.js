
//
import axios from "axios";

//创建axios实例
const service=axios.create({
    baseURL:"http://localhost:5050/api", //后端API基础URL
    timeout:5000 //请求超时时间
});

//请求拦截器
service.interceptors.request.use(
    config=>{
        const token=localStorage.getItem('token');//假设token存储在localStorage中
        // const token='Bearer 147258369';
        if(token){
            config.headers['Authorization']=`Bearer ${token}`;
        }
        return config;
    },
    error=>{
        return  Promise.reject(error);
    }
);


//响应拦截器
service.interceptors.response.use(
    response=>{
        return response;
    },
    error=>{
        return Promise.reject(error);
    }
)


export default service;





