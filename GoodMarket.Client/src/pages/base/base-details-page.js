import React from 'react';
import { VerticalTable } from '../../components/table';
import { LoadIndicator } from '../../components/loading';

class BaseDetailsPage extends React.Component {

    api = this.props.injects.gmapi.users;

    state = {
        data: null,
        isLoading: false
    }

    componentDidMount(){
        const id = this.props.match.params.id;
        this.setState({isLoading:true});
        this.api.get(id)
            .then((data)=>{
                this.setState({data: data, isLoading:false});
            })
            .catch(error=>{
                this.setState({isLoading:false});
            });
    }

    render() {

        console.log("User details page");

        const {data, isLoading} = this.state;

        if (isLoading)
            return <LoadIndicator/>;

        

        return (
            <div className="d-flex bg-light flex-column flex-fill">
                <h2 className="m-2">Details Page</h2>
                <VerticalTable 
                    data = {[data]}
                    className="table table-dark"
                />
            </div>);
    }
}

export default BaseDetailsPage;