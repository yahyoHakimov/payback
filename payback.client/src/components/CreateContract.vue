<template>
    <div class="p-6">
        <h1 class="text-2xl font-semibold mb-6">Create Loan Contract</h1>
        <form @submit.prevent="submitLoanContract" class="bg-white shadow rounded-lg p-6">
            <div class="mb-4">
                <label for="amount" class="block text-sm font-medium text-gray-700">Amount</label>
                <input type="number" id="amount" v-model="amount" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
            </div>
            <div class="mb-4">
                <label for="repaymentDate" class="block text-sm font-medium text-gray-700">Repayment Date</label>
                <input type="date" id="repaymentDate" v-model="repaymentDate" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
            </div>
            <div class="mb-4">
                <label for="user" class="block text-sm font-medium text-gray-700">User</label>
                <select id="user" v-model="selectedUser" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
                    <option v-for="user in users" :key="user.id" :value="user.id">{{ user.name }}</option>
                </select>
            </div>
            <div class="mb-4">
                <label for="purpose" class="block text-sm font-medium text-gray-700">Purpose (Optional)</label>
                <textarea id="purpose" v-model="purpose" rows="3" class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></textarea>
            </div>
            <div class="mb-4">
                <label for="content" class="block text-sm font-medium text-gray-700">Contract Content</label>
                <textarea id="content" v-model="content" rows="5" required class="mt-1 block w-full border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"></textarea>
            </div>
            <button type="submit" class="w-full bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded">
                Create Loan Contract
            </button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                amount: null,
                repaymentDate: '',
                selectedUser: null,
                purpose: '',
                content: '',
                users: [
                    { id: 1, name: 'John Doe' },
                    { id: 2, name: 'Jane Smith' },
                    // Add more users as needed
                ]
            };
        },
        methods: {
            async submitLoanContract() {
                try {
                    // First, create the loan
                    const loanResponse = await fetch('https://localhost:7160/api/loans', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            amount: this.amount,
                            repaymentDate: this.repaymentDate,
                            userId: this.selectedUser,
                            purpose: this.purpose,
                        }),
                    });

                    if (!loanResponse.ok) {
                        throw new Error('Failed to create loan');
                    }

                    const loanData = await loanResponse.json();
                    const loanId = loanData.id; // Assuming the API returns the created loan's ID

                    // Then, create the contract associated with the loan
                    const contractResponse = await fetch('https://localhost:7160/api/contracts', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            content: this.content,
                            loanId: loanId,
                        }),
                    });

                    if (!contractResponse.ok) {
                        throw new Error('Failed to create contract');
                    }

                    console.log('Loan and contract created successfully');
                    // Reset form or navigate to another page
                    this.resetForm();
                } catch (error) {
                    console.error('Error creating loan contract:', error);
                    // Handle error (e.g., show error message to user)
                }
            },
            resetForm() {
                this.amount = null;
                this.repaymentDate = '';
                this.selectedUser = null;
                this.purpose = '';
                this.content = '';
            }
        },
    };
</script>