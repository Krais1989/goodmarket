
export const reducer = (state, action) => {

    if (state === undefined){
        return {
            page: 'home'
        }
    }

    let newState = {...state};
    switch (action.type) {
        case 'redirect':
            break;
        default:
            return state;
    }

    return newState;
}
