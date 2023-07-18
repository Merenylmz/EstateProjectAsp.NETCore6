<template lang="">
    <div>
        <h1>İletişim</h1>
        <div v-if="inf!=null">
            Gönderildi
        </div>
        <v-form @submit="handleSubmit">
            <v-container>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="name"
                    label="Adınız:"
                    required
                    clearable
                ></v-text-field>
                </v-col>

                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="email"
                    label="Emailiniz"
                    required
                    clearable
                ></v-text-field>
                </v-col>

                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="subject"
                    label="Konu"
                    required
                    clearable
                ></v-text-field>
                </v-col>
                <v-col
                cols="12"
                md="4"
                >
                
                </v-col>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="message"
                    label="Mesajınız"
                    required
                    clearable
                ></v-text-field>
                </v-col>
            </v-row>
            </v-container>
            <v-btn prepend-icon="$vuetify" type="submit">
              Gönder
            </v-btn>
        </v-form>
    </div>
</template>
<script>
import axios from 'axios';

export default {
    data:()=>{
        return{
            email: '',
            subject: '',
            message: '',
            inf: null
        }
    },
    methods: {
        async handleSubmit() {
            await axios.post("https://localhost:7230/api/Message", {
                email: this.email,
                messageTitle: this.subject,
                messageDescription: this.message
            });
            this.inf = "sended";
            window.location.href="/contact";
        }
    },
}
</script>
<style lang="">
    
</style>