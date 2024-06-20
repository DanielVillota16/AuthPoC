import { UserManager, UserManagerSettings } from 'oidc-client';

const userManagerConfig = {
    authority: "https://localhost:7021",
    client_id: "auth-poc",
    redirect_uri: "http://localhost:5050/",
    response_type: "id_token token",
    scope:"openid profile myApi.write myApi.read",
    post_logout_redirect_uri : "http://localhost:5050/",
};

export const userManager = new UserManager(userManagerConfig);

export function login() {
    return userManager.signinRedirect();
}

export function logout() {
    return userManager.signoutRedirect();
}

export function getUser() {
    return userManager.getUser();
}