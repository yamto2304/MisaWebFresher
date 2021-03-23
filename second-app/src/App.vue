<template>
  <div id="app">
    <!-- <v-main> -->
      <Navbar/> 
      <Header/>
    <!-- </v-main> -->
    <!-- <Content/>  -->
  </div>
</template>

<script>
// import Content from './components/layout/Content.vue'
import Header from './components/layout/Header.vue'
import Navbar from './components/layout/Navbar.vue'


export default {
  name: 'App',
  components: {
    Navbar,
    // Content,
    Header
  }
}
</script>

<style lang='css'>
  @import url('../style/general.css');
</style>
