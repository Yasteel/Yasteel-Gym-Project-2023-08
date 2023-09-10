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
        
    })

    const fitness = reactive({
        HRrest: null,
        HRmax: null,
        VO2max: null,
    })

    const calculateFitnessLevels = () => {

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
        <div class="bmiInfo">
            <DxButton
                width="100%"
                text="Calculate Fitness Levels"
                type="success"
                styling-mode="contained"
                @click="calculateFitnessLevels"
            />
        </div>
    </div>
</template>

<style scoped>

</style>