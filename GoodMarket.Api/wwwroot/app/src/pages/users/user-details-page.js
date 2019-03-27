import React from 'react';
import { withRouter } from 'react-router-dom';
import { withGmInjection } from '../../context';
import { BaseDetailsPage } from '../base';

class UserDetailsPage extends BaseDetailsPage {
    api = this.props.injects.gmapi.users;
}

export default withRouter(withGmInjection(UserDetailsPage));