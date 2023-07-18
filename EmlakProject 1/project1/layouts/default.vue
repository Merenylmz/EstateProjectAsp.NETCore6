<template>
  <v-app dark style="z-index: 0;height: 100%;">
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        
        
      </v-list>
    </v-navigation-drawer>
    <v-app-bar
      :clipped-left="clipped"
      fixed
      app
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title></v-toolbar-title>
      <v-spacer />
      
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    
    <v-footer
      :absolute="!fixed"
      app
      style="z-index: 1;"
    >
      <span>&copy; {{ new Date().getFullYear() }} Created by Muhammet Eren YILMAZ</span>
    </v-footer>
  </v-app>
</template>

<script>
import localStorage from "localStorage";
export default {
  name: 'DefaultLayout',
  created(){
    if (localStorage.getItem("isAuth") == 0) {
      this.items.push({
        icon: 'mdi-login',
        title: 'Giriş Yap',
        to: '/auth/login'
      },{
        icon: 'mdi-account-plus-outline',
        title: 'Kayıt Ol',
        to: '/auth/register'
      });
    }
    else if(localStorage.getItem("isAuth") == 1){
      this.items.push(
        {
          icon: 'mdi-format-list-bulleted',
          title: "Admin İlanlar",
          to: "/admin/adverts"
        },
        {
          icon: 'mdi-plus',
          title: 'İlan Ekleme Sayfası',
          to: '/admin/adverts/create',
        },
        {
          icon: 'mdi-logout',
          title: 'Çıkış Yap',
          to: '/auth/logout',
        }
      )
    }
  },
  data () {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-home-variant-outline',
          title: 'Anasayfa',
          to: '/'
        },
        {
          icon: 'mdi-information-outline',
          title: 'Hakkımızda',
          to: '/aboutus'
        },
        {
          icon: 'mdi-card-account-mail',
          title: 'İletişim',
          to: '/contact'
        }
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Vuetify.js'
    }
  }
}
</script>
