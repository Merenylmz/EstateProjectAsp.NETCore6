<template lang="">
    <div>
        
    </div>
</template>
<script>
import localStorage from "localStorage";
export default {
    beforeCreate(){
        localStorage.setItem("isAuth", 0);
        localStorage.removeItem("userId");
        window.location.href="/";
    }
}
</script>
<style lang="">
    
</style>