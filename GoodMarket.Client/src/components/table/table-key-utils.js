export const GetRowKey = (rowId)=>{
    return (rowId*10).toString();
}

export const GetFieldKey = (rowId, fieldIndex) => {
    const result = (rowId*10 + fieldIndex).toString();
    //console.log(">", result);
    return result;
}
