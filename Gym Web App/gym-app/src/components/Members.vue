<script setup >
    import { 
        ref, 
        onMounted,
        reactive
    } from 'vue'
    
    import {
        DxDataGrid,
        DxColumn,

    } from 'devextreme-vue/data-grid'


    // interface Members{
    //     MemberId: number,
    //     IdNumber: string,
    //     Name: string,
    //     Surname: string,
    //     Gender: string,
    //     Age: number,
    //     Contact: string,
    //     JoinDate: Date,
    //     MembershipType: number,
    // }



    var datasource = ref(null);
    var columns = ref([
        { dataField: 'memberid', caption: 'Member Id' },
        { dataField: 'name', caption: 'Name' },
        { dataField: 'surname', caption: 'Surname' },
        { dataField: 'age', caption: 'Age' },
        { dataField: 'contact', caption: 'Contact#' },
    ]);
    
    const editingOptions = reactive({
      mode: 'form', // Enables row editing
      allowAdding: true, // Enables adding new rows
      allowUpdating: true, // Enables editing existing rows
      allowDeleting: true, // Enables deleting rows
      useIcons: true, // Use icons for edit actions
    });

    
    onMounted(() => {
        getMembers();
    });


    let getMembers = async () => {
        axios.get('https://localhost:7136/api/Members', {
            method: 'GET'
        })
        .then(response => datasource.value = response.data.payload)
        .catch(err => console.log(err));

        // const response = fetch('https://localhost:7136/api/Members');
        // const members = (await response).json();
        
        // console.log(await members.payload);

        // datasource.value = await members.payload;

    };

</script>

<template>
    <div class="datagridWrapper">
        <DxDataGrid
            :data-source="datasource"
            :editing="editingOptions"
            :columns="columns"
        >
        </DxDataGrid>
    </div>
</template>

<style scoped>
    .datagridWrapper{
        padding: 2rem;
    }
</style>