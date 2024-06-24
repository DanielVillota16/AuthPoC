import { useState, useEffect } from 'react';
import { userManager } from './authService';
import './App.css';

function App() {

  // const handleLogin = () => {
  //   login("user", "password")
  //     .then(result => console.log(result))
  //     .catch((error) => console.error(error));
  // };

  const [user, setUser] = useState(null);

  useEffect(() => {
    async function checkAuthStatus() {
      const user = await userManager.getUser();
      setUser(user);
    }
    checkAuthStatus();
  }, []);

  const handleLoginOIDC = () => {
    userManager.signinRedirect().catch(err => console.error(err));
  }

  const handleLogoutOIDC = () => {
    userManager.signoutRedirect().catch(err => console.error(err));
  }

  const showUserInfo = () => {
    userManager.getUser().then(info => console.log(info));
  }

  const fetchApi = async () => {
    const headers = {
      Authorization: `Bearer ${user.access_token}`
    };
    const response = await fetch("https://localhost:7050/WeatherForecast", { headers });
    const json = await response.json();
    console.log(json);
  }

  return (
    <div>
      {
        !user
          ? <button onClick={handleLoginOIDC}>Log in</button>
          : (
            <>
              <p>Welcome, {user.profile.name}!</p>
              <button onClick={showUserInfo}>Show things</button>
              <button onClick={fetchApi}>Fetch api</button>
              <button onClick={handleLogoutOIDC}>Log out</button>
            </>
          )
      }
    </div>
  );
};

export default App;
