import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseDetailsPage } from '../base';

class ProductDetailsPage extends BaseDetailsPage {
    api = this.props.injects.gmapi.products;
}

export default withRouter(withGmInjection(ProductDetailsPage));