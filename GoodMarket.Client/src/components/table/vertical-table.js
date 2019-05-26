import React from 'react';
import { StrUtils } from '../../utils';

/** Базовый компонент для отображения свойств объекта в табличном виде */
const VerticalTable = (props) => {

    let {
        columns, 
        data,
        ...others
    } = props;

    if ( data===undefined || data===null || data.length===0 || data[0]===null)
    {
        return (
            <table {...others}>
                <tbody><tr><td>NO DATA</td></tr></tbody>
            </table>
            );
    }
    
    /** Колонки по умолчанию. Если не определён columns, взять поля из первого объекта - tableData[0] */
    if (columns ===null || columns===undefined )
    {
        
        const colObjFromDataObj = (obj) =>{
            const colPairs = Object.keys(obj).map(k => ({[k]: StrUtils.capitalize(k)}));
            if (colPairs.length===0) return {};
            return Object.assign(...colPairs);
        } 
        columns = colObjFromDataObj(data[0]);
    }

    const columnsKeys = Object.keys(columns);

    const jsxFieldFunc = (obj, objIndex, objFieldName)=>{
        const fieldValue = obj[objFieldName];
        if (typeof fieldValue ==="object")
            return <td key={(objIndex+1).toString()}><VerticalTable data={[fieldValue]} /></td>;
        else
            return <td key={(objIndex+1).toString()}>{fieldValue}</td>;
    }

    const jsxFieldsArray = columnsKeys.map((objFieldName, objFieldIndex) => {
        const headerField = <th key={"0"}>{columns[objFieldName]}</th>;
        const valueFields = data.map((obj, objIndex)=> jsxFieldFunc(obj, objIndex, objFieldName));
        return (<tr key={objFieldIndex.toString()}>{[headerField, ...valueFields]}</tr>);
    });

    return (
            <table {...others}>
                <tbody>
                    {jsxFieldsArray}
                </tbody>
            </table>);
}

export default VerticalTable;