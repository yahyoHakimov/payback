<!-- Home.vue -->
<template>
    <div>
        <div class="grid grid-cols-1 md:grid-cols-3 gap-8">
            <!-- Overview -->
            <div class="bg-white p-6 rounded-lg shadow">
                <h2 class="text-xl font-semibold mb-4">Overview</h2>
                <div class="space-y-4">
                    <div>
                        <p class="text-3xl font-bold">$12,345.67</p>
                        <p class="text-sm text-gray-600">Current Balance</p>
                    </div>
                    <div>
                        <p class="text-2xl font-semibold">$250.00</p>
                        <p class="text-sm text-gray-600">Upcoming Payments</p>
                    </div>
                    <div>
                        <p class="text-2xl font-semibold">12</p>
                        <p class="text-sm text-gray-600">Recent Transactions</p>
                    </div>
                </div>
            </div>

            <!-- Quick Actions -->
            <div class="bg-white p-6 rounded-lg shadow">
                <h2 class="text-xl font-semibold mb-4">Quick Actions</h2>
                <div class="space-y-4">
                    <button class="w-full bg-black text-white py-2 px-4 rounded-lg flex items-center justify-center">
                        <i class="fas fa-hand-holding-usd mr-2"></i>
                        Request Loan
                    </button>
                    <button class="w-full bg-white text-black border border-black py-2 px-4 rounded-lg flex items-center justify-center">
                        <i class="fas fa-money-bill-wave mr-2"></i>
                        Lend Money
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Home'
    }
</script>