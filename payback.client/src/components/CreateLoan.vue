<template>
    <div class="max-w-md mx-auto bg-white p-8 rounded-lg shadow-md">
        <h2 class="text-2xl font-bold mb-6 text-gray-900">Create Loan</h2>
        <form @submit.prevent="createLoan">
            <div class="mb-4">
                <label for="borrower" class="block text-gray-700">Borrower</label>
                <input v-model="borrower" id="borrower" type="text" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <div class="mb-4">
                <label for="amount" class="block text-gray-700">Amount</label>
                <input v-model="amount" id="amount" type="number" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <div class="mb-4">
                <label for="dueDate" class="block text-gray-700">Due Date</label>
                <input v-model="dueDate" id="dueDate" type="date" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <button type="submit" class="bg-blue-600 text-white px-4 py-2 rounded-lg w-full hover:bg-blue-700">
                Create Loan
            </button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                borrower: '',
                amount: 0,
                dueDate: '',
            };
        },
        methods: {
            async createLoan() {
                const response = await fetch('https://localhost:7160/api/loans', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        borrower: this.borrower,
                        amount: this.amount,
                        dueDate: this.dueDate,
                    }),
                });
                if (response.ok) {
                    console.log('Loan created successfully');
                }
            },
        },
    };
</script>
