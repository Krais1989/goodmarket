import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseDetailsPage } from '../base';

class OrderDetailsPage extends BaseDetailsPage {
    api = this.props.injects.gmapi.orders;
}

export default withRouter(withGmInjection(OrderDetailsPage));