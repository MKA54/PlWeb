import { createRouter, createWebHashHistory } from 'vue-router';

import SubmissionForm from '../Views/SubmissionForm.vue';
import FormsList from '../Views/FormsList.vue';

const routes = [
    {
        path: '/',
        name: 'form',
        component: SubmissionForm
    },
    {
        path: '/forms',
        name: 'forms',
        component: FormsList
    }
];

const router = createRouter({
    history: createWebHashHistory(),
    routes
});

export default router