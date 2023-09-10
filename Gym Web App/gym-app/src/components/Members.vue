<script setup lang="ts">
    import { 
        ref, 
        onMounted,
        reactive
    } from 'vue'
    
    import {
        DxDataGrid,
        DxColumn,
        DxPaging,
        DxEditing,
        DxForm
    } from 'devextreme-vue/data-grid'


    import notify from 'devextreme/ui/notify';
    import axios from 'axios';

    import WeighIn from './WeighIn.vue';


    const datasource = ref(null);
    const weighInPage: (any) = ref(null);

    const openWeighIn = () => {
        weighInPage.value.open();
    }

    const buttons = reactive({
        customButtons: [
            "edit",
            "delete",
            {
                text: "Action 1",
                icon: "fa-solid fa-scale-unbalanced",
                onClick: openWeighIn,
            }
    ]
    })


    
    onMounted(() => {
        getMembers();
    });


    let getMembers = async () => {
        axios.get('https://localhost:7136/api/Members', {
            method: 'GET'
        })
        .then(response => datasource.value = response.data.payload)
        .catch(err => console.log(err));
    };

    

    const onSaved = (values: any) => {
        if(values.changes.length != 0){
            var memberId = values.changes[0].data.memberId;
            axios.patch(`https://localhost:7136/api/Members/${memberId}`, JSON.stringify(values.changes[0].data),{
                'headers': {
                    'Content-Type': "application/json"
                }
            })
            .then((response) => {
                console.log(response);
                notify("Update Succcess", "success");
            })
            .catch(err => console.log(err));
        }
    }

</script>

<template>
    <div class="datagridWrapper">
        <DxDataGrid
            :data-source="datasource"
            id="testDatagrid"
            :hoverStateEnabled="true"
            :showBorders="true"
            :onSaved="onSaved"
        >
            <DxPaging :page-size="10"/>
            <DxEditing
                :allow-adding="true"
                :allow-updating="true"
                :allow-deleting="true"
                mode="form"
            >
                <DxForm
                    id="form"
                    label-mode="floating"
                    label-location="left"
                    read-only="false"
                    col-count="3"
                >
                    
                </DxForm>
            </DxEditing>
            <DxColumn 
                data-field="memberId"
                caption="Member Id"
                :visible="false"
                :disabled="true"
                :width="500"
            >

            </DxColumn>
            <DxColumn 
                data-field="idNumber"
                caption="ID Number"
            >

            </DxColumn>
            <DxColumn 
                data-field="name"
                caption="Name"
            >

            </DxColumn>
            <DxColumn 
                data-field="surname"
                caption="Surname"
            >

            </DxColumn>
            <DxColumn 
                data-field="gender"
                caption="Gender"
            >

            </DxColumn>
            <DxColumn 
                data-field="age"
                caption="Age"
            >

            </DxColumn>
            <DxColumn 
                data-field="height"
                caption="Height"
                :visible="false"
            >

            </DxColumn>
            <DxColumn 
                data-field="contactNumber"
                caption="Contact#"
            >

            </DxColumn>
            <DxColumn 
                data-field="joinDate"
                data-type="date"
                caption="Join Date"
            >

            </DxColumn>
            <DxColumn 
                data-field="membershipType"
                caption="Membership Type"
            >
            </DxColumn>
            <DxColumn 
                type="buttons" 
                :buttons="buttons.customButtons" 
                use-icons="true"
            />



        </DxDataGrid>
        <WeighIn ref="weighInPage"></WeighIn>
    </div>
</template>

<style scoped>
    .datagridWrapper{
        padding: 2rem;
    }
</style>

  