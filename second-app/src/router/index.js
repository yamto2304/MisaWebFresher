import VueRouter from 'vue-router'
import Vue from 'vue'
import Employee from '../components/view/EmployeeList.vue'

Vue.use(VueRouter)

const routes = [
    {
        path: '/employee',
        name: 'Employee',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: Employee
      }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
  })
  
  export default router