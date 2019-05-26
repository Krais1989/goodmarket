import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseListPage } from '../base';

class OrdersListPage extends BaseListPage {
    api = this.props.injects.gmapi.orders;
}


export default withRouter(withGmInjection(OrdersListPage));