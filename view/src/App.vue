<template>
  <div>
    <h1></h1>
    <div>
      <el-button type="primary" @click="toPage('/content')">select</el-button>
      <el-button type="primary" @click="toPage('/dataform')">insert</el-button>
      <router-link to ="/">路由連結</router-link>
    </div>
    <hr/>

    <router-view></router-view>

  </div>
</template>
<script setup lang="ts">
import{useRouter} from'vue-router'
const router=useRouter();
const toPage=(url:string)=>{
router.push(url)
//router.push({name:url}) 若index.ts 有設定name 也可用name 來做跳轉
}
</script>
<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
