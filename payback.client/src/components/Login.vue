<template>
    <div class="bg-white p-8 rounded-lg shadow-md mb-6">
        <h2 class="text-2xl font-bold mb-6 text-gray-900">Login</h2>
        <form @submit.prevent="login">
            <div class="mb-4">
                <label for="username" class="block text-gray-700">Username</label>
                <input v-model="username" id="username" type="text" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" :disabled="loading" />
            </div>
            <div class="mb-4">
                <label for="password" class="block text-gray-700">Password</label>
                <input v-model="password" id="password" type="password" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" :disabled="loading" />
            </div>
            <button type="submit" class="bg-blue-600 text-white px-4 py-2 rounded-lg w-full hover:bg-blue-700" :disabled="loading">
                <span v-if="loading" class="spinner-border spinner-border-sm"></span>
                Login
            </button>
            <p v-if="message" :class="{'text-green-600': success, 'text-red-600': !success}" class="mt-4">{{ message }}</p>
        </form>
        <button @click="googleSignIn" class="bg-red-600 text-white px-4 py-2 rounded-lg w-full hover:bg-red-700 mt-4" :disabled="loading">
            <span v-if="loading" class="spinner-border spinner-border-sm"></span>
            Sign in with Google
        </button>
        <p class="text-center mt-4">
            Don't have an account?
            <router-link to="/register" class="text-blue-600 underline">Register here</router-link>
        </p>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                username: '',
                password: '',
                message: '',
                success: false,
                loading: false,
                googleAuth: null,
            };
        },
        mounted() {
            this.initGoogleAuth();
        },
        methods: {
            async login() {
                this.loading = true;
                try {
                    const response = await fetch('https://34.131.86.117/api/User/login', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            username: this.username,
                            password: this.password,
                        }),
                    });
                    if (response.ok) {
                        this.message = 'User logged in successfully';
                        this.success = true;
                        localStorage.setItem('user', JSON.stringify(await response.json()));
                        this.$router.push('/create-loan');
                    } else {
                        this.message = 'Login failed. Please check your credentials.';
                        this.success = false;
                    }
                } catch (error) {
                    this.message = 'An error occurred. Please try again.';
                    this.success = false;
                } finally {
                    this.loading = false;
                }
            },
            initGoogleAuth() {
                gapi.load('auth2', () => {
                    this.googleAuth = gapi.auth2.init({
                        client_id: 'YOUR_GOOGLE_CLIENT_ID.apps.googleusercontent.com',
                    });
                });
            },
            googleSignIn() {
                this.loading = true;
                this.googleAuth.signIn().then(googleUser => {
                    const profile = googleUser.getBasicProfile();
                    console.log('ID: ' + profile.getId());
                    console.log('Name: ' + profile.getName());
                    console.log('Image URL: ' + profile.getImageUrl());
                    console.log('Email: ' + profile.getEmail());

                    // Here you can handle the authentication and pass the token to your backend
                    localStorage.setItem('user', JSON.stringify(profile));
                    this.$router.push('/create-loan');
                }).catch(error => {
                    console.log('Google sign-in error:', error);
                }).finally(() => {
                    this.loading = false;
                });
            },
        },
    };
</script>

<style scoped>
    .spinner-border {
        width: 1rem;
        height: 1rem;
        border: 0.25em solid currentColor;
        border-right-color: transparent;
        border-radius: 50%;
        display: inline-block;
        vertical-align: text-bottom;
        animation: spinner-border 0.75s linear infinite;
    }

    @keyframes spinner-border {
        to {
            transform: rotate(360deg);
        }
    }
</style>
