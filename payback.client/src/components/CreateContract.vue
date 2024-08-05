<template>
    <div class="max-w-md mx-auto bg-white p-8 rounded-lg shadow-md">
        <h2 class="text-2xl font-bold mb-6 text-gray-900">Create Contract</h2>
        <form @submit.prevent="createContract">
            <div class="mb-4">
                <label for="content" class="block text-gray-700">Content</label>
                <textarea v-model="content" id="content" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full"></textarea>
            </div>
            <div class="mb-4">
                <label for="loanId" class="block text-gray-700">Loan ID</label>
                <input v-model="loanId" id="loanId" type="number" class="mt-1 px-4 py-2 border border-gray-300 rounded-lg w-full" />
            </div>
            <button type="submit" class="bg-blue-600 text-white px-4 py-2 rounded-lg w-full hover:bg-blue-700">
                Create Contract
            </button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                content: '',
                loanId: 0,
            };
        },
        methods: {
            async createContract() {
                const response = await fetch('https://localhost:7160/api/contracts', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        content: this.content,
                        loanId: this.loanId,
                    }),
                });
                if (response.ok) {
                    console.log('Contract created successfully');
                }
            },
        },
    };
</script>
