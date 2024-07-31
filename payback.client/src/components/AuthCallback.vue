<template>
    <div class="flex flex-col items-center justify-center min-h-screen">
        <h2 class="text-2xl font-bold mb-4">Processing Authentication...</h2>
        <div class="loader"></div>
    </div>
</template>


<script>
    export default {
        async created() {
            // Extract the authorization code from the URL
            const urlParams = new URLSearchParams(window.location.search);
            const code = urlParams.get('code');

            if (code) {
                try {
                    // Exchange the authorization code for tokens
                    const response = await fetch('https://oauth2.googleapis.com/token', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded',
                        },
                        body: new URLSearchParams({
                            code: code,
                            client_id: '806625840381-hor4d6n1g7uklv9sml8jfjaijud487cb.apps.googleusercontent.com',
                            client_secret: 'YOUR_GOOGLE_CLIENT_SECRET',
                            redirect_uri: 'http://localhost:8080/auth/callback',
                            grant_type: 'yahyo',
                        }),
                    });

                    const data = await response.json();

                    if (data.id_token) {
                        // Verify and process the ID token on your backend if needed
                        console.log('ID Token:', data.id_token);

                        // Simulate login by setting loggedIn to true
                        this.$emit('login-success');
                        this.$router.push('/');
                    } else {
                        console.error('Failed to obtain ID token:', data);
                    }
                } catch (error) {
                    console.error('Error during authentication:', error);
                }
            }
        },
    };
</script>
<style scoped>
    /* Loader styles */
    .loader {
        border: 16px solid #f3f3f3; /* Light grey */
        border-top: 16px solid #3498db; /* Blue */
        border-radius: 50%;
        width: 120px;
        height: 120px;
        animation: spin 2s linear infinite;
    }

    @keyframes spin {
        0% {
            transform: rotate(0deg);
        }

        100% {
            transform: rotate(360deg);
        }
    }
</style>