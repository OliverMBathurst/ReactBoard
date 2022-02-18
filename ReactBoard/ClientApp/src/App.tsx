import React from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import { Administration, Home, Thread } from './components';
import { Board, BoardCatalogView } from './components/board';
import { AdminRoute, HomeRoute } from './global/constants/routes';
import './styles.scss';

const App = () => {
    return (
        <Switch>
            <Route exact path={HomeRoute} component={Home} />
            <Route path={AdminRoute} component={Administration} />
            <Route path="/:boardUrlName/catalog" render={({ match }) => <BoardCatalogView boardUrlName={match.params.boardUrlName} />} />
            <Route path="/:boardUrlName/:pageNumber" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} pageNumber={parseInt(match.params.pageNumber)} />} />
            <Route path="/:boardUrlName" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} />} />
            <Route path="/:boardUrlName/:threadId" render={({ match }) => <Thread boardUrlName={match.params.boardUrlName} threadId={parseInt(match.params.threadId)} />} />
        </Switch>
    )
}

export default App