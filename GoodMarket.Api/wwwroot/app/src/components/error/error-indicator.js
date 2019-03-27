import React from 'react';
import icon from './error.jpg';
import './error.css';

const ErrorIndicator = ({message})=>{
    return (
        <div className="error-container">
            <img className="error-image" src={icon} alt="error icon"></img>
            <div className="error-title">Хрясь!</div>
            <div>Произошла ошибка</div>
            <div>{message}</div>
        </div>
    );
}

export default ErrorIndicator;