<template lang="">
    <div>
            <v-card
                :loading="loading"
                class="my-12"
                max-width="400"
            >
                <template v-slot:loader="{ isActive }">
                <v-progress-linear
                    :active="isActive"
                    color="deep-purple"
                    height="4"
                    indeterminate
                ></v-progress-linear>
                </template>

                <v-img
                cover
                height="250"
                :src="data.imageUrl"
                ></v-img>

                <v-card-item>
                <v-card-title>{{data.name}}</v-card-title>

                <v-card-subtitle>
                    <span class="me-1">Fiyat: {{data.price}} TL</span>

                    <v-icon
                    color="error"
                    icon="mdi-fire-circle"
                    size="small"
                    ></v-icon>
                </v-card-subtitle>
                </v-card-item>

                <v-card-text>
                    <div>{{data.description}}</div>
                </v-card-text>
                <v-card-actions>
                
                </v-card-actions>
            </v-card>
    </div>
</template>
<script>
import axios from 'axios';

export default {
    data:()=>{
        return{
            data:[]
        }
    },
    created(){
        axios.get("https://localhost:7230/api/Advert/"+this.$route.params.id)
            .then((res)=>res.data)
            .then((data)=>{this.data=data;})
            .catch((err)=>console.log(err));
    }

}
</script>
<style lang="">
    
</style>