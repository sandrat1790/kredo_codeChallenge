import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "./productdetailpage.css";

function ProductDetail({ product }) {
  let navigate = useNavigate();

  useEffect(() => {
    if (!product) {
      console.error("no product", product);
      navigate("/category");
    }
  }, [product]);

  return (
    <div className="product-detail">
      <div className="detail-container">
        <div className="wrapper">
          <div className="product-img">
            <img
              src="https://tinyurl.com/23j8kasb"
              height="500"
              width="327"
              alt="example"
            />
          </div>
          <div className="product-info">
            <div className="product-text">
              <h1>{product.name}</h1>
              <p>{product.description}</p>
            </div>
            <div className="product-price-btn">
              <p>{product.price}</p>
              <button type="button">add to cart</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ProductDetail;
