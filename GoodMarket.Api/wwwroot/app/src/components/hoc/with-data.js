import React from 'react';
import { LoadIndicator } from '../loading';
import { ErrorIndicator } from '../error';


/* HOC извлекающий данные и передающий обёрнотому компоненту */
/* Пока данные загружаются показывает загрузку */
/* По завершению загрузки отображает обёрнутый компонент */

/** Wrapped - оборачиваемый компонент (обёртыш) */
/** dataFunc - функция извлечения данных. Асинхронная - возвращает промис, Синхронная - возвращает объект с данными */
/** dataMutFunc - функция преобразования одного объекта данных другой. */
const withData = ( Wrapped ) => {
    return class extends React.Component {

        state = {
            data: null,
            isLoading: false,
            isError: false
        }

        componentDidMount() {
            const {dataFunc} = this.props;
            
            //console.log("WithData:", "componentDidMount()");

            let result = dataFunc();
            if (result instanceof Promise){
                this.setState({isLoading:true});
                console.log("WithData:", "async dataFunc()");
                result
                    .then(data=>{
                        this.setState({isLoading:false, data});
                    })
                    .catch(error=>{
                        this.setState({isLoading:false, data:null, isError:true});
                    });
            } else {
                //console.log("WithData:", "sync dataFunc()");
                this.setState({isLoading:false, data:result});
            }
        }

        render(){

            //console.log("WithData:", "render()");

            const {isLoading, isError, data} = this.state;

            if (isLoading)
                return <LoadIndicator/>;

            if (isError)
                return <ErrorIndicator/>;

            const {dataFunc, dataTransFunc = (data) => ({data: data}), ...others} = this.props;
            const mutData = dataTransFunc(data);
            const mutProps = {...others, ...mutData};
            return (
                <Wrapped {...mutProps} />
            );
        }
    }
}

export default withData;