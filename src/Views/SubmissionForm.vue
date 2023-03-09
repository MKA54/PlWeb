<template>
    <div class="container bg-light border border-dark">
        <h1>Car order.</h1>
        <form class="needs-validation" novalidate ref="inputForm" id="form">
            <div class="form-group row">
                <label for="id_first_name" class="col-sm-2 col-form-label">First name</label>
                <div class="col-sm-10">
                    <input type="text" v-model.trim="first_name" class="form-control" id="id_first_name" placeholder="First name" required />
                    <div class="invalid-feedback">
                        Enter your name.
                    </div>
                </div>

            </div>
            <div class="form-group row">
                <label for="id_last_name" class="col-sm-2 col-form-label">Last name</label>
                <div class="col-sm-10">
                    <input type="text" v-model.trim="last_name" class="form-control" id="id_last_name" placeholder="Last name" required />
                    <div class="invalid-feedback">
                        Enter last name.
                    </div>
                </div>
            </div>
            <div class="form-group row">
                <label for="id_city" class="col-sm-2 col-form-label">City</label>
                <div class="col-sm-10">
                    <input type="text" v-model.trim="city" class="form-control" id="id_city" placeholder="City" required />
                    <div class="invalid-feedback">
                        Enter city.
                    </div>
                </div>
            </div>
            <fieldset class="form-group">
                <div class="row">
                    <label class="col-sm-2 col-form-label">Car model</label>
                    <div class="col-sm-10 text-left">
                        <div class="form-check">
                            <input v-model="car_model" class="form-check-input" type="radio" name="role" id="id_bmw" value="bmw" checked>
                            <label class="form-check-label" for="id_bmw">
                                BMW
                            </label>
                        </div>
                        <div class="form-check">
                            <input v-model="car_model" class="form-check-input" type="radio" name="role" id="id_mercedes_benz" value="mercedes_benz">
                            <label class="form-check-label" for="id_mercedes_benz">
                                Mercedes-Benz
                            </label>
                        </div>
                        <div class="form-check">
                            <input v-model="car_model" class="form-check-input" type="radio" name="role" id="id_audi" value="audi">
                            <label class="form-check-label" for="id_audi">
                                Audi
                            </label>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class="form-row">
                <label class="col-sm-2 col-form-label" for="id_engine">Engine's type</label>
                <div class="col-sm-10 text-left">
                    <select v-model="engine_type" class="custom-select " id="id_engine" required>
                        <option value="">
                            Select engine
                        </option>
                        <option value="Petrol">
                            Petrol
                        </option>
                        <option value="Diesel">
                            Diesel
                        </option>
                        <option value="Hybrid">
                            Hybrid
                        </option>
                    </select>
                    <div class="invalid-feedback">
                        Please select a valid state.
                    </div>
                </div>
            </div>
            <fieldset class="form-group">
                <div class="form-row mt-2">
                    <label class="col-sm-2 col-form-label">Additional options</label>
                    <div class="col-sm-10 text-left align-self-center">
                        <div class="form-check form-check-inline">
                            <input v-model="checked_options" class="form-check-input" type="checkbox" id="id_full_size_spare_tire" value="Full size spare tire">
                            <label class="form-check-label" for="id_full_size_spare_tire">Full size spare tire</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input v-model="checked_options" class="form-check-input" type="checkbox" id="id_toning" value="Toning">
                            <label class="form-check-label" for="id_toning">Toning</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input v-model="checked_options" class="form-check-input" type="checkbox" id="id_heated_all_seats" value="Heated all seats">
                            <label class="form-check-label" for="id_heated_all_seats">Heated all seats</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input v-model="checked_options" class="form-check-input" type="checkbox" id="id_improved_light" value="Improved light">
                            <label class="form-check-label" for="id_improved_light">Improved light</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input v-model="checked_options" class="form-check-input" type="checkbox" id="id_cruise_control" value="Cruise-control">
                            <label class="form-check-label" for="id_cruise_control">Cruise-control</label>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class="form-group row mt-3">
                <div class="col-sm-12 text-right">
                    <button type="button" @click="register_application" class="btn btn-primary">Submit</button>
                </div>
            </div>
        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                first_name: "",
                last_name: "",
                city: "",
                car_model: "bmw",
                engine_type: "",
                checked_options: []
            };
        },
        methods: {
            register_application() {
                // eslint-disable-next-line
                let inputForm = $(this.$refs.inputForm);

                inputForm.removeClass("was-validated");

                if (   inputForm[0][0].checkValidity() === false || this.first_name.length === 0
                    || inputForm[0][1].checkValidity() === false || this.last_name.length === 0
                    || inputForm[0][2].checkValidity() === false || this.engine_type.length === 0
                    || inputForm[0][4].checkValidity() === false || this.engine_type.length === 0)
                {
                    inputForm.addClass("was-validated");

                    return;
                }

                let form =
                {
                    first_name : this.first_name,
                    last_name: this.last_name,
                    city: this.city,
                    car_model : this.car_model,
                    engine_type: this.engine_type,
                    checked_options_count: this.checked_options.length,
                    checked_options: this.checked_options
                }
           
                fetch('form', {
                    method: 'POST',                 
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },                  
                    body: JSON.stringify(form)
                });

                this.first_name = "";
                this.last_name = "";
                this.city = "";
                this.car_model = "bmw";
                this.engine_type = "";
                this.checked_options = [];
            }
        },
    });
</script>