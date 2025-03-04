import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';
import { IProduct } from './model/Product';
import { IOpenProduct } from './model/OpenProduct';
import { IStockedProduct } from './model/StockedProduct';

axios.defaults.baseURL = "http://localhost:5076";

const responseBody = <T,>(response: AxiosResponse<T>) => {
	if (!response || !response.data) {
		return null;
	}
	return response.data;
};
const requests = {
	get: (url: string, config?: AxiosRequestConfig) => axios.get(url, config).then(responseBody),
	post: (url: string, body: any, config?: AxiosRequestConfig) => axios.post(url, body, config).then(responseBody),
	put: (url: string, body: any) => {
		return axios.put(url, body).then(responseBody);
	},
	delete: (url: string, body?: any) => axios.delete(url, body).then(responseBody),
};

export const ProductApi = {
	all: (): Promise<IProduct[]> => {
		return requests.get(`/Product/`);
	},
    create: (product: IProduct) => {
		return requests.post('/Product', product);
    },
    delete: (id: string) => {
        return requests.delete(`/Product/${id}`)
    }
}

export const OpenProductApi = {
	all: (): Promise<IOpenProduct[]> => {
		return requests.get(`/OpenProduct/`);
	},
    create: (product: IOpenProduct) => {
		return requests.post('/OpenProduct', product);
    },
    delete: (id: string) => {
        return requests.delete(`/OpenProduct/${id}`)
    }
}

export const StockedProductApi = {
	all: (): Promise<IStockedProduct[]> => {
		return requests.get(`/StockedProduct/`);
	},
    create: (product: IStockedProduct) => {
		return requests.post('/StockedProduct', product);
    },
    delete: (id: string) => {
        return requests.delete(`/StockedProduct/${id}`)
    }
}
