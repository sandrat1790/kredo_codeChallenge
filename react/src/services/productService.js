import axios from "axios";
import {
  onGlobalSuccess,
  onGlobalError,
} from "../services/serviceHelper";

const api = "https://localhost:50001/api/product";

const getProductById = (id) => {
  const config = {
    method: "GET",
    url: `${api}/${id}`,
    withCredentials: true,
    crossdomain: true,
    headers: { "Content-Type": "application/json" },
  };
  return axios(config).then(onGlobalSuccess).catch(onGlobalError);
};

const getAllProduct = () => {
  const config = {
    method: "GET",
    url: api,
    withCredentials: true,
    crossdomain: true,
    headers: { "Content-Type": "application/json" },
  };
  return axios(config).then(onGlobalSuccess).catch(onGlobalError);
};



export {
  getProductById,
  getAllProduct,
  
};
