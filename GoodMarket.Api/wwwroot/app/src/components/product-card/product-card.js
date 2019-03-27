import React from 'react';
import './product-card.css';
import mockImage from './product.png';

const ProductCard = ({imgUrl, title, text, btnTitle, onBtnClick}) => {
    return (
        <div className="card product-card">
            <img className="card-img-top" src={imgUrl?imgUrl:mockImage} alt="Product"/>
            <div className="card-body">
                <h5 className="card-title">{title}</h5>
                <p className="card-text">
                    {text}
                </p>
                <button className="btn btn-primary w-100" onClick={onBtnClick}>{btnTitle}</button>
            </div>
        </div>
    );
}

export default ProductCard;