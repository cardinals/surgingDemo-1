import request from '../utils/request';

export async function query() {
  return request('/api/users');
}
export async function Authentication(params) {
	return request(`/api/user/authentication`, {
		method: 'post',
		mode: 'cors',
    traditional: true,
		body: JSON.stringify(params),
	})
}
export async function Regisger(params) {
	return request(`/api/User/Register`, {
		method: 'post',
		mode: 'cors',
    traditional: true,
		body: JSON.stringify(params),
	})
}