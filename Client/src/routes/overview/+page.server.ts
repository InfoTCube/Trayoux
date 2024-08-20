import { environment } from '../../environments/environment.dev';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({cookies}) => {
    const authToken = `.AspNetCore.Identity.Application=${cookies.get('auth')};`;
    const response = await fetch(`${environment.apiUrl}/api/Money`, {
        method: 'GET',
        headers: {
            Cookie: authToken
        },
        credentials: 'include'
      });
    let balance = -1;

    console.log(response.status);

    if(response.ok) {
        balance = await response.json();
        return {
            balance
        };
    }
};