<template>
    <div>
        <h2>Create Contract</h2>
        <form @submit.prevent="createContract">
            <div>
                <label for="content">Content</label>
                <textarea v-model="content" id="content"></textarea>
            </div>
            <div>
                <label for="loanId">Loan ID</label>
                <input type="number" v-model="loanId" id="loanId" />
            </div>
            <button type="submit">Create Contract</button>
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
