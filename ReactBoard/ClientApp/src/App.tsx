import React from 'react';
import { Route } from 'react-router';
import { Switch } from 'react-router-dom';
import { Administration, Home, Thread } from './components';
import { BoardCatalogView, BoardPaginatedView } from './components/board';
import { BoardsContext, MessageKeysContext } from './global/context';
import './styles.scss';

const App = () => {
    return (
        <MessageKeysContext>
            <BoardsContext>
                <Switch>
                    <Route exact path="/" component={Home} />
                    <Route path="/admin" component={Administration} />
                    <Route path="/:boardUrlName/catalog" component={BoardCatalogView} />
                    <Route path="/:boardUrlName/:pageNumber" component={BoardPaginatedView} />
                    <Route path="/:boardUrlName" component={BoardPaginatedView} />
                    <Route path="/:boardUrlName/:threadId" component={Thread} />
                </Switch>
            </BoardsContext>
        </MessageKeysContext>
    )
}

export default App