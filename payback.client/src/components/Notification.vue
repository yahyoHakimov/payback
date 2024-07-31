<template>
    <div>
        <h2>Notifications</h2>
        <ul>
            <li v-for="message in messages" :key="message">{{ message }}</li>
        </ul>
    </div>
</template>

<script>
    import { HubConnectionBuilder } from '@microsoft/signalr';

    export default {
        data() {
            return {
                connection: null,
                messages: [],
            };
        },
        mounted() {
            this.connection = new HubConnectionBuilder()
                .withUrl('https://localhost:5001/hub')
                .build();

            this.connection.on('ReceiveMessage', (message) => {
                this.messages.push(message);
            });

            this.connection.start()
                .then(() => console.log('Connection started'))
                .catch(err => console.error('Error while starting connection: ' + err));
        },
        beforeUnmount() {
            if (this.connection) {
                this.connection.stop();
            }
        },
    };
</script>
