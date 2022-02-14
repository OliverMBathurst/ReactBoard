import React from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import { Administration, Board, Home, Thread } from './components';
import { BoardCatalogView } from './components/board';
import { AdminRoute, HomeRoute } from './global/constants/routes';
import './styles.scss';

const App = () => {
    return (
        <Switch>
            <Route exact path={HomeRoute} component={Home} />
            <Route path={AdminRoute} component={Administration} />
            <Route path="/:boardUrlName/catalog" render={({ match }) => <BoardCatalogView boardUrlName={match.params.boardUrlName} />} />
            <Route path="/:boardUrlName/:pageNumber" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} pageNumber={match.params.page} />} />
            <Route path="/:boardUrlName" render={({ match }) => <Board boardUrlName={match.params.boardUrlName} />} />
            <Route path="/:boardUrlName/:threadId" render={({ match }) => <Thread id={match.params.threadId} boardUrlName={match.params.boardUrlName} />} />
        </Switch>
    )
}

export default App