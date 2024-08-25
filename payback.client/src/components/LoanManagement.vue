<template>
    <div class="p-6">
        <h1 class="text-2xl font-semibold mb-6">Loan Management</h1>

        <!-- Filter Options -->
        <div class="mb-4 flex space-x-4">
            <input type="date" v-model="dateFilter" class="border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
            <input type="number" v-model="amountFilter" placeholder="Amount" class="border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
            <input type="text" v-model="personFilter" placeholder="Person" class="border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500">
        </div>

        <!-- Active Loans List -->
        <div class="bg-white shadow rounded-lg overflow-hidden">
            <table class="min-w-full divide-y divide-gray-200">
                <thead class="bg-gray-50">
                    <tr>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Amount</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Counterpart</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Due Date</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
                    </tr>
                </thead>
                <tbody class="bg-white divide-y divide-gray-200">
                    <tr v-for="loan in filteredLoans" :key="loan.id">
                        <td class="px-6 py-4 whitespace-nowrap">${{ loan.amount }}</td>
                        <td class="px-6 py-4 whitespace-nowrap">{{ loan.counterpart }}</td>
                        <td class="px-6 py-4 whitespace-nowrap">{{ loan.dueDate }}</td>
                        <td class="px-6 py-4 whitespace-nowrap">{{ loan.status }}</td>
                        <td class="px-6 py-4 whitespace-nowrap">
                            <button @click="sendReminder(loan.id)" class="text-blue-600 hover:text-blue-900 mr-2">Send Reminder</button>
                            <button @click="markAsPaid(loan.id)" class="text-green-600 hover:text-green-900">Mark as Paid</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      dateFilter: '',
      amountFilter: '',
      personFilter: '',
      loans: [
        { id: 1, amount: 1000, counterpart: 'John Doe', dueDate: '2023-06-30', status: 'Active' },
        { id: 2, amount: 500, counterpart: 'Jane Smith', dueDate: '2023-07-15', status: 'Active' },
        // Add more loan data as needed
      ]
    }
  },
  computed: {
    filteredLoans() {
      return this.loans.filter(loan => {
        return (!this.dateFilter || loan.dueDate === this.dateFilter) &&
               (!this.amountFilter || loan.amount === parseFloat(this.amountFilter)) &&
               (!this.personFilter || loan.counterpart.toLowerCase().includes(this.personFilter.toLowerCase()))
      })
    }
  },
  methods: {
    sendReminder(loanId) {
      // Implement send reminder logic
      console.log('Sending reminder for loan:', loanId)
    },
    markAsPaid(loanId) {
      // Implement mark as paid logic
      console.log('Marking loan as paid:', loanId)
    }
  }
}
</script>