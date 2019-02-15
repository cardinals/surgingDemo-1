import React from 'react';
import { Router, Route, Switch } from 'dva/router';
import IndexPage from './routes/IndexPage';
import AuthorizedRoute from '../src/routes/AuthorizedRoute'
import Product from '../src/routes/Product'
import ProductDetail from '../src/routes/ProductDetail'
function RouterConfig({ history }) {

  const App = ({match,location,history}) => {
debugger
    return (
      <Switch>
        <Route path={`${match.path}/product`} exact component={Product}/>
        <Route path={`${match.path}/detail/:id`}  component={ProductDetail}/>
      </Switch>
    )
  }
  return (
    <Router history={history}>
      <Switch>
        <AuthorizedRoute path="/app"  component={App} />
      </Switch>
    </Router>
  );
}

export default RouterConfig;
