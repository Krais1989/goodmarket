import React from 'react';


const withInjection = (Wrapped, Consumer)=>{

    return (props) =>{
        return (
            <Consumer>
                {(injects)=>{
                    return (
                        <Wrapped {...props} injects={injects} /> 
                    );
                }}
            </Consumer>
        );
    };
}

export default withInjection;