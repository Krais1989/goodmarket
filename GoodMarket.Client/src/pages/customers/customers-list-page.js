import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseListPage } from '../base';

class CustomersListPage extends BaseListPage {
    api = this.props.injects.gmapi.customers;
}


export default withRouter(withGmInjection(CustomersListPage));