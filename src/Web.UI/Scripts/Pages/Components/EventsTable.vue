<script>
    import axios from 'axios'
    var interval = null

    export default {
        props: ['updateTime'],
        data() {
            return {
                loading: false,
                columns: [
                    {
                        label: 'Data/Hora do envio',
                        field: 'timestamp',
                    },
                    {
                        label: 'Regiao',
                        field: 'regiao',
                    },
                    {
                        label: 'Sensor',
                        field: 'sensor',
                    },
                    {
                        label: 'Valor',
                        field: 'valor',
                    },
                    {
                        label: 'Status',
                        field: 'status',
                    }                    
                ],
                rows: [],
            };
        },
        filters: {
            timestampToData(value) {
                return new Date(value).toLocaleString("pt-br");
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
                axios.get('/api/SensorEvent').then((result) => {
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
        <h4>Todos os Eventos</h4>
        <h5 v-if="loading">Carregando</h5>
        <vue-good-table class="table-responsive" :columns="columns"
                        :rows="rows"
                        :fixed-header="true"
                        :search-options="{ enabled: true }"
                        :pagination-options="{ enabled: false }" 
                        theme="polar-bear"
                        :isLoading.sync="loading" >
            <template slot="table-row" slot-scope="props">
                <span v-if="props.column.field == 'timestamp'">
                    {{props.row.timestamp | timestampToData }}
                </span>
            </template>
        </vue-good-table>
    </div>
</template>