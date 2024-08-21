import { environment } from '../../environments/environment.dev';
import type { Expense } from '../../models/expense';
import type { Gain } from '../../models/gain';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({cookies}) => {
    const authToken = `.AspNetCore.Identity.Application=${cookies.get('auth')};`;
    const moneyResponse = await fetch(`${environment.apiUrl}/api/Money`, {
        method: 'GET',
        headers: {
            Cookie: authToken
        },
        credentials: 'include'
      });
    let balance = -1;
    if(moneyResponse.ok) {
        balance = await moneyResponse.json();
    }

    const gainsResponse = await fetch(`${environment.apiUrl}/api/Money/Gains`, {
        method: 'GET',
        headers: {
            Cookie: authToken
        },
        credentials: 'include'
      });
    let gains: Gain[] = [];
    if(gainsResponse.ok) {
        gains = await gainsResponse.json();
    }

    const expensesResponse = await fetch(`${environment.apiUrl}/api/Money/Expenses`, {
        method: 'GET',
        headers: {
            Cookie: authToken
        },
        credentials: 'include'
      });
    let expenses: Expense[] = [];
    if(expensesResponse.ok) {
        expenses = await expensesResponse.json();
    }

    return {
        balance,
        gains, 
        expenses
    };
};