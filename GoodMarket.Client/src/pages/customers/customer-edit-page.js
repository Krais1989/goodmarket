import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseEditPage } from '../base';

class CustomerEditPage extends BaseEditPage {
    api = this.props.injects.gmapi.customers;

}

export default withRouter(withGmInjection(CustomerEditPage));