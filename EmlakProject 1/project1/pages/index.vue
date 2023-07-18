<template>
  <div>
    <v-card v-for="item in data"
    class="me-3"
    max-width="344"
    style="display: inline-block; margin-bottom: 12px;"
  >
    <v-img
      :src="item.imageUrl"
      height="200px"
      cover
      
    ></v-img>

    <v-card-title>
      {{ item.name }}
    </v-card-title>

    <v-card-subtitle>
      {{item.description}}
      <br>
      <h3 style="color: white;">{{item.price}} TL</h3>
    </v-card-subtitle>

    <v-card-actions>
      <v-btn
        color="orange-lighten-2"
        variant="text"
        router
        exact
        @click="detailsPage(item.id)"
      >İncele</v-btn>

      <v-spacer></v-spacer>

    </v-card-actions>
    </v-card>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: 'IndexPage',
  data() {
    return {
      data: [],
    }
  },
  mounted () {
      this.getData();
  },
  methods: {
      getData() {
          // fetch("https://localhost:7230/api/Advert").then((res)=>res.json()).then((data)=>{this.data=data;})
          axios.get("https://localhost:7230/api/advert/")
              .then((res)=>{this.data = res.data;});
      },
      detailsPage(id){
        this.$router.push("/"+id);
      }
    }
  
}
</script>
