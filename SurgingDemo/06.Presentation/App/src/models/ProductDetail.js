
import { parse } from 'qs';
import { GetForModify,CreateOrder } from '../services/Product'
import com from '../utils/commom'
import {message} from 'antd';
export default {
  namespace: 'productDetail',
  state: {
    info:{

    }
  },
  subscriptions: {
    sb: function () {
    }
  },
  effects: {
    *GetForModify({ payload }, { call, put }) {  // eslint-disable-line
      const { data } = yield call(GetForModify, parse({entityQueryRequest:payload}))
        if(data&&data.IsSucceed&&data.StatusCode===200){
          yield put({
            type:'GetForModifySuc',
            payload:{
                     data:JSON.parse(data.Entity)
            }
          })
        }
    },
    *CreateOrder({ payload }, { call, put }){
      message.loading('处理中...')
      const { data } = yield call(CreateOrder, parse({orderInfoRequestDto:payload}))

      if(data&&data.IsSucceed){
          var json=JSON.parse(data.Entity);
          if(json.IsValid){
            message.success("购买成功!")
          }
      }
    }
  },
  reducers: {
    GetForModifySuc(state, action) {
      return { ...state, info:action.payload.data };
    }
  }
};
