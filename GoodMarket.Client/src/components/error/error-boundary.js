import React from 'react';
import ErrorIndicator from './error-indicator';


export default class ErrorBoundary extends React.Component {

    state = {
        hasError: false,
        errorMessage: ""
    }

    componentDidCatch(error, info){
        this.setState ({
            hasError: true,
            errorMessage: info
        })
    }

    render() {
        if (this.state.hasError || this.props.showError){
            return (<ErrorIndicator message={this.state.errorMessage} />);
        }
        return this.props.children;
    }
}