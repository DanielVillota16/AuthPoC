import { useEffect, useState } from 'react';
import { login, logout, getUser } from './authService';
import reactLogo from './assets/react.svg';
import viteLogo from '/vite.svg';
import './App.css';

function App() {

  const [user, setUser] = useState(null);

  useEffect(() => {
    async function checkAuthStatus() {
      const user = await getUser();
      setUser(user);
    }
    checkAuthStatus();
  }, []);

  const handleLogin = () => {
    login().catch((error) => console.error(error));
  };

  const handleLogout = () => {
    logout().catch((error) => console.error(error));
  };

  return (
    <div>
      {!user? (
        <button onClick={handleLogin}>Log in</button>
      ) : (
        <>
          <p>Welcome, {user.profile.name}!</p>
          <button onClick={handleLogout}>Log out</button>
        </>
      )}
    </div>
  );
};

export default App;
