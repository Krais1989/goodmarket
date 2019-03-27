

# === CONTEXT API === #

# Context объект содержит Provider и Consumer, которые используются для поставки и получения данных.
# Поставить данные во внутренние компоненты
    <Context.Provider value={}> ... </Context.Provider>

# Подучение данных. Consumer попадают данные первого подходящего Provider. (Provider и Consumer одного Context объекта)
# Для внедрения используется функция принимающая данные Provider и возвращающая JSX
    <Context.Consumer> {(value) => (<Component></Component>))} </Context.Consumer> 

# Инициализовать компоненты контекстов. Прийдётся использовать в Provider и Consumer, поэтому выделить создание контекста в отдельный файл
    const MyContext = React.createContext([default value]);
    # С использованием алиасов Provider и Consumer. Будет <SwapiServiceProvider> и <SwapiServiceConsumer>
    const {
        Provider : SwapiServiceProvider,
        Consumer : SwapiServiceConsumer
    } = React.createContext();
# Объект, создаваемый createContext() будет считывать ближайший подходящий Provider 

# Провайдер. Компонент верхнего уровня
    Создать передаваемые объекты в state.
    
# Потребитель. Компонент внутри иерархии, обозначенной MyContext.Prodiver
    