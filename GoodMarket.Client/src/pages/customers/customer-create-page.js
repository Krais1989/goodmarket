import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseCreatePage } from '../base';

class CustomerCreatePage extends BaseCreatePage {
    api = this.props.injects.gmapi.customers;
}

export default withRouter(withGmInjection(CustomerCreatePage));