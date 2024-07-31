import { createRouter, createWebHistory } from 'vue-router';
import AuthCallback from '../components/AuthCallback.vue';
import CreateLoan from '../components/CreateLoan.vue';
import CreateContract from '../components/CreateContract.vue';
import Notifications from '../components/Notification.vue';
import Login from '../components/Login.vue';
import Register from '../components/Register.vue';

const routes = [
    { path: '/', redirect: '/login' },
    { path: '/auth/callback', component: AuthCallback },
    { path: '/create-loan', component: CreateLoan },
    { path: '/create-contract', component: CreateContract },
    { path: '/notifications', component: Notifications },
    { path: '/login', component: Login },
    { path: '/register', component: Register }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
