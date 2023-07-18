<template lang="">
    <div>
        <v-form @submit="handleSubmit">
            <v-container>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="name"
                    label="Adınız"
                    required
                ></v-text-field>
                </v-col>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="email"
                    label="Email Adresiniz"
                    required
                ></v-text-field>
                </v-col>

                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="password"
                    label="Şifreniz"
                    required
                ></v-text-field>
                </v-col>
            </v-row>
        </v-container>
        <v-btn type="submit" color="primary">Kayıt Ol</v-btn>
    </v-form>
    </div>
</template>
<script>
import localStorage from "localStorage";
export default {
    data: () => ({
        name: '',
        email: '',
        password: '',
    }),
    methods: {
        handleSubmit(e){
            e.preventDefault();
            fetch("https://localhost:7230/api/Users/register", {
                method: "POST",
                headers: {
                    "Content-type": "application/json"
                },
                body: JSON.stringify({
                    username: this.name,
                    email: this.email,
                    password: this.password
                })
            }).then((res)=>res.json()).then((data)=>{
                localStorage.setItem("isAuth", 0);
                window.location.href="/auth/login";
            });
        }
    },
}
</script>
<style lang="">
    
</style>