import { UserManager } from "oidc-client";

const config = {
  authority: "https://localhost:5001",
  client_id: "auth-poc",
  redirect_uri: "http://localhost:5050/callback",
  response_type: "code",
  scope: "openid profile api1",
  post_logout_redirect_uri: "http://localhost:5050",
};

const userManager = new UserManager(config);


export { userManager };