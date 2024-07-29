import axios from 'axios';

const API_URL = 'http://localhost:5205//api/Claims';

const getClaims = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

const getClaimById = async (id) => {
  const response = await axios.get(`${API_URL}/${id}`);
  return response.data;
};

const createClaim = async (claim) => {
  const response = await axios.post(API_URL, claim);
  return response.data;
};

const updateClaim = async (id, claim) => {
  const response = await axios.put(`${API_URL}/${id}`, claim);
  return response.data;
};

const deleteClaim = async (id) => {
  const response = await axios.delete(`${API_URL}/${id}`);
  return response.data;
};

export { getClaims, getClaimById, createClaim, updateClaim, deleteClaim };
