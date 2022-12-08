import React, { useEffect, useState } from "react";
import {
  Route,
  Routes,
  useNavigate,
  Navigate,
} from "react-router-dom";
import CategoryIndex from "./components/categories/CategoryIndex";
import ProductIndex from "./components/products/ProductIndex";
import ProductDetailPage from "./components/products/ProductDetailPage";
import * as categoryService from "./services/categoryService";
// import * as productService from "./services/productService";

function App() {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [categoryId, setCategoryId] = useState(null);
  const [product, setProduct] = useState(null);
  let navigate = useNavigate();

  useEffect(() => {
    console.log("firing useEffect for getCategories");
    categoryService
      .getCategories()
      .then((res) => setCategories(res.items))
      .catch((err) => console.error(err));
  }, []);

  useEffect(() => {
    if (categoryId) {
      console.log("catId", categoryId);
      categoryService
        .getProductByCategory(categoryId)
        .then((res) => {
          setProducts(res.items);
          navigate(`/category/${categoryId}`);
        })
        .catch((err) => console.error(err));
    }
  }, [categoryId]);

  useEffect(() => {
    console.log("product", product);
    if (product) {
      navigate(`/product/${product.id}`);
    }
  }, [product]);

  return (
    <React.Fragment>
      <Routes>
        <Route path="/" element={<Navigate to="/category" />} />
        <Route
          path="/category"
          element={
            <CategoryIndex
              categories={categories}
              setCategoryId={setCategoryId}
            />
          }
        ></Route>
        <Route
          path="/category/:id"
          element={
            <ProductIndex
              products={products}
              setProductId={setProduct}
            />
          }
        ></Route>
        <Route
          path="/product/:id"
          element={<ProductDetailPage product={product} />}
        ></Route>
      </Routes>
    </React.Fragment>
  );
}

export default App;
