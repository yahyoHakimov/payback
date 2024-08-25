<template>
    <div class="min-h-screen flex bg-gray-100">
        <!-- Sidebar -->
        <Sidebar class="w-20 bg-white shadow-md" />

        <!-- Main Content -->
        <div class="flex-1 flex flex-col">
            <!-- Top Navigation Bar -->
            <nav class="bg-white shadow-sm">
                <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                    <div class="flex justify-between h-16">
                        <div class="flex">
                            <!-- Logo -->
                            <div class="flex-shrink-0 flex items-center">
                                <span class="text-lg font-bold">F&G Group</span>
                            </div>
                        </div>
                        <div class="flex items-center">
                            <!-- User Profile Icon -->
                            <button @click="userProfile" class="ml-4 bg-white p-1 rounded-full text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500">
                                <UserIcon class="w-6 h-6" />
                            </button>
                            <!-- Log Out Icon -->
                            <button @click="logout" class="ml-4 bg-white p-1 rounded-full text-gray-400 hover:text-red-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500">
                                <svg class="h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                          d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 11-6 0v-1m6-10V5a3 3 0 00-6 0v1" />
                                </svg>
                            </button>
                        </div>
                    </div>
                </div>
            </nav>

            <!-- Main Content Area -->
            <main class="flex-1 overflow-y-auto p-6">
                <router-view />
            </main>
        </div>
    </div>
</template>

<script>
    import Sidebar from "@/components/Sidebar.vue";
    import { UserIcon } from '@heroicons/vue/outline';

    export default {
        name: "Layout",
        components: {
            Sidebar,
            UserIcon
        },
        methods: {
            logout() {
                // Handle logout logic
                localStorage.removeItem('user');
                this.$router.push('/login');
            },
            userProfile() {
                this.$router.push('/profile');
            }
        }
    };
</script>
