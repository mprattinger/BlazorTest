
var B2CService = function () {
    msalConfig = {
        auth: {
            clientId: '074e8975-c9c9-4e86-8688-00f4801a2279'
        }
    };
    tokenRequest = {
        scopes: ["user.read"]
    };

    var msalInstance = new Msal.UserAgentApplication(this.msalConfig);

    return {
        login: function (dotnetHelper) {
            msalInstance.loginPopup(this.tokenRequest).then((id_token) => {
                //login success
                console.log("signed in sucessfully");
                console.log(id_token);
                msalInstance.acquireTokenSilent(this.tokenRequest).then((resp) => {
                    //var data = {};
                    //data.id_token = id_token;
                    //data.auth_resp = resp;
                    var strData = JSON.stringify(resp);
                    //return strData;
                    dotnetHelper.invokeMethodAsync('HandleLoginSuccess', strData);
                }).catch((error) => {
                    if (err.name === "InteractionRequiredAuthError") {
                        msalInstance.acquireTokenPopup(loginRequest.scopes).then((resp) => {
                            //DotNet.invokeMethodAsync("BlazorTest", "HandleLoginSuccess")
                            //var data = {};
                            //data.id_token = id_token;
                            //data.auth_resp = resp;
                            var strData = JSON.stringify(resp);
                            //return strData;
                            dotnetHelper.invokeMethodAsync('HandleLoginSuccess', strData);
                        }).catch(function (error) {
                            // Acquire token interactive failure
                            console.log(error);
                            //rej(error);
                        });
                    }
                    console.log(error);
                });
                //res(id_token);
            }).catch((error) => {
                //login failure
                console.log(error);
                //rej(error);
            });
        },
        logout: function () {
            msalInstance.logout();
        },
        getToken: function (dotnetHelper) {
            msalInstance.acquireTokenSilent(this.tokenRequest).then((resp) => {
                //var data = {};
                //data.id_token = id_token;
                //data.auth_resp = resp;
                var strData = JSON.stringify(resp);
                //dotnetHelper.invokeMethodAsync('HandleLoginSuccess', strData);
                return strData;
            }).catch((error) => {
                if (error.name === "InteractionRequiredAuthError") {
                    msalInstance.acquireTokenPopup(this.tokenRequest).then((resp) => {
                        //DotNet.invokeMethodAsync("BlazorTest", "HandleLoginSuccess")
                        //var data = {};
                        //data.id_token = id_token;
                        //data.auth_resp = resp;
                        var strData = JSON.stringify(resp);
                        //dotnetHelper.invokeMethodAsync('HandleLoginSuccess', strData);
                        return strData;
                    }).catch(function (error) {
                        // Acquire token interactive failure
                        console.log(error);
                        //rej(error);
                    });
                } else if (error.name === "ClientAuthError") {
                    return this.B2CService.login();
                }
                console.log(error);
            });
        }
    };
}();

//class Authentication {
//    msalConfig = {
//        auth: {
//            clientId: '074e8975-c9c9-4e86-8688-00f4801a2279'
//        }
//    };
//    tokenRequest = {
//		scopes: ["user.read"]
//	};

//    constructor() {

//        this.msalInstance  = new Msal.UserAgentApplication(this.msalConfig);
//    }

//    sign_in() {
//        var that = this;
//        return new Promise((res, rej) => {
//            that.msalInstance.loginPopup(this.tokenRequest).then((id_token) => {
//                //login success
//                console.log("signed in sucessfully");
//                console.log(id_token);
//                that.msalInstance.acquireTokenSilent(this.tokenRequest).then((resp)=>{
//                    res(response.accessToken);
//                }).catch((error)=>{
//                    if (err.name === "InteractionRequiredAuthError") {
//                        that.msalInstance .acquireTokenPopup(loginRequest.scopes).then((response) => {
//                            res(response.accessToken);
//                        }).catch(function (error) {
//                            // Acquire token interactive failure
//                            console.log(error);
//                            rej(error);
//                        });
//                    }
//                    console.log(error);
//                })
//                res(id_token);
//            }).catch((error) => {
//                //login failure
//                console.log(error);
//                rej(error);
//            });
//        });
//    }

//    sign_out() {
//        that.msalInstance.logout();
//    }
//}

