<template>
    <div class="min-h-screen flex items-center justify-center bg-gray-100">
        <div class="bg-white shadow-md rounded-lg p-8 max-w-md w-full">
            <div v-if="step === 1">
                <h2 class="text-2xl font-semibold mb-4">Welcome to Our App</h2>
                <p class="mb-4">Discover our key features:</p>
                <ul class="list-disc list-inside mb-6">
                    <li>Automated deductions for easy repayments</li>
                    <li>Secure transactions with bank-level encryption</li>
                    <li>Legal assurances for all loans</li>
                </ul>
                <button @click="nextStep" class="w-full bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded">
                    Next
                </button>
            </div>

            <div v-if="step === 2">
                <h2 class="text-2xl font-semibold mb-4">Sign Up</h2>
                <form @submit.prevent="signUp">
                    <div class="mb-4">
                        <label for="name" class="block text-sm font-medium text-gray-700">Name</label>
                        <input type="text" id="name" v-model="signUpForm.name" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                    </div>
                    <div class="mb-4">
                        <label for="email" class="block text-sm font-medium text-gray-700">Email</label>
                        <input type="email" id="email" v-model="signUpForm.email" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                    </div>
                    <div class="mb-6">
                        <label for="password" class="block text-sm font-medium text-gray-700">Password</label>
                        <input type="password" id="password" v-model="signUpForm.password" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                    </div>
                    <button type="submit" class="w-full bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded">
                        Sign Up
                    </button>
                </form>
                <div class="mt-4 text-center">
                    <p>Or sign up with:</p>
                    <div class="flex justify-center space-x-4 mt-2">
                        <button class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded">
                            Google
                        </button>
                        <button class="bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                            Facebook
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      step: 1,
      signUpForm: {
        name: '',
        email: '',
        password: ''
      }
    }
  },
  methods: {
    nextStep() {
      this.step++
    },
    signUp() {
      // Implement sign up logic
      console.log('Signing up:', this.signUpForm)
    }
  }
}
</script>