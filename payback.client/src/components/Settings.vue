<template>
    <div class="p-6">
        <h1 class="text-2xl font-semibold mb-6">Settings</h1>

        <!-- Profile Management -->
        <div class="bg-white shadow rounded-lg p-6 mb-6">
            <h2 class="text-xl font-semibold mb-4">Profile Management</h2>
            <form @submit.prevent="updateProfile">
                <div class="mb-4">
                    <label for="name" class="block text-sm font-medium text-gray-700">Name</label>
                    <input type="text"
                           id="name"
                           v-model="profile.name"
                           :class="inputClass"
                           class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                </div>
                <div class="mb-4">
                    <label for="email" class="block text-sm font-medium text-gray-700">Email</label>
                    <input type="email"
                           id="email"
                           v-model="profile.email"
                           :class="emailClass"
                           class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                    <p v-if="!isValidEmail(profile.email)" class="text-red-600 text-sm mt-2">Please enter a valid email address.</p>
                </div>
                <div class="mb-4">
                    <label for="bankAccount" class="block text-sm font-medium text-gray-700">Bank Account</label>
                    <input type="text"
                           id="bankAccount"
                           v-model="profile.bankAccount"
                           class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                </div>
                <button type="submit"
                        :disabled="!isFormValid"
                        class="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded disabled:opacity-50 disabled:cursor-not-allowed">
                    Update Profile
                </button>
            </form>
        </div>

        <!-- Security Settings -->
        <div class="bg-white shadow rounded-lg p-6 mb-6">
            <h2 class="text-xl font-semibold mb-4">Security Settings</h2>
            <div class="mb-4 flex space-x-2">
                <button @click="changePassword"
                        class="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded">
                    Change Password
                </button>
                <button @click="changePIN"
                        class="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded">
                    Change PIN
                </button>
            </div>
            <div class="flex items-center">
                <input type="checkbox"
                       id="biometric"
                       v-model="security.biometricEnabled"
                       class="mr-2">
                <label for="biometric" class="text-sm font-medium text-gray-700">
                    Enable Biometric Authentication
                </label>
            </div>
        </div>

        <!-- Legal Documentation -->
        <div class="bg-white shadow rounded-lg p-6">
            <h2 class="text-xl font-semibold mb-4">Legal Documentation</h2>
            <ul class="list-disc list-inside">
                <li><a href="#" class="text-blue-600 hover:text-blue-800">Terms of Service</a></li>
                <li><a href="#" class="text-blue-600 hover:text-blue-800">Privacy Policy</a></li>
                <li><a href="#" class="text-blue-600 hover:text-blue-800">Loan Agreement Template</a></li>
            </ul>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                profile: {
                    name: '',
                    email: '',
                    bankAccount: ''
                },
                security: {
                    biometricEnabled: false
                },
                isFormValid: true
            }
        },
        computed: {
            inputClass() {
                return this.profile.name ? 'border-green-300' : 'border-red-300';
            },
            emailClass() {
                return this.isValidEmail(this.profile.email) ? 'border-green-300' : 'border-red-300';
            }
        },
        methods: {
            updateProfile() {
                if (!this.isFormValid) return;
                // Logic to handle profile update
                console.log('Profile updated:', this.profile);
            },
            changePassword() {
                // Logic for changing password
                console.log('Changing password');
            },
            changePIN() {
                // Logic for changing PIN
                console.log('Changing PIN');
            },
            isValidEmail(email) {
                // Simple email validation regex
                const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@(([^<>()[\]\.,;:\s@"]+\.)+[^<>()[\]\.,;:\s@"]{2,})$/i;
                return re.test(email);
            }
        },
        watch: {
            'profile.name'(value) {
                this.isFormValid = value.length > 0 && this.isValidEmail(this.profile.email);
            },
            'profile.email'(value) {
                this.isFormValid = this.profile.name.length > 0 && this.isValidEmail(value);
            }
        }
    }
</script>

<style scoped>
    .disabled:opacity-50 {
        opacity: 0.5;
    }
</style>
