<template>
  <div id="app">
    <Navbar/>
    <Header/>
    <Content/>
    <!-- <img alt="Vue logo" src="./assets/logo.png"> -->
    <!-- <HelloWorld msg="Welcome to Your Vue.js App"/> -->
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import Navbar from "./components/layout/Navbar.vue"
import Header from "./components/layout/Header.vue"
import Content from "./components/layout/Content.vue"

export default {
  name: 'App',
  components: {
    // HelloWorld,
    Navbar,
    Header,
    Content,
  }
}
</script>

<style lang='css'>
@import url("./style/general.css");
/* .html{
  overflow: hidden;
} */
</style>
