<script>

    import AmountCards from './Components/AmountCards.vue'
    import EventsTable from './Components/EventsTable.vue'
    import Charts from './Components/Charts.vue'

    export default {
        data() {
            return {
                updateTime: 10000
            }
        },
        components: {
            AmountCards,
            EventsTable,
            Charts
        }
    }
</script>

<template>
    <div>
        <div class="row">
            <div class="col-auto">
                <h3>Analyst Challange - Sensor Events</h3>
            </div>
            <div class="col-auto pt-2">
                <label>Atualização a cada </label>
                <select v-model="updateTime" class="ml-2">
                    <option value="5000">5 segundos</option>
                    <option value="10000">10 segundos</option>
                    <option value="15000">15 segundos</option>
                    <option value="20000">20 segundos</option>
                    <option value="30000">30 segundos</option>
                    <option value="60000">1 minuto</option>
                </select>
            </div>
        </div>
        <hr />    
        <div class="row">

            <div class="col-md-7 pr-5">
                <amount-cards :update-time="updateTime" />
                <events-table :update-time="updateTime" />                
            </div>
            <div class="col-md-5">
                <charts :update-time="updateTime" />
            </div>
        </div>        
    </div>
</template>