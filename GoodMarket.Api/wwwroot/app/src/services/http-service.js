

export default class HttpService {

    constructor(defaultHeaders = {}){
        this.defaultHeaders = {
            "Content-Type": "application/json"
        };
        this.defaultHeaders = {...this.defaultHeaders, ...defaultHeaders};
    }

    baseQuery = async (url, method="GET", body, addHeaders={}) => {
        const headers = {...this.defaultHeaders, ...addHeaders};
        console.log(`HttpService ${method} ${url}\n headers:${JSON.stringify(headers)} data:${body}`);
        const result = await fetch(url, {method, body, headers});
        console.log(result);
        return result;
    }

    baseJsonQuery = async (url, method="GET", body=null, addHeaders={}) => {
        const response = await this.baseQuery(url, method, body!==null ? JSON.stringify(body) : null, addHeaders);
        if (response.status !== 200) 
        {
            return Error("\tHttpService Error message:\n\t", response.statusText);
        }
        const json = await response.json();
        console.log("\tHttpService Body:\n\t", json);
        return json;
    }

    getJson = async (url, headers={}) => {
        return await this.baseJsonQuery(url, "GET", null, headers);
    }

    postJson = async (url, dataObj, headers={}) => {
        return await this.baseJsonQuery(url, "POST", dataObj, headers);;
    }

    putJson = async (url, dataObj, headers={}) => {
        return await this.baseJsonQuery(url, "PUT", dataObj, headers);;
    }

    deleteJson = async (url, headers={}) => {
        return await this.baseQuery(url, "DELETE", null, headers);;
    }
}