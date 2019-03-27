
import HttpService from './http-service'

export default class RestApiService {
    
    fullPath = ()=>{ return this.host+this.path; }

    constructor(host, path, httpService){
        this.host = host; // "https://localhost:5001/api";
        this.path = path;
        this.httpService = httpService ? httpService: new HttpService();
    }

    getAll = async () => {
        return await this.httpService.getJson(this.fullPath());
    }

    get = async (id) => {
        return await this.httpService.getJson(this.fullPath()+"/"+id);
    }

    getDefault = async() => {
        return await this.httpService.getJson(this.fullPath()+"/default");
    }

    create = async (entity)=> {
        return await this.httpService.postJson(this.fullPath(), entity);
    }

    update = async (id, entity) => {
        return await this.httpService.putJson(this.fullPath()+"/"+id, entity);
    }

    delete = async (id) => {
        return await this.httpService.deleteJson(this.fullPath()+"/"+ id);
    }
}