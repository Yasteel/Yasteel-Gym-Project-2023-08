<script setup lang="ts">
    import NavBar from './components/NavBar.vue'
    import Members from './components/Members.vue'


</script>

<template>
    <section class="nav">
        <NavBar :currentTab="0"></NavBar>
    </section>
    <section class="body">
        <Members></Members>
    </section>
    <section class="footer"></section>
</template>

<style>

</style>