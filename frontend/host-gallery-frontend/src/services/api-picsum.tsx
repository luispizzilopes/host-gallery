import axios from "axios";

const ApiPicsum = axios.create({
    baseURL: "https://picsum.photos",
    timeout: 5000, 
});

export default ApiPicsum; 