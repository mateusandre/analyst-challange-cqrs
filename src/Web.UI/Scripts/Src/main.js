import Vue from 'vue'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.min.js'
import $ from 'jquery'
import VueGoodTablePlugin from 'vue-good-table'
import 'vue-good-table/dist/vue-good-table.css'

window.$ = $
window.JQuery = $


Vue.use(VueGoodTablePlugin)

import Dashboard from './../Pages/Dashboard.vue'

new Vue({
    el: '#app',
    components: {
        Dashboard
    }
})