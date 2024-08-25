<template>
    <div class="flex h-screen">
        <!-- Sidebar -->
        <Sidebar v-if="isLoggedIn" class="w-1/5 bg-gray-200" />

        <!-- Main Content -->
        <div class="flex-1 flex flex-col">
            <!-- Top bar (optional) -->
            <Home v-if="isLoggedIn" />

            <!-- Main Content Area -->
            <div id="app" class="flex-1 bg-gray-100">
                <router-view />
            </div>
        </div>
    </div>
</template>

<script>
    import Register from '@/components/Register.vue';
    import Login from '@/components/Login.vue';
    import CreateLoan from '@/components/CreateLoan.vue';
    import CreateContract from '@/components/CreateContract.vue';
    import Notifications from '@/components/Notification.vue';
    import Home from '@/components/Home.vue';
    import Sidebar from '@/components/Sidebar.vue';

    export default {
        name: 'App',
        components: {
            Register,
            Login,
            CreateLoan,
            CreateContract,
            Notifications,
            Home,
            Sidebar
        },
        data() {
            return {
                loggedIn: false,
                showRegister: false,
                googleAuth: null,
            };
        },
        mounted() {
            this.initGoogleAuth();
        },
        methods: {
            onRegisterSuccess() {
                this.loggedIn = true;
            },
            onLoginSuccess() {
                this.loggedIn = true;
            },
            toggleForms() {
                this.showRegister = !this.showRegister;
            },
            initGoogleAuth() {
                gapi.load('auth2', () => {
                    this.googleAuth = gapi.auth2.init({
                        client_id: 'YOUR_GOOGLE_CLIENT_ID.apps.googleusercontent.com',
                    });
                });
            },
            googleSignIn() {
                this.googleAuth.signIn().then(googleUser => {
                    const profile = googleUser.getBasicProfile();
                    console.log('ID: ' + profile.getId());
                    console.log('Name: ' + profile.getName());
                    console.log('Image URL: ' + profile.getImageUrl());
                    console.log('Email: ' + profile.getEmail());

                    this.loggedIn = true;
                }).catch(error => {
                    console.log('Google sign-in error:', error);
                });
            },
        },
    };
</script>