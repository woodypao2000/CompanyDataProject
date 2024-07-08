import { createRouter, createWebHistory } from 'vue-router';
//import App from '../App.vue'; //避免重複渲染
import content from '../content.vue'
import dataForm from '../dataForm.vue';

const router = createRouter({
  history: createWebHistory(),
  routes:[ 
         //  { path: '/',component: App },// 避免重複渲染
           {name:'dataForm', path: '/dataForm',component: dataForm},
           { name:'content', path: '/content',component: content}
        ]

});

export default router;