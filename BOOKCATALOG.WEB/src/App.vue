<template>
    <div id="app" class="container">
        <!--<DataTable />-->
        <nav>
            <router-link to='/' class="btn btn-success">Ksi¹¿ki</router-link>
            <router-link to='/addbook' class="btn btn-success">Dodaj ksi¹¿kê</router-link>
            <router-link to='/chat' class="btn btn-success">Komunikator</router-link>
        </nav>
        <router-view />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    //import Home from './components/Home.vue';
    import DataTable from './components/DataTable.vue';


    @Component({
        components: {
            //Home,
            DataTable
        }
    })
    export default class App extends Vue { }
</script>

<style>
</style>
