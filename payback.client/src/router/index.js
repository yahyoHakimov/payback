import { createRouter, createWebHistory } from 'vue-router';
import AuthCallback from '../components/AuthCallback.vue';
import CreateLoan from '../components/CreateLoan.vue';
import CreateContract from '../components/CreateContract.vue';
import Notifications from '../components/Notification.vue';
import Login from '../components/Login.vue';
import Register from '../components/Register.vue';
import Layout from '../components/Layout.vue';

const routes = [
    { path: '/', redirect: '/login' },
    { path: '/auth/callback', component: AuthCallback },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    {
        path: '/',
        component: Layout,
        children: [
            { path: '/create-loan', component: CreateLoan },
            { path: '/create-contract', component: CreateContract },
            { path: '/notifications', component: Notifications },
        ]
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

// Navigation guard to protect routes
router.beforeEach((to, from, next) => {
    const publicPages = ['/login', '/register', '/auth/callback'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('user');

    if (authRequired && !loggedIn) {
        return next('/login');
    }

    next();
});

export default router;
