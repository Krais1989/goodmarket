import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseCreatePage } from '../base';

class OrderCreatePage extends BaseCreatePage {
    api = this.props.injects.gmapi.orders;
}

export default withRouter(withGmInjection(OrderCreatePage));