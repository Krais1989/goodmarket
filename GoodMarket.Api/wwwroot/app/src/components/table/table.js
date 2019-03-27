import React from 'react';
import './table.css';
import { StrUtils } from '../../utils';

import {GetFieldKey, GetRowKey} from './table-key-utils';


/** columnsData: {key:title, key:title} - . */
/** tableData: [{},{},{}] - массив отображаемых объектов */
const Table = (props) => {

    let { 
        idFunc = (row) => row.id,
        columns, 
        data, 
        allowDetail, allowEdit, allowDelete,
        onDetailRecord, onEditRecord, onDeleteRecord,
        ...others
    } = props;
    
    if ( data===undefined || data===null || data.length===0)
    {
        return (
            <table className="table table-dark">
                <tbody><tr><td>NO DATA</td></tr></tbody>
            </table>
            );
    }
    
    /** Колонки по умолчанию. Если не определён columns, взять поля из первого объекта - tableData[0] */
    if (columns ===null || columns===undefined)
    {
        const colObjFromDataObj = (obj) => Object.assign(...Object.keys(obj).map(k => ({[k]: StrUtils.capitalize(k)})));
        columns = colObjFromDataObj(data[0]);
    }

    const columnsKeys = Object.keys(columns);

    /* Header */
    const hrId = 0;
    let jsxColumns = columnsKeys.map((k, i) => <th key={GetFieldKey(hrId, i)}> {columns[k]} </th>);
    if (allowDetail)
        jsxColumns.push(<th key={GetFieldKey(hrId, jsxColumns.length + 1)}></th>);
    if (allowEdit)
        jsxColumns.push(<th key={GetFieldKey(hrId, jsxColumns.length + 2)}></th>);
    if (allowDelete)
        jsxColumns.push(<th key={GetFieldKey(hrId, jsxColumns.length + 3)}></th>);

    if (jsxColumns.length > 0)
        jsxColumns = <thead><tr>{jsxColumns}</tr></thead>;

    const filtTableData = data.map(d => (Object.assign(...columnsKeys.map(col=>({[col]: d[col]})))));
    
    let jsxRows = filtTableData.map((rowData, index) => 
        <TableRow 
            key = {GetRowKey(idFunc(rowData))}
            index = {index}
            id={idFunc(rowData)} 
            rowData={rowData} 

            onDetail={onDetailRecord}
            onEdit={onEditRecord} 
            onDelete={onDeleteRecord}
            allowDetail={allowDetail}
            allowEdit={allowEdit}
            allowDelete={allowDelete}
            />
        );
    

    return (
        <table {...others}>
            {jsxColumns}
            <tbody>{jsxRows}</tbody>
        </table>
    );
}

const TableRow = ({id, index, rowData, onDetail, onEdit, onDelete, allowDetail, allowEdit, allowDelete, ...props}) => {

    const jsxFieldFunc = (content, rowIndex, fieldIndex) => 
        (<td key={GetFieldKey(rowIndex, fieldIndex)}>
            {typeof (content)==='object' 
                ? "data" 
                : content }
        </td>);

    let jsxFields = Object.keys(rowData).map((col, fieldIndex) => jsxFieldFunc(rowData[col], index, fieldIndex) );

    if (allowDetail)
        jsxFields.push(<td key={GetFieldKey(id+1, jsxFields.length+1)}> 
                            <button type="button" className="btn btn-secondary" onClick={()=>{onDetail(id)}}> <i className="far fa-eye"></i></button>  
                        </td>);
    
    if (allowEdit)
        jsxFields.push(<td key={GetFieldKey(id+1, jsxFields.length+1)}> 
                            <button type="button" className="btn btn-warning" onClick={()=>{onEdit(id)}}> <i className="far fa-edit"></i></button>  
                        </td>);
    
    if (allowDelete)
        jsxFields.push(<td key={GetFieldKey(id+1, jsxFields.length+2)}> 
                            <button type="button" className="btn btn-danger" onClick={()=>{onDelete(id)}}> <i className="fas fa-trash"></i></button>   
                        </td>);

    return (
        <tr {...props}> 
            {jsxFields}
        </tr>
    );
}   

export default Table;