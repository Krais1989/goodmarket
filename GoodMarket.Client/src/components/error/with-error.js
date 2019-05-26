import React from 'react';

import ErrorBoundary from './error-boundary';

const withError = (Wrapped)=>{
    return (props) => {
        return (
            <ErrorBoundary>
                <Wrapped {...props} />
            </ErrorBoundary>
        );
    }

}

export default withError;