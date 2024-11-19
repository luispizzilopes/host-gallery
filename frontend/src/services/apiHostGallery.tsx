import axios, { AxiosInstance } from 'axios';

const apiHostGallery : AxiosInstance = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_BASE_URL || 'https://localhost:7213/api',
  withCredentials: true,
});

apiHostGallery.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

apiHostGallery.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401 || error.response?.status === 403) {
    }
    return Promise.reject(error);
  }
);

export default apiHostGallery;
