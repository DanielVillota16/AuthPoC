import { useEffect } from 'react';
import { userManager } from './authService';
import { useNavigate } from 'react-router-dom';

const Callback = () => {
  const navigate = useNavigate();

  useEffect(() => {
    async function handleCallback() {
      await userManager.signinRedirectCallback();
      navigate('/');
    }
    handleCallback();
  }, []);

  return null;
}

export default Callback;