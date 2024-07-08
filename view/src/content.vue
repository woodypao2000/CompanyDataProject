<template>
      <div>
    <a href="https://vitejs.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + Vue" />
  <button :class="{ active: isActive }" :style="{ backgroundColor: buttonColor }" @click="vbindClick">v-bind & v-on</button>
  <p>Total Records by computed: {{ totalRecords }}</p>
  <el-table :data="tableData" style="width: 100%">
    <el-table-column prop="reportDate" label="Report Date" width="180"/>
    <el-table-column prop="dataYearMonth" label="Data Year Month" width="180"/>
    <el-table-column prop="companyName" label="Company Name" width="180"/>
    <el-table-column prop="industry" label="Industry" width="180"/>
    <el-table-column prop="monthlyRevenue" label="Monthly Revenue" width="180"/>
    <el-table-column prop="lastYearMonthlyRevenue" label="Last Year Monthly Revenue" width="180"/>
    <el-table-column prop="monthlyComparisonPercentage" label="Monthly Comparison Percentage" width="200"/>
    <el-table-column prop="lastYearComparisonPercentage" label="Last Year Comparison Percentage" width="200"/>
    <el-table-column prop="cumulativeRevenue" label="Cumulative Revenue" width="180"/>
    <el-table-column prop="lastYearCumulativeRevenue" label="Last Year Cumulative Revenue" width="200"/>
    <el-table-column prop="previousComparisonPercentage" label="Previous Comparison Percentage" width="200"/>
    <el-table-column prop="notes" label="Notes" width="100"/>
    <el-table-column prop="companyCode" label="Company Code" width="180"/>
  </el-table>
  

</template>
<script lang='ts' setup>
import axios from 'axios';
import { ref, onMounted,computed } from 'vue';
const tableData = ref([]);

const fetchData = async () => {
  try {
    const response = await axios.get('http://localhost:5100/api/Tool/GetEntities');
    tableData.value = response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
  }
};
const totalRecords = computed(() => {
  return tableData.value.length;
});
onMounted(() => {
  fetchData();
});

const isActive = ref(false);
const buttonColor = ref('blue');
const vbindClick = () => {
  isActive.value = !isActive.value;
  buttonColor.value = isActive.value ? 'green' : 'blue';
};
</script>
  <style scoped>
  .logo {
    height: 6em;
    padding: 1.5em;
    will-change: filter;
    transition: filter 300ms;
  }
  .logo:hover {
    filter: drop-shadow(0 0 2em #646cffaa);
  }
  .logo.vue:hover {
    filter: drop-shadow(0 0 2em #42b883aa);
  }
  .hello{ 
  color: blue;
  }
  .main .world{
    color: aqua;
  }
  .active {
  font-weight: bold;
}
  
  </style>