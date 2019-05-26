import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseEditPage } from '../base';

class ProductEditPage extends BaseEditPage {
    api = this.props.injects.gmapi.products;

}

export default withRouter(withGmInjection(ProductEditPage));