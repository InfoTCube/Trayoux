import { json, type Cookies, type RequestHandler } from '@sveltejs/kit';

export const POST: RequestHandler = async ({ cookies }) => {
    //const { cookies } = event;
    // Delete the specific cookie(s)
    cookies.delete('auth', { path: '/' });
    // Return a response to indicate the cookie was deleted
    //return new Response('Cookie deleted', { status: 200 });
    return json({ message: 'Cookie deleted' });
};