import React from 'react';
import {BrowserRouter as Router, Route, Switch, withRouter, Redirect} from 'react-router-dom';

/* Переключает страницу в зависимости от path url */
const BaseSwitcherPage = ({ ListPage    =   ()=>(<h2>Base List Page</h2>), 
                            DetailsPage =   ()=>(<h2>Base Details Page</h2>) , 
                            EditPage    =   ()=>(<h2>Base Edit Page</h2>), 
                            CreatePage    =   ()=>(<h2>Base Create Page</h2>), 
                            match, location, ...others}) => {
    
    /** Родительский Route для текущего BaseSwitcherPage-компонента должен иметь путь "/[domain]" без / вконце и exact аттрибута */
    /** Автоматически переводит /domain в /domain/ */

    const parentPath = match.path;          // Путь родительского Route.path
    const domainRoot = parentPath + '/';    // Правильный путь корневого домена (/users/, /products/, etc...)
    const currentUrl = location.pathname;   // Текущий url

    if ( currentUrl === parentPath )
        return <Redirect to={domainRoot} />

    return (
        <Router>
            <Switch>
                <Route path={domainRoot} component = {ListPage} exact />
                <Route path={`${domainRoot}create`} component = {CreatePage} exact />
                <Route path={`${domainRoot}edit/:id`} component = {EditPage} exact />
                <Route path={`${domainRoot}:id`} component = {DetailsPage} exact />
                <Redirect to={domainRoot} />
            </Switch>
        </Router>
    );
}

export default withRouter(BaseSwitcherPage);