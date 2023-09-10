<script setup lang="ts">
    import { 
        reactive
    //     prop 
    } from 'vue'
    
    import { 
        DxPopup, 
        DxPosition,
    } from 'devextreme-vue/popup';

    import {
        DxTabPanel,
        DxItem
    } from 'devextreme-vue/tab-panel'

    import Bmi from './Bmi.vue'
    import FitnessLevel from './FitnessLevel.vue'
    
    const displayRules = reactive({
        showModal: false,
        showBmi: true,
        enableSaveButton: true
    })

    const open = () => {
        displayRules.showModal = true;
    }
    
    const close = () => {
        displayRules.showModal = false;
    }


    defineExpose({
        open
    })

</script>

<template>
    <div class="weighInContainer" >
        <DxPopup 
            title="Weigh In"
            :visible="displayRules.showModal"
            :show-close-button="true"
            :hide-on-outside-click="true"
            :onHiding="close"
            width="30vw"
            height="auto"
        >
            <DxPosition
                at="center"
                my="center"

                collision="fit"
            />

            <DxTabPanel>
                <DxItem title="BMI">
                    <Bmi></Bmi>
                </DxItem>
                <DxItem title="HRmax | VO2max">
                    <FitnessLevel></FitnessLevel>
                </DxItem>
            </DxTabPanel>

            
        </DxPopup>
        
    </div>
</template>

<style scoped>
    
</style>