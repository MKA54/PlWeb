<template>
    <nav>
        <p>
            <router-link to="/">
                Form
            </router-link>
            <router-link to="/forms">
                All form
            </router-link>
        </p> 
    </nav>
    <router-view />
</template>

<script>
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
