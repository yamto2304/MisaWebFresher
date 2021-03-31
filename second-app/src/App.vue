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
</style>