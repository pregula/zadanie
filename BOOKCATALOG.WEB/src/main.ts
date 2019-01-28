import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import signalR from '@aspnet/signalr';
import routes from './routes';
import 'bootstrap/dist/css/bootstrap.css';

Vue.config.productionTip = true;

Vue.use(VueRouter);

const router = new VueRouter({ mode: 'history', routes });

new Vue({
    router,
    render: h => h(App)
}).$mount('#app');
