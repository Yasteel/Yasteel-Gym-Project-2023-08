<script setup lang="ts">
    import { 
        reactive
    } from 'vue'

    import {
        DxForm,
        DxSimpleItem,
    } from 'devextreme-vue/form'

    import {
        DxButton
    } from 'devextreme-vue'   

    const formData = {
        HRrest: null
    }

    const displayRules = reactive({
        showResults: true
    })

    const fitness = reactive({
        HRrest: null,
        HRmax: null,
        VO2max: null,
    })

    const calculateFitnessLevels = () => {

    }

    const saveFitnessRecord = () => {

    }

</script>

<template>
    <div class="cardioHealthContainer">
        <DxForm
            :col-count="1"
            :form-data="formData"
            label-mode="floating"
        >
            <DxSimpleItem data-field="HRrest"></DxSimpleItem>
        </DxForm>
        <div class="fitnessLevel">
            <DxButton
                width="100%"
                text="Calculate Fitness Levels"
                type="success"
                styling-mode="contained"
                @click="calculateFitnessLevels"
            />
        </div>
        <div class="fitnessLevel" v-if="displayRules.showResults" >
            <p> 
                HRmax: <span>{{ fitness.HRmax }}</span>
            </p>
        </div>
        <div class="fitnessLevel" v-if="displayRules.showResults" >
            <p> 
                VO2max: <span>{{ fitness.VO2max }}</span>
            </p>
        </div>
        <div class="fitnessLevel" v-if="displayRules.showResults">
            <DxButton
                width="100%"
                text="Save"
                type="success"
                styling-mode="contained"
                @click="saveFitnessRecord"
            />
        </div>
    </div>
</template>

<style scoped>
    .cardioHealthContainer {
        margin-top: 2rem;
    }
    .fitnessLevel {
        margin: 1rem 0;
    }

    .fitnessLevel p {
        display: inline-block;
        width: 100%;
        font-size: 1rem;
    }
</style>