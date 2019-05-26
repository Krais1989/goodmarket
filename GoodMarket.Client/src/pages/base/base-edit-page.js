import React from 'react';
import InputForm from '../../components/input-form/input-form';
import { LoadIndicator } from '../../components/loading';
import { ObjUtils } from '../../utils';

class BaseEditPage extends React.Component {

    api = this.props.injects.gmapi.users;

    state = {
        data: undefined,
        isLoading: false
    }

    /** changeArray - массив с описанием изменения в иерархии */
    onChange = (changeArray) => {
        this.setState((state)=>{
            return {data: ObjUtils.getWithChanges(state.data, changeArray)};
        });
    }

    submit = ()=>{
        this.api.update(this.state.data.id, this.state.data)
            .then((result)=>{
            })
            .catch((error)=>{
                return Error(error);
            });
    }

    componentDidMount() {
        const id = this.props.match.params.id;

        this.setState({isLoading:true});

        this.api.get(id)
            .then((json)=>{
                this.setState({data: json, isLoading:false});
            });
    }

    render() {
        console.log("User edit page");

        const {data, isLoading} = this.state;

        if (isLoading)
            return <LoadIndicator/>

        return (
                <div className="d-flex bg-light flex-column flex-fill">
                    <h2 className="m-2">Edit Page</h2>
                    <InputForm 
                        className="table table-dark" 
                        data = {data}
                        onChange={this.onChange}
                    />
                    <div className="d-flex flex-row-reverse">
                        <button className="btn btn-warning btn-lg" onClick={this.submit}>Save <i className="far fa-save"></i></button>
                    </div>
                </div>

        );
    }
}

export default BaseEditPage;