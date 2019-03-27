import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseDetailsPage } from '../base';

class CustomerDetailsPage extends BaseDetailsPage {
    api = this.props.injects.gmapi.customers;
}

export default withRouter(withGmInjection(CustomerDetailsPage));