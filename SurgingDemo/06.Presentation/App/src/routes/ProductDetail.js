import React, { PropTypes } from 'react';
import { connect } from 'dva';
import ProductDetail from '../components/ProductDetail';

function ProductDetailRoute({ location, dispatch, productDetail,history }) {
   
    const ProductDetailProps = {
        onOk(data) {
            debugger
            dispatch({
                type: 'productDetail/LoginOn',
                payload: data,
              
            })
         
        }
    }
    return (
        <ProductDetail {...ProductDetailProps} />
    )
}
//监听属性，建立组件和数据的映射关系
function mapStateToProps({ productDetail }) {
    return { productDetail };
}
//关联model
export default connect(mapStateToProps)(ProductDetailRoute);