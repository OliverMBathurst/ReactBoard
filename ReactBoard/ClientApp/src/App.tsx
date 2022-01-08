import React from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import Administration from './components/administration/administration';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import Home from './components/home/home';
import { AdminRoute, HomeRoute } from './global/constants/routes';
import './styles.scss';

const App = () => {
    return (
        <Switch>
            <Route exact path={HomeRoute} component={Home} />
            <Route path={AdminRoute} component={Administration} />
            <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
        </Switch>
    )
}

export default App