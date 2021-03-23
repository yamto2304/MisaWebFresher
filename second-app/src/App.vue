<template>
  <div id="app">
    <!-- <v-main> -->
      <Navbar/> 
      <Header/>
      <Content/> 
    <!-- </v-main> -->
  </div>
</template>

<script>
import Content from './components/layout/Content.vue'
import Navbar from './components/layout/Navbar.vue'
import Header from './components/layout/Header.vue'
// import Content from './components/view/EmployeeList.vue'
export default {
  name: 'App',
  components: {
    Navbar,
    Header,
    Content,
  }
}
</script>

<style lang='css'>
  @import url('../style/general.css');
</style>