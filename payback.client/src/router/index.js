import { createRouter, createWebHistory } from 'vue-router';
import AuthCallback from '@/components/AuthCallback.vue';
import CreateLoan from '@/components/CreateLoan.vue';
import CreateContract from '@/components/CreateContract.vue';
import Notifications from '@/components/Notification.vue';
import Login from '@/components/Login.vue';
import Register from '@/components/Register.vue';
import Layout from '@/components/Layout.vue';
import Home from '@/components/Home.vue';
import AuthLayout from '@/components/AuthLayout.vue'; // New empty layout for auth pages
import UserProfile from '@/components/UserProfile.vue'
import Settings from '@/components/Settings.vue'

const routes = [
    {
        path: '/',
        component: Layout,
        children: [
            { path: '/', component: Home, name: 'Home' },
            { path: 'loans', component: CreateLoan, name: 'CreateLoan' },
            { path: 'create-contract', component: CreateContract, name: 'CreateContract' },
            { path: 'notifications', component: Notifications, name: 'Notifications' },
            { path: 'profile', component: UserProfile, name: 'UserProfile' },
            { path: 'settings', component: Settings, name: 'Settings' },
        ],
        meta: { requiresAuth: true, layout: 'default' }
    },
    {
        path: '/auth/callback',
        component: AuthCallback,
        name: 'AuthCallback',
        meta: { layout: 'empty' }
    },
    {
        path: '/login',
        component: AuthLayout,
        children: [
            { path: '', component: Login }, // Login page will be rendered within AuthLayout.vue
        ],
    },
    {
        path: '/register',
        component: AuthLayout,
        children: [
            { path: '', component: Register }, // Register page will be rendered within AuthLayout.vue
        ],
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

// Navigation Guards
router.beforeEach((to, from, next) => {
    const loggedIn = localStorage.getItem('user');

    // If the route requires authentication and user is not logged in, redirect to login
    if (to.meta.requiresAuth && !loggedIn) {
        return next('/login');
    }

    // If already logged in and trying to access login page, redirect to home
    if (to.name === 'Login' && loggedIn) {
        return next('/');
    }

    next();
});

export default router;
