import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import "../../../src/App.css";

function ProductIndex({ products, setProductId }) {
  const navigate = useNavigate();

  useEffect(() => {
    if (!products) {
      navigate("/category");
    }
  });

  return (
    <div className="product-index">
      {products.map((product) => {
        return (
          <div className="product-container" key={product.id}>
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">{product.name}</h5>
                  <hr></hr>
                  <button onClick={() => setProductId(product)}>
                    View Details
                  </button>

              </div>
            </div>
          </div>
        );
      })}
    </div>
  );
}

export default ProductIndex;
