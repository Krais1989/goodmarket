import React from 'react';
import { StrUtils } from '../../utils';

/** Форма отображения */
/** TODO: InputForm вызывается рекурсивно */
class InputForm extends React.Component {

    render(){
        const {data, dataProps, onChange, ...others} = this.props;
    
        if ( data===undefined || data===null)
        {
            return (
                <table {...others}>
                    <tbody><tr><td>NO DATA</td></tr></tbody>
                </table>
                );
        }
        
        /** Колонки по умолчанию. Если не определён columns, взять поля из первого объекта - tableData[0] */
        let mutDataProps = dataProps;
        if (mutDataProps ===null || mutDataProps===undefined )
        {
            const colObjFromDataObj = (obj) => {
                var objs = Object.keys(obj).map(k => ({[k]: StrUtils.capitalize(k)}));
                if (objs.length ===0) return {};
                return Object.assign(...objs);
            } 
            mutDataProps = colObjFromDataObj(data);
        }

        const jsxFieldFunc = (obj, fieldName) => {
            const fieldValue = obj[fieldName];
            if (typeof fieldValue ==="object")
                return (<td key={"1"}>
                            <InputForm data={fieldValue} dataProps={null} 
                                    className={this.props.className} 
                                    onChange={(arr)=>onChange([fieldName, ...arr])}
                                    /> 
                        </td>);
            else
                return (<td key={"1"}>
                            <input type="text" className="form-control" 
                                value={fieldValue} 
                                onChange={(evt)=>onChange([fieldName, evt.target.value])} />
                        </td>);
        }
    
        const jsxFieldsArray = Object.keys(mutDataProps).map((fieldName, fieldIndex) => {
            const headerField = <th key={"0"}>{mutDataProps[fieldName]}</th>;
            const valueFields = jsxFieldFunc(data, fieldName);
            return (<tr key={fieldIndex.toString()}>{[headerField, valueFields]}</tr>);
        });
    
        return (
                <table {...others}>
                    <tbody>
                        {jsxFieldsArray}
                    </tbody>
                </table>);
    }
    
}

export default InputForm;