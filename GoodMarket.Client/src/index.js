import React from 'react';
import ReactDOM from 'react-dom';

import App from './components/app';
import HttpService from './services/http-service';
import { RestApiService } from './services';

import GmContext from './context/gm-context';

/* Services */
const http = new HttpService();
const apiUrl = "https://localhost:5001/api";
const gmapi = {
    http: http,
    products:  new RestApiService(apiUrl, "/products", http),
    users:  new RestApiService(apiUrl, "/users", http),
    orders: new RestApiService(apiUrl, "/orders", http),
    customers: new RestApiService(apiUrl, "/customers", http),
}

/* Injectibles */
const injects = {
    gmapi
}

ReactDOM.render(
    <GmContext.Provider value={injects}>
        <App/>
    </GmContext.Provider>, document.getElementById("root"));