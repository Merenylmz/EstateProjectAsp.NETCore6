<template>
  <div>
    <h1>Admin İlanlar Listesi</h1>
      
    <v-data-table
      :headers="headers"
      :items="data"
    >

    <template v-slot:item="{ item }">
      <tr>
        <td>{{ item.name }}</td>
        <td>{{ item.description }}</td>
        <td>{{ item.price }}</td>
        <td>
          <v-btn prepend-icon="$vuetify" @click="editItem(item.id)" variant="outlined">
            Düzenle
          </v-btn>
          <v-btn prepend-icon="$vuetify" @click="deleteItem(item.id)" variant="outlined">
            Sil
          </v-btn>
        </td> <!-- Boş işlemler sütunu -->
      </tr>
    </template>
    </v-data-table>
  </div>
</template>
  
<script>
import localStorage from "localStorage";
import axios from "axios";
export default {
  name: 'AdvertsPage',
  data() {
    return {
      data: [],
      headers: [
        { text: 'Ad', value: 'name' , },
        { text: 'Açıklama', value: 'description' , },
        { text: 'Fiyat', value: 'price' },
        { text: 'İşlemler' },
      ]
    }
  },
  beforeCreate() {
    localStorage.getItem("isAuth") == 0 ? window.location.href="/auth/login":"";
  },
  created () {
    this.getData();
  },
  methods: {
    getData() {
      axios.get("https://localhost:7230/api/advert/")
        .then((res)=>{this.data = res.data; });
    },
    editItem(id){
      this.$router.push("/admin/adverts/edit/"+id);
    },
    deleteItem(id){
      if (confirm("Silmek İstediğinizden emin misiniz?")) {
        axios.delete(`https://localhost:7230/api/Advert/${id}`)
        window.location.reload();
      } 
      else{}
    }
  },
}
</script>

