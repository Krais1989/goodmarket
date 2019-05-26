import React from 'react';
import LoadIndicator from './load-indicator';


 const LoadBoundary = ({isLoading, children})=> {

    if (isLoading)
        return <LoadIndicator />
    return children;
}

export default LoadBoundary;