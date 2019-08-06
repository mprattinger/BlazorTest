
class Authentication {
    msalConfig = {
        auth: {
            clientId: '074e8975-c9c9-4e86-8688-00f4801a2279'
        }
    };
    tokenRequest = {
		scopes: ["user.read"]
	};

    constructor() {

        this.msalInstance  = new Msal.UserAgentApplication(this.msalConfig);
    }

    sign_in() {
        var that = this;
        return new Promise((res, rej) => {
            that.msalInstance.loginPopup(this.tokenRequest).then((id_token) => {
                //login success
                console.log("signed in sucessfully");
                console.log(id_token);
                that.msalInstance.acquireTokenSilent(this.tokenRequest).then((resp)=>{
                    res(response.accessToken);
                }).catch((error)=>{
                    if (err.name === "InteractionRequiredAuthError") {
                        that.msalInstance .acquireTokenPopup(loginRequest.scopes).then((response) => {
                            res(response.accessToken);
                        }).catch(function (error) {
                            // Acquire token interactive failure
                            console.log(error);
                            rej(error);
                        });
                    }
                    console.log(error);
                })
                res(id_token);
            }).catch((error) => {
                //login failure
                console.log(error);
                rej(error);
            });
        });
    }

    sign_out() {
        that.msalInstance.logout();
    }
}

