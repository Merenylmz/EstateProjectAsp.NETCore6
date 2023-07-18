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
        <v-btn type="submit" color="primary">Giriş</v-btn>
    </v-form>
    </div>
</template>
<script>
import localStorage from "localStorage";
export default {
    data: () => ({
      email: '',
      password: '',
    }),
    methods: {
        handleSubmit(e){
            e.preventDefault();
            fetch("https://localhost:7230/api/Users/login", {
                method: "POST",
                headers: {
                    "Content-type": "application/json"
                },
                body: JSON.stringify({
                    email: this.email,
                    password: this.password
                })
            }).then((res)=>res.json()).then((data)=>{
                if (data.state) {
                    localStorage.setItem("isAuth", 1);
                    localStorage.setItem("userId", data.userId);
                    return window.location.href="/admin/adverts";
                }
                window.location.reload();
            }).catch(()=>alert("Hatalı Giriş"));
        }
    },
}
</script>
<style lang="">
    
</style>