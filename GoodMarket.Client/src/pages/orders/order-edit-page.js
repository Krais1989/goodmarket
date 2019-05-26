import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseEditPage } from '../base';

class OrderEditPage extends BaseEditPage {
    api = this.props.injects.gmapi.orders;

}

export default withRouter(withGmInjection(OrderEditPage));