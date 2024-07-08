import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
//import login from './login.vue'
import router from './router/index';  // 引入 router
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import './assets/CSS/global.scss'
const app = createApp(App);
app.use(router);
app.use(ElementPlus);
app.mount('#app');

