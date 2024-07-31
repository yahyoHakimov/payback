<template>
    <div id="app" class="min-h-screen bg-gray-100 flex flex-col items-center justify-center">
        <!--
        <header class="text-center mb-10">
               <h1 class="text-4xl font-bold text-gray-900">My Application</h1>
           </header>

        -->
        <router-view></router-view>
    </div>

</template>

<script>
    import Register from './components/Register.vue';
    import Login from './components/Login.vue';
    import CreateLoan from './components/CreateLoan.vue';
    import CreateContract from './components/CreateContract.vue';
    import Notifications from './components/Notification.vue';

    export default {
        name: 'App',
        components: {
            Register,
            Login,
            CreateLoan,
            CreateContract,
            Notifications,
        },
        data() {
            return {
                loggedIn: false,
                showRegister: false, // initially show login form
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

                    // Here you can handle the authentication and pass the token to your backend
                    this.loggedIn = true;
                }).catch(error => {
                    console.log('Google sign-in error:', error);
                });
            },
        },
    };
</script>
