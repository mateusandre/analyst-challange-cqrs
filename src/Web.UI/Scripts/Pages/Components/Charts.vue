<script>
    import axios from 'axios'
    import PieChart from "./PieChart.js"

    var interval = null

    export default {        
        props: ['updateTime'],
        data() {
            return {
                loading: false,
                rows: [],
                chartOptions: {
                    hoverBorderWidth: 20
                },                
            };
        },
        computed: {
            chartData() {
                return {
                    hoverBackgroundColor: "red",
                    hoverBorderWidth: 10,
                    labels: this.rows.map((item) => item.regiao),
                    datasets: [
                        {
                            label: "Data One",
                            backgroundColor: ["#06d6a0", "#023047", "#00D8FF", "#ef476f", "#ffd166"],
                            data: this.rows.map((item) => {
                                return item.eventos.length
                            })
                        }
                    ]
                }
            }
        },
        components: {
            PieChart
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
                axios.get('/api/SensorEvent/numeric-event-value-by-region').then((result) => {
                    this.rows = result.data
                    
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
        <h4 class="mb-5">Eventos com valores numéricos por região</h4>
        <pie-chart v-if="!loading" :updated="!loading" :data="chartData" :options="chartOptions" style="max-width: 80%;margin: 0 auto;"></pie-chart>
    </div>
</template>