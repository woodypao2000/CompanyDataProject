
<template>
  
   <el-form :model="form" label-width="auto" style="max-width: 600px">
    <el-form-item label="ReportDate">
      <el-input v-model="form.ReportDate" />
    </el-form-item>
    <el-form-item label="CompanyCode">
      <el-input v-model="form.CompanyCode" />
    </el-form-item>
    <el-form-item label="CompanyName">
      <el-input v-model="form.CompanyName" />
    </el-form-item>
    <el-form-item label="Industry">
      <el-input v-model="form.Industry" />
    </el-form-item>
    <el-form-item label="DataYearMonth">
      <el-input v-model="form.DataYearMonth" />
    </el-form-item>
    <el-form-item label="MonthlyRevenue">
      <el-input v-model="form.MonthlyRevenue" />
    </el-form-item>
    <el-form-item label="PreviousMonthlyRevenue">
      <el-input v-model="form.PreviousMonthlyRevenue" />
    </el-form-item>
    <el-form-item label="LastYearMonthlyRevenue">
      <el-input v-model="form.LastYearMonthlyRevenue" />
    </el-form-item>
    <el-form-item label="MonthlyComparisonPercentage">
      <el-input v-model="form.MonthlyComparisonPercentage" />
    </el-form-item>
    <el-form-item label="LastYearComparisonPercentage">
      <el-input v-model="form.LastYearComparisonPercentage" />
    </el-form-item>
    <el-form-item label="CumulativeRevenue">
      <el-input v-model="form.CumulativeRevenue" />
    </el-form-item>
    <el-form-item label="LastYearCumulativeRevenue">
      <el-input v-model="form.LastYearCumulativeRevenue" />
    </el-form-item>
    <el-form-item label="PreviousComparisonPercentage">
      <el-input v-model="form.PreviousComparisonPercentage" />
    </el-form-item>   
    <el-form-item label="Notes">
      <el-input v-model="form.notes" type="textarea" />
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onSubmit">Create</el-button>
    </el-form-item>
   </el-form>
</template>
<script lang='ts' setup>
import { reactive } from 'vue'
import axios from 'axios';
import { ElMessageBox, ElMessage } from 'element-plus';
import{useRouter} from'vue-router'
const router=useRouter();
const form = reactive({
  CompanyCode: '',
  ReportDate: '',
  DataYearMonth: '',
  CompanyName: '',
  Industry: '',
  MonthlyRevenue: 0,
  PreviousMonthlyRevenue: 0,
  LastYearMonthlyRevenue: 0,
  MonthlyComparisonPercentage: 0,
  LastYearComparisonPercentage: 0,
  CumulativeRevenue: 0,
  LastYearCumulativeRevenue: 0,
  PreviousComparisonPercentage: 0,
  notes: ''
});
const onSubmit = async () => {
   try {
    const response = await axios.post('http://localhost:5100/api/Tool/PostCompanyData',form);
    console.log('Data submitted:', response.data);
    ElMessageBox.alert('Data submitted successfully!', 'Success', {
      confirmButtonText: 'OK'
    }
  );router.push("/")
  } catch (error) {
    
    console.error('Error submitting data:', error);
    ElMessage({
      message: 'Error submitting data: ' + error,
      type: 'error',
    });
  }
}
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


</style>
