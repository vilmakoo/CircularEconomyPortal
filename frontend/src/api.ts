import axios from 'axios';

const API_URL = 'http://localhost:5232'; 

export interface WasteBin {
  id: number;
  address: string;
  emptyingSchedule: string;
  lastEmptiedAt: string;
  userId: number;
}

export interface User {
  id: number;
  name: string;
  email: string;
  phone: string;
}

export interface Feedback {
  message: string;
}

// helper to get waste bins
export const getWasteBins = async () => {
  const response = await axios.get<WasteBin[]>(`${API_URL}/wastebins`);
  return response.data;
};

// helper to get user details
export const getUser = async () => {
  const response = await axios.get<User>(`${API_URL}/users`);
  return response.data;
};

// helper to update user
export const updateUser = async (user: User) => {
  await axios.put(`${API_URL}/users`, user);
};

// helper to send feedback
export const sendFeedback = async (message: string) => {
  await axios.post(`${API_URL}/feedback`, { message });
};