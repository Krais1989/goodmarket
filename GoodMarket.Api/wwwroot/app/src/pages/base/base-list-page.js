import React from 'react';
import {Table} from '../../components/table';
import { RedirectService } from '../../services';
import Paginator from '../../components/paginator';
import { LoadIndicator } from '../../components/loading';

 class BaseListPage extends React.Component {

    state = {
        data: null,
        isLoading: false
    }

    redirect = new RedirectService(this.props.history);
    api = this.props.injects.gmapi.users;
    
    onCreateRecord = ()=>{
        this.props.history.push(`create`);
    }

    onDetailRecord = (id) => {
        console.log("OnDetailRecord:", id);
        this.props.history.push(`${id}`);
    }

    onEditRecord = (id) => {
        console.log("onEditRecord:", id);
        this.props.history.push(`edit/${id}`);
    }

    onDeleteRecord = (id) => {
        console.log("onDeleteRecord:", id);

        if (!window.confirm('Delete record:'+id))
            return;

        this.api.delete(id)
            .then((response)=>{
                console.log("Record deleted:", id);
                this.setState((state)=>{
                    const newData = [...state.data].filter(el=>el.id!==id);
                    console.log(newData);
                    return {data: newData};
                });
            })
            .catch((error)=>{
                return Error(error);
            });
    }

    componentDidMount(){

        this.setState({isLoading: true});
        this.api.getAll()
            .then((jsonArr)=>{
                this.setState({data: jsonArr, isLoading: false});
            })
            .catch(error=>{
                this.setState({isLoading: false});
            });
    }

    render() {

        console.log("Users list page");

        const {data, isLoading} = this.state;

        if (isLoading)
            return <LoadIndicator/>

        const jsxTable = (<Table 
            className="table table-dark"
            data={data}
            onDetailRecord={this.onDetailRecord} 
            onEditRecord={this.onEditRecord} 
            onDeleteRecord={this.onDeleteRecord} 
            allowDetail
            allowEdit
            allowDelete
            />);

        return (<div className="d-flex flex-column flex-fill bg-light">
                    <div className="d-flex">
                        <h2 className="mr-auto m-2">List Page</h2>
                        <button className="btn btn-primary btn-lg"  onClick={this.onCreateRecord}>Create <i className="fas fa-plus"></i></button>
                    </div>
                    
                    {jsxTable}
                    {
                         (data && data.length>0)? (<div className="d-flex column justify-content-center"><Paginator/></div>):""
                    }
                    
                </div>);
    }
}


export default BaseListPage;