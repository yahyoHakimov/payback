<template>
    <div class="bg-white p-8 rounded-lg shadow-md max-w-md w-full">
        <div class="flex justify-center mb-6">
        </div>
        <h2 class="text-2xl font-bold mb-6 text-center text-gray-900">Welcome back! Please sign in to continue.</h2>
        <form @submit.prevent="login">
            <div class="mb-4">
                <label for="email" class="block text-sm font-medium text-gray-700">Email</label>
                <input v-model="email" id="email" type="email" placeholder="Enter your email" required
                       class="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500">
            </div>
            <div class="mb-6 relative">
                <label for="password" class="block text-sm font-medium text-gray-700">Password</label>
                <input v-model="password" id="password" :type="showPassword ? 'text' : 'password'" placeholder="Enter your password" required
                       class="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500">
                <button type="button" @click="togglePassword" class="absolute inset-y-0 right-0 pr-3 flex items-center text-sm leading-5">
                    <eye-icon v-if="!showPassword" class="h-5 w-5 text-gray-500" />
                    <eye-off-icon v-else class="h-5 w-5 text-gray-500" />
                </button>
            </div>
            <button type="submit" :disabled="loading"
                    class="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                <span v-if="loading" class="spinner-border spinner-border-sm mr-2"></span>
                Sign In
            </button>
        </form>
        <div class="mt-4">
            <button @click="googleSignIn" :disabled="loading"
                    class="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                Sign in with Google
            </button>
        </div>
        <p class="mt-4 text-center text-sm text-gray-600">
            Don't have an account?
            <router-link to="/register" class="font-medium text-indigo-600 hover:text-indigo-500">Sign Up</router-link>
        </p>
    </div>
</template>

<script>
    import { EyeIcon, EyeOffIcon } from '@heroicons/vue/solid'

    export default {
        components: {
            EyeIcon,
            EyeOffIcon
        },
        data() {
            return {
                email: '',
                password: '',
                showPassword: false,
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
            togglePassword() {
                this.showPassword = !this.showPassword;
            },
            async login() {
                this.loading = true;
                try {
                    const response = await fetch('https://localhost:7160/api/User/login', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            email: this.email,
                            password: this.password,
                        }),
                    });
                    if (response.ok) {
                        this.message = 'User logged in successfully';
                        this.success = true;
                        localStorage.setItem('user', JSON.stringify(await response.json()));
                        this.$router.push('/');
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
                    this.$router.push('/');
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