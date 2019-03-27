
class RedirectService {

    constructor(history){
        this.history = history;
    }
    
    back = () => {
        this.history.goBack();
    }
    forward = () => {
        this.history.goForward();
    }
    go = (path) => {
        this.history.push(path);
    }
}

export default RedirectService;