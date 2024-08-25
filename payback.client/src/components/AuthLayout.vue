<template>
    <div class="min-h-screen flex flex-col items-center justify-center bg-gray-100">
        <!-- Injected Route Component (Login/Register) -->
        <router-view />

        <!-- Footer Links (optional) -->
        <div class="mt-8">
            <p class="text-sm text-gray-500">
                &copy; 2024 F&G Group.
                <router-link to="/terms" class="text-indigo-600 hover:text-indigo-500">Terms</router-link>
                <span>&bull;</span>
                <router-link to="/privacy" class="text-indigo-600 hover:text-indigo-500">Privacy</router-link>
            </p>
        </div>
    </div>
</template>

<script>
export default {
  name: 'AuthLayout',
};
</script>

<style scoped>
    /* Customize styles as needed */
</style>
