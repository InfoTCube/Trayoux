import type { Handle } from '@sveltejs/kit';

export const handle: Handle = async ({ event, resolve }) => {
    const { request } = event;
    const cookies = request.headers.get('cookie') || '';
    const authenticated = cookies.includes('auth');

    const authorizedRoutes = ['/abc'];
    const unauthorizedRoutes = ['/login', '/signup'];

    if (authorizedRoutes.includes(event.url.pathname) && !authenticated) {
        return new Response(null, { status: 302, headers: { Location: '/login' } });
    } else if(unauthorizedRoutes.includes(event.url.pathname) && authenticated) {
        return new Response(null, { status: 302, headers: { Location: '/' } });
    }

    return resolve(event);
};