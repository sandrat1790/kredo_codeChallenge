import React from "react";
import "../../../src/App.css";

function CategoryIndex({ categories, setCategoryId }) {
  return (
    <div className="category-index">
      {categories.map((category) => {
        return (
          <div className="category-container" key={category.id}>
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">{category.name}</h5>
                <p><img
              src="https://tinyurl.com/23j8kasb"
              height="100"
              width="100"
              alt="example"
            /></p>
                <button onClick={() => setCategoryId(category.id)}>
                  view
                </button>
              </div>
            </div>
          </div>
        );
      })}
    </div>
  );
}

export default CategoryIndex;
