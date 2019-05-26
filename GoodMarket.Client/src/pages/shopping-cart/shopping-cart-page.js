import React from 'react';
import { LoadIndicator } from '../../components/loading';
import { ErrorIndicator } from '../../components/error';
import { withGmInjection } from '../../context';
//import { getWithChanges } from '../../utils/object-utils';

class ShoppingCartPage extends React.Component
{
    gmapi = this.props.injects.gmapi;
    state = {
        isLoading: false,
        data: null,
        products: null
    }

    setQuantity = (prodId, quantity) =>{
        console.log(prodId, quantity);
        
        // this.setState((state)=>{
        //     let newData = getWithChanges(state.data);
        //     const cart = newData.cart;
        //     const recs = cart.records;
            
        //     if (recs.hasOwnProperty(prodId)){
        //         recs[prodId] = quantity;
        //         return {data: newData};
        //     }
        //     else
        //         return state;
        // });
    }

    removeRecord = (prodId) =>{
        // this.setState((state)=>{
        //     let newData = getWithChanges(state.data);
        //     const cart = newData.cart;
        //     const recs = cart.records;
            
        //     if (recs.hasOwnProperty(prodId)){
        //         delete newData.records.prodId;
        //         return {data: newData};
        //     }
        //     else
        //         return state;
        // });
    }

    componentDidMount(){
        this.setState({isLoading: true});
        this.gmapi.customers.get(1) // TODO: взять текущего залогиненного юзера
            .then(data=>{
                console.log(data);
                this.setState({data: data, isLoading: false});
            })
            .catch(error=>{
                console.log(error);
                this.setState({data: null, isLoading: false});
            });
    }

    render(){

        const {isLoading, data} = this.state;

        if (isLoading)
            return <LoadIndicator/>

        if (data===null || data===undefined)
            return <ErrorIndicator />

        const cart = data.cart;
        const recs = cart.records;
        const jsxRows = Object.keys(recs).map((prodId)=>{
            return (
                <tr key={prodId}>
                    <td>Product {prodId}</td>
                    <td>Config</td>
                    <td>
                        <input onChange={(ev)=>this.setQuantity(prodId, ev.target.value)} value={recs[prodId]}></input>
                        <button type="button" className="btn btn-sm btn-danger ml-1" onClick={()=>{}}> Remove <i className="fas fa-times"></i></button>  
                    </td>
                    <td>$$$</td>
                </tr>
            );
        });

        return (
            <table className="table table-stripped">
                <thead className="thead-light">
                    <tr>
                    <th scope="col">Product</th>
                    <th scope="col">Configuration</th>
                    <th scope="col">Quantity</th>
                    <th scope="col">Price</th>
                    </tr>
                </thead>
                <tbody>
                    {jsxRows}
                </tbody>
            </table>
        );
    }
}

export default withGmInjection(ShoppingCartPage);