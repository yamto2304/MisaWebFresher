<template>
  <div id="app">
    <Navbar />
    <Header />
    <Content />
  </div>
</template>
<script>
import Content from "./components/layout/Content.vue";
import Navbar from "./components/layout/Navbar.vue";
import Header from "./components/layout/Header.vue";
export default {
  name: "App",
  components: {
    Navbar,
    Header,
    Content
  }
};
</script>

<style lang='css'>
@import url("../style/general.css");
#nav a.router-link-exact-active {
  color: #019160;
}
.navbar .navbar-content .nav-item.router-link-exact-active {
  background-color: #019160;
}
</style>