import axios from "axios";
import {
  onGlobalSuccess,
  onGlobalError,
} from "../services/serviceHelper";

const api = "https://localhost:50001/api/category";

const getCategories = () => {
  const config = {
    method: "GET",
    url: api,
    withCredentials: true,
    crossdomain: true,
    headers: { "Content-Type": "application/json" },
  };
  return axios(config).then(onGlobalSuccess).catch(onGlobalError);
};

const getProductByCategory = (categoryId) => {
  const config = {
    method: "GET",
    url: `${api}/${categoryId}/products`,
    withCredentials: true,
    crossdomain: true,
    headers: { "Content-Type": "application/json" },
  };
  return axios(config).then(onGlobalSuccess).catch(onGlobalError);
};

export { getCategories, getProductByCategory };
