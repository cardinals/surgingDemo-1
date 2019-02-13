import request from '../utils/request';
import qs from 'qs';
export async function New(params) {
	return request(`/Applications/New`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function FormGetListPaged(params) {
	return request(`/FormTemplateVersion/GetListPaged`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function ReportGetListPaged(params) {
	return request(`/Report/GetListPaged`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function ApplicationsGetListPaged(params) {
	return request(`/api/Goods/GetPageList`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function TemplateListByAppIdPaged(params) {
	return request(`/Applications/TemplateListByAppIdPaged`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function ReportListByAppIdPaged(params) {
	return request(`/Applications/ReportListByAppIdPaged`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}


export async function Modify(params) {
	return request(`/Applications/Modify`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function GetForModify(params) {
	return request(`/Applications/GetForModify`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function AppTempBatchNew(params) {
	return request(`/ApplicationTemplate/BatchNew`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function ApplicationTemplateRemove(params) {
	return request(`/ApplicationTemplate/Remove`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function CopyReport(params) {
	return request(`/Applications/CopyReport`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function CopyForm(params) {
	return request(`/FormTemplate/Copy`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}

export async function Publish(params) {
	return request(`/Applications/Publish`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function UnPublish(params) {
	return request(`/Applications/UnPublish`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
export async function Remove(params) {
	return request(`/Applications/Remove`, {
		method: "post",	
		body: JSON.stringify(params)	
	})
}
