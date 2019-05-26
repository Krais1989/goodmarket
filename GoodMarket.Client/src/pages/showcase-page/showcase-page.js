import React from 'react';
import { withGmInjection } from '../../context';
import { LoadIndicator } from '../../components/loading';
import ProductCard from '../../components/product-card';

class ShowcasePage extends React.Component {

    gmapi = this.props.injects.gmapi;

    state = {
        data: null,
        isLoading: false
    }

    componentDidMount(){
        this.setState({isLoading:false});
        this.gmapi.products.getAll()
            .then((prods)=>{
                this.setState({data: prods, isLoading:false});
            })
            .catch(error=>{
                this.setState({data: null, isLoading:false});
            });
    }

    render(){

        const {data, isLoading} = this.state;

        if (isLoading)
            return <LoadIndicator/>;

        if (data ===null || data===undefined){
            return (<div></div>)
        }

        const jsxCards = data.map((d, i)=>{
            return (<ProductCard title={d.title} btnTitle="Buy" text={"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "}
                        key={i} onBtnClick={()=>{console.log("Buy", d.id)}}  />)
        });

        return (
            <div className="d-flex bg-light flex-column p-2">
                <h2>Showcase Page</h2>
                <div className="d-flex align-content-start justify-content-center flex-wrap">
                    {jsxCards}
                </div>
            </div>
        
        );
    }
}

export default withGmInjection(ShowcasePage);