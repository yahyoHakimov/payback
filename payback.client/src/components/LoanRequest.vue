<template>
    <div class="bg-white p-6 rounded-lg shadow">
        <h2 class="text-2xl font-bold mb-4">Loan Request</h2>
        <p class="text-gray-600 mb-6">Fill out the form to request a loan.</p>
        <form @submit.prevent="submitLoanRequest" class="space-y-6">
            <div>
                <label for="amount" class="block text-sm font-medium text-gray-700 mb-1">Amount</label>
                <input type="number"
                       id="amount"
                       v-model="loanRequest.amount"
                       placeholder="Enter loan amount"
                       class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                       required />
            </div>
            <div>
                <label for="repaymentDate" class="block text-sm font-medium text-gray-700 mb-1">Repayment Date</label>
                <input type="date"
                       id="repaymentDate"
                       v-model="loanRequest.repaymentDate"
                       class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                       required />
            </div>
            <div>
                <label for="borrowerLender" class="block text-sm font-medium text-gray-700 mb-1">Borrower/Lender</label>
                <select id="borrowerLender"
                        v-model="loanRequest.borrowerLender"
                        class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        required>
                    <option value="" disabled>Select user</option>
                    <option v-for="user in users" :key="user.id" :value="user.id">{{ user.name }}</option>
                </select>
            </div>
            <div>
                <label for="purpose" class="block text-sm font-medium text-gray-700 mb-1">Purpose</label>
                <textarea id="purpose"
                          v-model="loanRequest.purpose"
                          placeholder="Describe the purpose of the loan"
                          rows="4"
                          class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></textarea>
            </div>
            <button type="submit"
                    class="w-full bg-black text-white py-2 px-4 rounded-md hover:bg-gray-800 focus:outline-none focus:ring-2 focus:ring-gray-600 focus:ring-opacity-50">
                Submit Loan Request
            </button>
        </form>
    </div>
</template>

<script>
export default {
  name: 'LoanRequest',
  data() {
    return {
      loanRequest: {
        amount: '',
        repaymentDate: '',
        borrowerLender: '',
        purpose: ''
      },
      users: [
        { id: 1, name: 'John Doe' },
        { id: 2, name: 'Jane Smith' },
        { id: 3, name: 'Bob Johnson' }
      ]
    }
  },
  methods: {
    submitLoanRequest() {
      // Here you would typically send the loan request to your backend
      console.log('Loan Request Submitted:', this.loanRequest)
      // After submission, you might want to navigate to a confirmation page or back to the overview
      this.$router.push('/')
    }
  }
}
</script>