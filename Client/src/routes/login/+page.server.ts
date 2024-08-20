import { error, redirect, type Actions, type Cookies } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import { expoIn } from 'svelte/easing';
import { environment } from '../../environments/environment.dev';

export const load = (async () => {
    return {};
}) satisfies PageServerLoad;

export const actions: Actions = {
    login: async ({cookies, request}) => {
        const formData = Object.fromEntries(await request.formData());
        
        if(!formData.email || !formData.password) {
            return {
                data: formData,
                error: 'Missing email or password'
            };
        }

        const {email, password, remember} = formData as {email: string, password: string, remember: string}

        const error = await loginUser(email, password, remember, cookies);

        if(error) {
            let errorMsg = 'Username password is incorrect'
            if(error != 'Unauthorized')
                errorMsg = error;

            return {
                data: formData,
                error: errorMsg
            };
        }

        throw redirect(302, '/');
    }
}

async function loginUser(email: string, password: string, remember: string, cookies: Cookies) : Promise<string> {
    let age = 60*60*2;
    let res = '';
    if(remember != undefined)
        age = 60*60*24*365;

    await fetch(`${environment.apiUrl}/login?useCookies=true`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email, password})
    }).then(data => {
        if(data.status > 299) {
            return data.statusText;;
        }
        const setCookie = data.headers.getSetCookie()[0];
        cookies.set(
            'auth', setCookie.substring(setCookie.indexOf('=')+1, setCookie.indexOf(';')),
            {
                path: '/',
                maxAge: age,
                httpOnly: false,
            },
        )
    }).catch(error => {
        console.log(error);
        res = error;
    });

    return res;
}