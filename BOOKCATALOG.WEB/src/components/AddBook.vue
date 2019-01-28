<template>
    <div class="form">
        <div class="form-group">
            <label for="book.title">Tytuł książki</label>
            <input v-model="book.title" class="form-control" type="text" id="book.title" name="book.title" />
            <label for="book.releaseDate">Rok wydania</label>
            <input v-model="book.releaseDate" class="form-control" type="number" id="book.releaseDate" name="book.releaseDate" />
            <label for="book.price">Cena</label>
            <input v-model="book.price" class="form-control" type="number" id="book.price" name="book.price" />
            <label for="book.count">Ilość</label>
            <input v-model="book.count" class="form-control" type="number" id="book.count" name="book.count" />
        </div>
        <div class="form-group">
            <button @click="saveBook" class="btn btn-primary">Zapisz</button>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import Axios from 'axios';

    @Component
    export default class AddBook extends Vue {
        book = {
            title: '',
            releaseDate: (new Date).getFullYear(),
            price: Number,
            count: Number
        }
        
        saveBook() {
            Axios
                .post('https://localhost:44341/api/books', 
                this.book,
                {
                    headers: {
                        'Content-Type': 'application/json',
                    }
                    //withCredentials: false,
                })
                .then(() => { this.$router.push({ path: '/' }); });
        }
    }
</script>

<style scoped>
</style>