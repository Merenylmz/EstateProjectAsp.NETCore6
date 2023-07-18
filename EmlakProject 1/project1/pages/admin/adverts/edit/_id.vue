<template lang="">
    <div>
        <v-form v-model="valid" @submit="handleSubmit">
            <v-container>
            <v-row>
                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="name"
                    label="İlan Adı"
                    required
                ></v-text-field>
                </v-col>

                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="description"
                    label="Açıklama"
                    required
                ></v-text-field>
                </v-col>

                <v-col
                cols="12"
                md="4"
                >
                <v-text-field
                    v-model="price"
                    type = "number"
                    label="Fiyat"
                    required
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
                    v-model="imageUrl"
                    label="Resim Yolu"
                    required
                ></v-text-field>
                </v-col>
            </v-row>
            </v-container>
            <br>
            <v-btn type="submit" color="primary">Değişiklikleri Kaydet</v-btn>
        </v-form>
    </div>
</template>
<script>
import localStorage from 'localStorage';
import axios from 'axios';
export default {
    data: () => ({
      valid: false,
      name: '',
      description: '',
      price: 0,
      imageUrl: ''
    }),
    beforeCreate() {
      localStorage.getItem("isAuth") == 0 ? window.location.href="/auth/login":"";
    },
    created() {
        axios.get(`https://localhost:7230/api/Advert/${this.$route.params.id}`)
            .then((res)=>res.data)
            .then((datas)=>{
                this.name = datas.name;
                this.description = datas.description;
                this.price = datas.price;
                this.imageUrl = datas.imageUrl; 
            });
    },
    methods: {
        handleSubmit(e){
            e.preventDefault();
            axios.put(`https://localhost:7230/api/Advert/`, {
                Id: this.$route.params.id, 
                name: this.name,
                description: this.description,
                price: this.price,
                imageUrl: this.imageUrl,
                userId: localStorage.getItem("userId")
            });
            /* fetch(`https://localhost:7230/api/Advert/`, {
            //     method: "PUT",
            //     headers: {
            //         "Content-type" : "application/json"
            //     },
            //     body: JSON.stringify({
            //         Id: this.$route.params.id, 
            //         name: this.name,
            //         description: this.description,
            //         price: this.price,
            //         imageUrl: this.imageUrl,
            //         userId: localStorage.getItem("userId")
            //     })
            // });
            */
            // this.$router.push("/admin/adverts"); Böyle Yapınca admin listesini yenilemiyo

            window.location.href = "/admin/adverts";
        }
    },
    // {{this.$route.params.id}} id bilgisi
}
</script>
<style lang="">
    
</style>