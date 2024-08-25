<template>
    <div class="max-w-4xl mx-auto p-6 bg-white shadow-md rounded-lg">
        <div class="flex items-center justify-between mb-6">
            <div class="flex items-center">
                <div class="w-16 h-16 bg-gray-300 rounded-full mr-4 flex items-center justify-center text-2xl text-gray-600">
                    {{ initials }}
                </div>
                <div>
                    <h1 class="text-2xl font-bold">{{ name }}</h1>
                    <p class="text-gray-600">{{ jobTitle }}</p>
                </div>
            </div>
            <div>
                <button @click="toggleEdit" class="px-4 py-2 bg-white text-gray-700 border border-gray-300 rounded-md mr-2 hover:bg-gray-100">
                    {{ isEditing ? 'Cancel' : 'Edit' }}
                </button>
                <button @click="saveChanges" class="px-4 py-2 bg-black text-white rounded-md hover:bg-gray-800">
                    Save
                </button>
            </div>
        </div>


        <div v-if="activeTab === 'Personal Info'" class="space-y-4">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                    <label for="name" class="block text-sm font-medium text-gray-700 mb-1">Name</label>
                    <input id="name"
                           v-model="name"
                           :disabled="!isEditing"
                           class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
                <div>
                    <label for="phone" class="block text-sm font-medium text-gray-700 mb-1">Phone</label>
                    <input id="phone"
                           v-model="phone"
                           :disabled="!isEditing"
                           class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>
            </div>
            <div>
                <label for="address" class="block text-sm font-medium text-gray-700 mb-1">Address</label>
                <textarea id="address"
                          v-model="address"
                          :disabled="!isEditing"
                          rows="3"
                          class="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"></textarea>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: 'UserProfile',
  data() {
    return {
      name: 'John Doe',
      jobTitle: 'Software Engineer',
      phone: '+1 (555) 555-5555',
      address: '123 Main St, Anytown USA',
      isEditing: false,
      activeTab: 'Personal Info',
    }
  },
  computed: {
    initials() {
      return this.name
        .split(' ')
        .map(n => n[0])
        .join('')
        .toUpperCase()
    }
  },
  methods: {
    toggleEdit() {
      this.isEditing = !this.isEditing
    },
    saveChanges() {
      // Here you would typically send the updated data to a server
      console.log('Saving changes:', {
        name: this.name,
        phone: this.phone,
        address: this.address
      })
      this.isEditing = false
    }
  }
}
</script>