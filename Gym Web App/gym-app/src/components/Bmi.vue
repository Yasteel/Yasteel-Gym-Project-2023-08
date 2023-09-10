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
    
    const displayRules = reactive({
        showModal: false,
        showBmi: true,
        enableSaveButton: true
    })
    
    const bmiInfo = {
        gender: "",
        age: 0,
        weight: 0.00,
        height: 0.00,
        bmi: 0.00,
        bmiStatus: ""
    }

    const calculateBmi = () => {

    }

    const saveBmiRecord = () => {

    }
</script>

<template>
    <div class="bmiContainer">
        <DxForm
            :col-count="1"
            :form-data="bmiInfo"
            label-mode="floating"
        >
            <DxSimpleItem data-field="gender"></DxSimpleItem>
            <DxSimpleItem data-field="age" data-type="number"></DxSimpleItem>
            <DxSimpleItem data-field="weight"></DxSimpleItem>
            <DxSimpleItem data-field="height"></DxSimpleItem>
        </DxForm>

        <div class="bmiInfo">
            <DxButton
                width="100%"
                text="Calculate BMI"
                type="success"
                styling-mode="contained"
                @click="calculateBmi"
            />
        </div>
        <div class="bmiInfo" v-if="displayRules.showBmi" >
            <p> 
                BMI Status: <span>Just right</span>
            </p>
        </div>
        <div class="bmiInfo" v-if="displayRules.showBmi" >
            <p> 
                BMI: <span>5.5</span>
            </p>
        </div>
        <div class="bmiInfo">
            <DxButton
                width="100%"
                text="Save"
                type="success"
                styling-mode="contained"
                @click="saveBmiRecord"
            />
        </div>
    </div>
</template>

<style scoped>

    .bmiContainer {
        margin-top: 2rem;
    }
    .bmiInfo {
        margin: 1rem 0;
    }

    .bmiInfo p {
        display: inline-block;
        width: 100%;
        font-size: 1.2rem;
    }
</style>