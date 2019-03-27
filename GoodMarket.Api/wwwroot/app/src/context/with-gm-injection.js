import withInjection from "./with-injection";
import GmContext from "./gm-context";


const withGmInjection = (Wrapped)=>withInjection(Wrapped, GmContext.Consumer);

export default withGmInjection;