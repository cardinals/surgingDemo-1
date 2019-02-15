
import { parse } from 'qs';
import { Authentication,Regisger } from '../services/Login'
import com from '../utils/commom'
export default {
  namespace: 'login',
  state: {
    test:{abc:1232},
    isRegister:false
  },
  subscriptions: {
    sb: function () {
    }
  },
  effects: {
    *Regisger({ payload }, { call, put }){
      
      const { data } = yield call(Regisger, parse({userRequestDto:payload}))
      if(data&&data.IsSucceed&&data.StatusCode===200){
        
        yield put({
          type:'RegisterToggle'
        })
      }
      
    },
    *LoginOn({ payload }, { call, put }) {  // eslint-disable-line
     // com.SetCookie('token', payload.username)
     debugger
      const { data } = yield call(Authentication, parse({userRequestDto:payload}))
      debugger

        if(data&&data.IsSucceed&&data.StatusCode===200){
          com.SetPkey(data.Entity)
          yield put({
            type:'authorize/Power'
          })
        }
    },
  },
  reducers: {
    save(state, action) {
      return { ...state, ...action.payload };
    },
    RegisterToggle(state, action){
      return { ...state, isRegister:!state.isRegister };
    }
  }
};
