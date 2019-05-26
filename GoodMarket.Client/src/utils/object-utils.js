

/** Копирует obj с изменением указанным в arr */
/** obj - исходный объект, arr - массив с изменением в иерархии [поле, [... поля], значение], i = для рекурсивного обхода arr */
const getWithChanges = (obj, arr, i=0) => {
    if (arr.length<2) return null;
    const f = arr[i];
    if (i+1 === arr.length - 1) { // предпоследний элемент
        const v = isNaN(arr[i+1])? arr[i+1] : parseInt(arr[i+1]);
        return Object.assign({}, obj, {[f]: v });
    }
    else {
        return Object.assign({}, obj, {[f]: getWithChanges(obj[f], arr, i+1) });
    }
}

export {getWithChanges}