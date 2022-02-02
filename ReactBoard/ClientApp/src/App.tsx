import React from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import { Administration, Board, Home, Thread } from './components';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { AdminRoute, HomeRoute } from './global/constants/routes';
import './styles.scss';

const App = () => {
    return (
        <Switch>
            <Route exact path={HomeRoute} component={Home} />
            <Route path={AdminRoute} component={Administration} />
            <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            <Route path="/board/:boardUrlName/:pageNumber" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} pageNumber={match.params.page}/>} />
            <Route path="/board/:boardUrlName" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} />} />
            <Route path="/thread/:threadId" render={({ match }) => <Thread id={match.params.threadId} />} />
        </Switch>
    )
}

export default App