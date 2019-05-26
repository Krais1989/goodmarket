
import React from 'react';
import { BaseSwitchPage } from '.';

const withBaseSwitch = ({ListPage, DetailsPage, EditPage, CreatePage}) => {
    return (props) => {
        return <BaseSwitchPage ListPage={ListPage} DetailsPage={DetailsPage} EditPage={EditPage} CreatePage={CreatePage} {...props} />
    }
}

export default withBaseSwitch;