<script setup lang="ts">
    import 
        { 
            reactive,
            onMounted 
        } from 'vue'

    var props:any = defineProps({
        currentTab: {}
    });

    var navSetting = reactive({
        currentTab: 0
    });

    onMounted(() => {
        navSetting.currentTab = props.currentTab;
    })


</script>

<template>
    <nav>
        <div>
            <h2>Gym <span>App</span></h2>
        </div>
        <div>
            <ul>
            <li id="nav-item-1" :class="props.currentTab == 0 ? 'current' : ''">Members</li>
            <li id="nav-item-2" :class="props.currentTab == 2 ? 'current' : ''">Trainers</li>
            <li id="nav-item-3" :class="props.currentTab == 3 ? 'current' : ''">About</li>
        </ul>
        </div>
    </nav>
</template>

<style scoped>
    nav{
        width: 100%;
        background: hsl(0 0% 0%);
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem 2rem;
    }

    ul{
        display: inline-flex;
        gap: 1rem;
        list-style-type: none;
    }

    li{
        display: grid;
        place-items: center;
        height: 35px;
        width: 120px;
        border-radius: 20px;
        font-size: .9rem;
        color: hsl(0 100% 100%)
    }
    
    li:hover{
        background: hsl(156, 91%, 48%);
        color: hsl(0, 0%, 30%);
        cursor: pointer;
    }
    li.current{
        background: hsl(156, 91%, 48%);
        color: hsl(0, 0%, 30%);
    }

    h2{
        font-weight: 400;
        font-size: 2rem;
    }

    span{
        color: hsl(156, 91%, 48%)
    }

</style>