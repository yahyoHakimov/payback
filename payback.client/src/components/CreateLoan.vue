<template>
    <div>
        <h2>Create Loan</h2>
        <form @submit.prevent="createLoan">
            <div>
                <label for="borrower">Borrower</label>
                <input v-model="borrower" id="borrower" />
            </div>
            <div>
                <label for="amount">Amount</label>
                <input type="number" v-model="amount" id="amount" />
            </div>
            <div>
                <label for="dueDate">Due Date</label>
                <input type="date" v-model="dueDate" id="dueDate" />
            </div>
            <button type="submit">Create Loan</button>
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
