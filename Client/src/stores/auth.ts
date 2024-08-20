export function isAuth(): boolean {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; auth=`);
    if (parts.length === 2) return true || false;
    return false;
}