import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseListPage } from '../base';

class ProductsListPage extends BaseListPage {
    api = this.props.injects.gmapi.products;
}


export default withRouter(withGmInjection(ProductsListPage));