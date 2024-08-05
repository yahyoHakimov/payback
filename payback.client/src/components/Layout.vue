<template>
    <div>
        <nav>
            <router-link to="/create-loan">Create Loan</router-link> |
            <router-link to="/create-contract">Create Contract</router-link> |
            <router-link to="/notifications">Notifications</router-link> |
            <button @click="logout">Logout</button>
        </nav>
        <router-view />
    </div>
</template>

<script>
    export default {
        methods: {
            logout() {
                localStorage.removeItem('user');
                this.$router.push('/login');
            }
        }
    }
</script>

<style scoped>
    nav {
        background-color: #f8f9fa;
        padding: 1rem;
    }

        nav a {
            margin-right: 1rem;
        }
</style>
