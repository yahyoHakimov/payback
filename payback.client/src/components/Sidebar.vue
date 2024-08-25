<template>
    <aside class="w-20 bg-white shadow-md">
        <div class="flex flex-col items-center h-full py-4">
            <div class="mb-8">
            </div>
            <nav class="flex-1 space-y-8">
                <router-link to="/" class="block p-3 text-gray-600 hover:bg-gray-100 rounded-lg">
                    <HomeIcon class="w-6 h-6" />
                </router-link>
                <router-link to="/loans" class="block p-3 text-gray-600 hover:bg-gray-100 rounded-lg">
                    <CurrencyDollarIcon class="w-6 h-6" /> <!-- Changed to CurrencyDollarIcon for Loans/Debt -->
                </router-link>
                <router-link to="/notifications" class="block p-3 text-gray-600 hover:bg-gray-100 rounded-lg">
                    <BellIcon class="w-6 h-6" />
                </router-link>
            </nav>
            <div>
                <router-link to="/settings" class="block p-3 text-gray-600 hover:bg-gray-100 rounded-lg">
                    <CogIcon class="w-6 h-6" />
                </router-link>
            </div>
        </div>
    </aside>
</template>

<script>
    import { HomeIcon, UserIcon, CurrencyDollarIcon, CogIcon, BellIcon } from '@heroicons/vue/outline'

    export default {
        name: 'Sidebar',
        components: {
            HomeIcon,
            UserIcon, // New icon for Profile
            CurrencyDollarIcon, // New icon for Loans/Debt
            CogIcon,
            BellIcon
        }
    }

</script>
