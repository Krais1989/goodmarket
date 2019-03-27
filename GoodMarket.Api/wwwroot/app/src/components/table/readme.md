    
    Table config
    {
        Sorting: {
            [
                { column: integer, sortFunc: (a,b)=>{}}
                { column: integer, sortFunc: (a,b)=>{}}
            ]
            sortOrder: [integers]
            sortColumns: [integers] // 4,1,2 - порядок сортировок
        }

        Pagination: {maxItems: 10}

        Columns: {
            onClick: (column, index) => {}
            sortFunc: (a, b, column, index) => {(a,b) => { }}
            titleFunc: (column, index) => { return string; }
            showFunc: (column, index) => { return true|false; }

            render: (column, index) => { return JSX; }
            component: TableRow
        }

        Rows: {
            keyFunc: (row, index)=>{ return integer; }   // Настройка ключей
            showFunc: (row, index)=>{ return true|false; }
            render: (column, index) => { return JSX; }
            component: TableRow
            render: (field, index) =>{return JSX; }
            fieldComponent: (field, index) =>{return TableFiend; }
        }

        Buttons: { // Настройка для полей-кнопок
            callback: (btnId, rowId) => {},
            buttons: [
                {showFunc: (row, index)=>{return true}, title, class, clickFunc: ()=>{}}
            ]
        }


    }
