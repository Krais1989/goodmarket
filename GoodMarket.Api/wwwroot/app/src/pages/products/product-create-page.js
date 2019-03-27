import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseCreatePage } from '../base';

class ProductCreatePage extends BaseCreatePage {
    api = this.props.injects.gmapi.products;
}

export default withRouter(withGmInjection(ProductCreatePage));