<template>
    <div class="chat">
        <div class="form-group">
            <form>
                <div>
                    <label for="msg.userName">Your Name</label>
                    <input type="text" name="Name" id="msg.userName" v-model="msg.userName">
                </div>
                <div>
                    <label for="msg.userMessage">Message</label>
                    <input type="text" name="Message" id="msg.userMessage" v-model="msg.userMessage">
                </div>
                <button v-on:click="submitCard" type="button">Submit</button>
            </form>
            <ul v-for="(item, index) in msg.messages" v-bind:key="index + 'itemMessage'">
                <li><b>Name: </b></li>
                <li><b>Message: </b></li>
            </ul>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import * as signalR from '@aspnet/signalr';
    
    const chatApp = Vue.extend({
        data: function () {
            return {
                msg: {

            userName: '',
            userMessage: '',
            connection: new signalR.HubConnectionBuilder().withUrl("https://localhost:44341/chatHub").build(),
            messages: []
                }
            }
        },
        methods: {
            submitCard: function () {
                if (this.msg.userName && this.msg.userMessage) {
                    
                    this.msg.connection.start().then(() => {
                        this.msg.connection
                        .invoke("SendMessage", this.msg.userName, this.msg.userMessage)
                        .catch(function (err) {
                            return console.error(err.toString());
                            }
                            );
                    });
                    this.msg.userName = "";
                    this.msg.userMessage = "";
                }
            }
        },
        created: function () {
            this.msg.connection = new signalR.HubConnectionBuilder()
                .withUrl("https://localhost:44341/chatHub")
                .configureLogging(signalR.LogLevel.Information)
                .build();
            this.msg.connection.start().catch(function (err) {
                return console.error(err.toString());
            });
        },
        mounted: function () {
            var thisVue = this;
            thisVue.msg.connection.start();
            thisVue.msg.connection.on("ReceiveMessage", function (user, message) {
                thisVue.msg.messages.push({ user, message });
            });
        }
    });
    @Component
    export default class Chat extends chatApp {
        }
</script>

 Add "scoped" attribute to limit CSS to this component only 
<style scoped>
</style>
