<template>
    <div class="datatable">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Lp.</th>
                    <th>Id</th>
                    <th>Tytuł</th>
                    <th>Rok wydania</th>
                    <th>Cena</th>
                    <th>Ilość</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(book, index) in books">
                    <td>{{ index }}</td>
                    <td>{{ book.id }}</td>
                    <td>{{ book.title }}</td>
                    <td>{{ book.releaseDate }}</td>
                    <td>{{ book.price }}</td>
                    <td>{{ book.count }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Axios from 'axios';

    @Component
    export default class DataTable extends Vue {
        books = []

        mounted() {
            this.fetchBooks()
        }

        fetchBooks() {
            Axios
                    .get('https://localhost:44341/api/books', {
                        headers: {
                            'Access-Control-Allow-Origin': '*',
                            'Access-Control-Allow-Credentials': true,
                            'Access-Control-Allow-Methods': 'GET, PUT, POST, DELETE, OPTIONS',
                            'Access-Control-Allow-Headers': 'Origin, Content-Type, Accept',
                            'Content-Type': 'application/json',
                        },
                        withCredentials: false,
                    })
                    .then(response => (this.books = response.data))
        }
    }
</script>

<style scoped>
</style>