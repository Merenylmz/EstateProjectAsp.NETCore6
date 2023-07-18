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
                    clearable
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
                    clearable
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
                    clearable
                    suffix="TL"
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
                    label="Resim Adresi"
                    required
                    clearable
                ></v-text-field>
                </v-col>
            </v-row>
            </v-container>
            <v-btn prepend-icon="$vuetify" type="submit">
              Ekle
            </v-btn>
        </v-form>
    </div>
</template>
<script>
import localStorage from 'localStorage';
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
    methods: {

        async handleSubmit(e){
            e.preventDefault();
            try {
                const response = await fetch("https://localhost:7230/api/Advert", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify({
                        name: this.name,
                        description: this.description,
                        price: this.price,
                        imageUrl: this.imageUrl,
                        userId: localStorage.getItem("userId")
                    })
                });
                this.$router.push("/admin/adverts");
            } catch (error) {
                console.log(error);
            }
        }
    }
}
</script>
