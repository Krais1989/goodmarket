import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseEditPage } from '../base';

class UserEditPage extends BaseEditPage {
    api = this.props.injects.gmapi.users;

}

export default withRouter(withGmInjection(UserEditPage));