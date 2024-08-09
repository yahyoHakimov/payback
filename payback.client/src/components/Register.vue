<template>
    <div class="bg-white p-8 rounded-lg shadow-md mb-6">
        <h2 class="text-2xl font-bold mb-6 text-gray-900">Register</h2>
        <form @submit.prevent="register">
            <div class="mb-4">
                <label for="username" class="block text-gray-700">Username</label>
                <input v-model="username" id="username" type="text" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <div class="mb-4">
                <label for="password" class="block text-gray-700">Password</label>
                <input v-model="password" id="password" type="password" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <div class="mb-4">
                <label for="email" class="block text-gray-700">Email</label>
                <input v-model="email" id="email" type="email" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <button type="submit" class="bg-blue-600 text-white px-4 py-2 rounded-lg w-full hover:bg-blue-700">Register</button>
        </form>
        <p class="text-center mt-4">
            Already have an account?
            <router-link to="/login" class="text-blue-600 underline">Login here</router-link>
        </p>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                username: '',
                password: '',
                email: '',
                loading: false,
                message: '',
                success: false,
            };
        },
        methods: {
            async register() {
                this.loading = true;
                try {
                    const response = await fetch('https://localhost:7160/api/User/register', {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            username: this.username,
                            password: this.password,
                            email: this.email,
                        }),
                    });
                    if (response.ok) {
                        this.message = 'User registered successfully';
                        this.success = true;
                        this.$emit('register-success');
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


<style scoped>
    /* Add your styles here */
</style>
