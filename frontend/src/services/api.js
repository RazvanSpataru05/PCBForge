async function request(url, options = {}) {
    const response = await fetch(url, {
        credentials: 'include',
        headers: { 'Content-Type': 'application/json' },
        ...options,
    });

    if (response.status === 204) return null;

    const data = await response.json().catch(() => null);

    if (!response.ok) {
        const error = new Error(data?.message || 'Request failed');
        error.status = response.status;
        error.errors = data?.errors || null;
        throw error;
    }

    return data;
}

export const register = (dto) =>
    request('/api/auth/register', { method: 'POST', body: JSON.stringify(dto) });

export const login = (dto) =>
    request('/api/auth/login', { method: 'POST', body: JSON.stringify(dto) });

export const logout = () =>
    request('/api/auth/logout', { method: 'POST' });

export const getMe = () =>
    request('/api/auth/me');