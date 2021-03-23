<template>
    <div class="navbar">
        <div class="logo-site">
            <div class="logo-box">
                <div class="toggle-icon"></div>
                <div class="amis-logo"></div>
            </div>
        </div>
        <div class="navbar-content">
            <a class="nav-item">
                <div class="nav-item-icon icon-dashboard"></div>
                <div class="nav-item-text">Tổng quan</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon icon-report"></div>
                <div class="nav-item-text">Báo cáo</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon icon-personnel"></div>
                <div class="nav-item-text">Danh mục khách hàng</div>
            </a>
            <router-link class="nav-item" to="/employee">
                <div class="nav-item-icon icon-personnel"></div>
                <div class="nav-item-text">Danh mục nhân viên</div>
            </router-link>
            <a class="nav-item">
                <div class="nav-item-icon icon-setting"></div>
                <div class="nav-item-text">Thiết lập hệ thống</div>
            </a>
            <div class="nav-item show-option"
                    v-on:click="showOption"
             >Where am I ?!</div>
        </div>  
    </div>
</template>

<script>
export default {
    name: 'Navbar',
    data () {
        return {
            name : "my Navbar"
        }
    },
    methods: {
        showOption(){
            alert("This is " + this.name);
        }
    }
}
</script>

<style scoped>
</style>