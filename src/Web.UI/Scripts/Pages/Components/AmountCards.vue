<script>
    import axios from 'axios'
    var interval = null

    export default {
        props: ['updateTime'],
        data() {
            return {
                loading: false,
                eventsByRegion: []
            }
        },
        mounted() {
            this.getData()

            this.startInterval()
        },
        watch: {
            updateTime() {
                this.startInterval()
            }
        },
        methods: {
            getData() {
                this.loading = true

                axios.get('/api/SensorEvent/by-region').then((result) => {
                    this.eventsByRegion = result.data
                }).finally(() => {
                    this.loading = false
                })
            },
            startInterval() {
                clearInterval(interval)
                interval = setInterval(() => {
                    this.getData()
                }, this.updateTime)
            }
        }
    }
</script>

<template>
    <div>
        <h4>Sensores por região</h4>
        <h5 v-if="loading">Carregando...</h5>
        <div class="d-flex flex-wrap">
            <div class="card text-white bg-primary" v-for="item in eventsByRegion">
                <div class="card-body">
                    <h2 class="text-uppercase font-weight-bold">{{ item.regiao }}</h2>
                    <p v-for="sensor in item.sensores">
                        {{sensor.sensor}} : {{sensor.eventos.length}} {{sensor.eventos.length == 1 ? "Evento" : "Eventos"}}
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .card {
        margin-right: 20px;
        min-width: calc(25% - 20px);
        margin-top: 20px;
        margin-bottom: 20px;
    }

    .card h2 {
        font-size: 18px;
    }
</style>