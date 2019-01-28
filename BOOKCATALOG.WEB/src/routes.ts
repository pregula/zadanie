import Chat from './components/Chat.vue';
import DataTable from './components/DataTable.vue';
import AddBook from './components/AddBook.vue';

const routes = [
    { path: '/', component: DataTable },
    { path: '/addbook', component: AddBook },
    { path: '/chat', component: Chat }
];

export default routes;