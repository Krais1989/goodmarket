import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseListPage } from '../base';

class UsersListPage extends BaseListPage {
    api = this.props.injects.gmapi.users;
}


export default withRouter(withGmInjection(UsersListPage));