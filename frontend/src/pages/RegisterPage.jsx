import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { register } from '../services/api';
function RegisterPage() {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [error, setError] = useState([]);
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    async function handleSubmit(e) {
        e.preventDefault();
        setError([]);

        if (password !== confirmPassword) {
            setError(['Passwords do not match.']);
            return;
        }

        setLoading(true);

        try {
            await register({ firstName, lastName, email, password });
            navigate('/');
        } catch (err) {
            if (err.status === 400 && err.errors) {
                setError(Object.values(err.errors).flat());
            } else if (err.status === 409) {
                setError([err.message]);
            } else {
                setError(['Something went wrong. Please try again']);
            }
        } finally {
            setLoading(false);
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <h1>Create an account</h1>

            <p>
                Already have an account? <Link to="/login">Log in</Link>
            </p>

            <label htmlFor="firstName">First name</label>
            <input
                id="firstName"
                type="text"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
            />

            <label htmlFor="lastName">Last name</label>
            <input
                id="lastName"
                type="text"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
            />

            <label htmlFor="email">Email</label>
            <input
                id="email"
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />

            <label htmlFor="password">Password</label>
            <input
                id="password"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />

            <label htmlFor="confirmPassword">Confirm Password</label>
            <input
                id="confirmPassword"
                type="password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
            />

            {error.length > 0 && (
                <ul role="alert">
                    {error.map((msg, i) => (
                        <li key={i}>{msg}</li>
                    ))}
                </ul>
            )}

            <button type="submit" disabled={loading}>
                {loading ? 'Creating account...' : 'Create account'}
            </button>

        </form>
    );
}

export default RegisterPage;