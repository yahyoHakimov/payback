<template>
    <div class="bg-white p-8 rounded-lg shadow-md max-w-md w-full">
        <div class="flex justify-center mb-6">
        </div>
        <h2 class="text-2xl font-bold mb-6 text-center text-gray-900">Welcome to our app! Please sign up to continue.</h2>
        <form @submit.prevent="register">
            <div class="mb-4">
                <label for="name" class="block text-sm font-medium text-gray-700">Name</label>
                <input v-model="name" id="name" type="text" placeholder="Enter your name" required
                       class="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500">
            </div>
            <div class="mb-4">
                <label for="email" class="block text-sm font-medium text-gray-700">Email</label>
                <input v-model="email" id="email" type="email" placeholder="Enter your email" required
                       class="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500">
            </div>
            <div class="mb-4 relative">
                <label for="password" class="block text-sm font-medium text-gray-700">Password</label>
                <input v-model="password" id="password" :type="showPassword ? 'text' : 'password'" placeholder="Enter your password" required
                       class="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500">
                <button type="button" @click="togglePassword" class="absolute inset-y-0 right-0 pr-3 flex items-center text-sm leading-5">
                    <eye-icon v-if="!showPassword" class="h-5 w-5 text-gray-500" />
                    <eye-off-icon v-else class="h-5 w-5 text-gray-500" />
                </button>
            </div>
            <div class="mb-6">
                <label class="inline-flex items-center">
                    <input type="checkbox" v-model="agreeTerms" class="form-checkbox h-5 w-5 text-indigo-600" required>
                    <span class="ml-2 text-sm text-gray-700">I agree to the terms and conditions</span>
                </label>
            </div>
            <button type="submit" :disabled="!agreeTerms"
                    class="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 disabled:opacity-50 disabled:cursor-not-allowed">
                Sign Up
            </button>
        </form>
        <p class="mt-4 text-center text-sm text-gray-600">
            Already have an account?
            <router-link to="/login" class="font-medium text-indigo-600 hover:text-indigo-500">Sign In</router-link>
        </p>
    </div>
</template>

<script>
    import { EyeIcon, EyeOffIcon } from '@heroicons/vue/solid';

    export default {
        components: {
            EyeIcon,
            EyeOffIcon
        },
        data() {
            return {
                name: '',
                email: '',
                password: '',
                agreeTerms: false,
                showPassword: false,
                loading: false,
                message: '',
                success: false,
            };
        },
        methods: {
            togglePassword() {
                this.showPassword = !this.showPassword;
            },
            async register() {
                if (!this.agreeTerms) {
                    this.message = 'Please agree to the terms and conditions';
                    return;
                }
                this.loading = true;
                try {
                    const response = await fetch('https://localhost:7160/api/User/register', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            username: this.name,
                            password: this.password,
                            email: this.email,
                        }),
                    });
                    if (response.ok) {
                        this.message = 'User registered successfully';
                        this.success = true;
                        this.$router.push('/login');
                    } else {
                        this.message = 'Registration failed';
                        this.success = false;
                    }
                } catch (error) {
                    this.message = 'An error occurred. Please try again.';
                    this.success = false;
                } finally {
                    this.loading = false;
                }
            },
        },
    };
</script>