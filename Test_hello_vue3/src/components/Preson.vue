<template>
<div class="preson">
    <h2>姓名：{{ student.name }}</h2>
    <h2>性别：{{ student.sex }}</h2>
    <h2>年龄：{{ student.age }}</h2>

    <button @click="set_student">按钮</button>
</div>
</template>

<script setup>
import { ref } from 'vue';

let student=ref({
    name:"张三",
    sex:"男",
age:"20"
})   


function set_student(){
    student.value={
    name:"李四",
    sex:"女",
age:"19"
}
console.log(student);
}



</script>

<style scoped>

</style>