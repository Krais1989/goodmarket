import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseCreatePage } from '../base';

class UserCreatePage extends BaseCreatePage {
    api = this.props.injects.gmapi.users;
}

export default withRouter(withGmInjection(UserCreatePage));