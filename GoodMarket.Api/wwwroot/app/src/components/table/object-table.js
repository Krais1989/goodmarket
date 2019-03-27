import React from 'react';
import './table.css';
import {ErrorIndicator} from '../error';

import Table from './table';
import { StrUtils } from '../../utils';

/** Обёртка для конвертации сложных входных данных в простые для Table */
/** columns: {name: title, name: title} */
/** objects: [{},{},{}] - массив объектов схожей структуры */
const ObjectsTable = ({columns = null, objects=[], ...props}) => {

    //if (!objects || objects.length===0) return <React.Fragment>TableWrap data is undefined</React.Fragment>;
    
    let columnsData = {};
    // Если columns не определён, взять все поля первого объекта
    if (columns===null){
        if (objects.length > 0)
        {
            let cols = Object.keys(objects[0]);
            for (let i = 0; i < cols.length; i++) {
                columnsData[cols[i]] = StrUtils.capitalize(cols[i]);
            }
        }
    }
    else
        columnsData = {...columns};

    if (Object.keys(columnsData).length === 0){
        return (<ErrorIndicator />);
    }

    /** Обработка строки в соответствии с columnsData */
    let rowsData = [];
    objects.forEach(obj => {
        let rowPropArr = Object.keys(columnsData).map((k) => obj[k]);
        rowsData.push(rowPropArr);
    });

    return (
        <Table columns={Object.values(columnsData)} rows = {rowsData} {...props}>
        </Table>
    );
}

export default ObjectsTable;