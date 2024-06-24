import { login } from './authService';
import './App.css';

function App() {

  const handleLogin = () => {
    login("user", "password")
      .then(result => console.log(result))
      .catch((error) => console.error(error));
  };

  return (
    <div>
      <button onClick={handleLogin}>Log in</button>
    </div>
  );
};

export default App;
