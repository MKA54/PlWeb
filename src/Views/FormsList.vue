<template>
    <div class="container bg-light border border-dark">
        <div class="mb-4 mt-4 form-inline">
            <div class="row no-gutters">
                <div class="col-12 col-lg-auto mb-2 mr-2">
                    <input class="form-control" placeholder="Поиск" v-model.trim="term" type="text" />
                </div>
                <div class="col mb-2">
                    <button @click="loadContacts" class="btn btn-primary mr-2" type="button">Поиск</button>
                    <button @click="clearSearch" class="btn btn-secondary" type="button">Очистить</button>
                </div>
            </div>
        </div>

        <table class="table table-striped">
            <thead>
                <tr>
                    <th>N</th>
                    <th>Name</th>
                    <th>Last name</th>
                    <th>Car model</th>
                    <th>Engine type</th>
                    <th>Checked options</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(form, index) in forms" :key="form.id">
                    <td>{{ index + 1 }}.</td>
                    <td>{{ form.firstName }}</td>
                    <td>{{ form.lastName }}</td>
                    <td>{{ form.carModel }}</td>
                    <td>{{ form.engineType }}</td>
                    <td>{{ form.checkedOptionsString }}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                term: "",
                forms: []
            };
        },
        created: function () {
            this.loadForms();
        },
        methods: {
            loadForms() {
                fetch('forms')
                    .then((response) => response.json())
                    .then((data) => this.forms = data); 
            },
            
            loadContacts() {
                    fetch('forms/term=' + this.term)
                        .then((response) => response.json())
                    .then((data) => this.forms = data);
            },

            clearSearch() {
                this.term = "",
                this.loadForms();
            }
        },
    });
</script>