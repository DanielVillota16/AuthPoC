const tokenEndpoint = "https://localhost:7021/connect/token";

const login = async (username, password) => {
  const payload = new URLSearchParams();
  payload.append("username", username);
  payload.append("password", password);
  payload.append("grant_type", "password");
  payload.append("client_id", "auth-poc");
  payload.append("scope", "openid profile myApi.write myApi.read");
  payload.append("redirect_uri", "http://localhost:5050/callback");

  console.log(payload);
  const headers = { "Content-Type": "application/x-www-form-urlencoded" };

  const response = await fetch(tokenEndpoint, { headers, body: payload, method: "post" });
  const json = await response.json();
  return json;
};

export { login };