import React from 'react';
import InputForm from '../../components/input-form/input-form';
import { LoadIndicator } from '../../components/loading';
import { ObjUtils } from '../../utils';

class BaseCreatePage extends React.Component {

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
        this.api.create(this.state.data)
            .then((result)=>{
                this.props.history.push("/");
            })
            .catch((error)=>{
                return Error(error);
            });
    }

    componentDidMount(){
        this.setState({ isLoading: true});
        this.api.getDefault()
            .then((entity)=>{
                this.setState({data: entity, isLoading: false});
            })
            .catch(error=>{
                this.setState({data: null, isLoading: false});
            });
    }

    render() {
        console.log("User edit page");

        const {data, isLoading} = this.state;

        if (isLoading)
            return <LoadIndicator/>

        return (
                <div className="gm-edit-page d-flex w-100 flex-column mt-5">
                    <h2 className="m-2">Create Page</h2>
                    <InputForm 
                        className="table table-dark" 
                        data = {data}
                        onChange={this.onChange}
                    />
                    <div className="align-self-end w-100 bg-dark">
                        <button className="btn btn-warning" onClick={this.submit}>Save</button>
                    </div>
                </div>

        );
    }
}

export default BaseCreatePage;