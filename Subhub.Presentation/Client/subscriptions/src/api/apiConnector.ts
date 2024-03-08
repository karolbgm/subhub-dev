import axios, { AxiosResponse } from "axios";
import { SubDto } from "../models/subDto";
import { GetSubsResponse } from "../models/getSubsResponse";
import {API_BASE_URL} from "../../config.ts"
import { GetSubByIdResponse } from "../models/getSubByIdResponse";


const apiConnector = {
    
    getSubscriptions: async (): Promise<SubDto[]> => {
        try {
            const response: AxiosResponse<GetSubsResponse> = await axios.get(`${API_BASE_URL}/subscriptions`);
            const subscriptions = response.data.subscriptionsDtos.map(subscription => ({
                ...subscription,
                paymentDate: subscription.paymentDate?.slice(0,10) ?? ""
            }));
            // console.log(response.data.subscriptionsDtos)
            // return;
            return subscriptions;
        } catch (error) {
            console.log('No movies found:', error);
            throw error;
        }
    },

    createSubscription: async (subscription: SubDto): Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/subscriptions`, subscription);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    editSubscription: async (subscription: SubDto) : Promise<void>  => {
        try {
            await axios.put<number>(`${API_BASE_URL}/subscriptions/${subscription.id}`, subscription);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    deleteSubscription: async (subscriptionId: number): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/subscriptions/${subscriptionId}`);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    getSubscriptionById: async (subscriptionId: string) : Promise<SubDto | undefined> => {
        
        try {
            const response = await axios.get<GetSubByIdResponse>(`${API_BASE_URL}/subscriptions/${subscriptionId}`);
            return response.data.subscriptionDto;
        } catch (error) {
            console.log(error);
            throw error;
        }
    }
}


export default apiConnector;


