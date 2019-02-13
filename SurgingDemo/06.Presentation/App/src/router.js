import React from 'react';
import { Router, Route, Switch } from 'dva/router';
import IndexPage from './routes/IndexPage';
import AuthorizedRoute from '../src/routes/AuthorizedRoute'
import Product from '../src/routes/Product'
function RouterConfig({ history }) {

  const App = ({match}) => {
debugger
    return (
      <Switch>
        <Route path={match.path}  component={Product}/>
        <Route path={`${match.path}/Product`}  component={Product}/>
        <Route path={`${match.path}/EditTag/:tag`}  component={Product}/>
      </Switch>
    )
  }
  return (
    <Router history={history}>
      <Switch>
        <AuthorizedRoute path="/"  component={App} />
        <AuthorizedRoute path="/app"  component={App} />
      </Switch>
    </Router>
  );
}

export default RouterConfig;
