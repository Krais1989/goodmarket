import React from 'react';
import {BrowserRouter as Router, Route, Switch, Redirect} from 'react-router-dom';

import HeaderBar from '../header-bar';
import NavigationBar from '../navigation-bar/navigation-bar';
import {HomePage} from '../../pages';
import ShowcasePage from '../../pages/showcase-page';
import { withBaseSwitch, BaseSwitchPage } from '../../pages/base';

import './app.css';
import {UsersListPage, UserDetailsPage, UserEditPage, UserCreatePage} from '../../pages/users';
import BreadcrumbsBar from '../breadcrumbs-bar';
import FooterBar from '../footer-bar';
import { ProductsListPage, ProductDetailsPage, ProductEditPage, ProductCreatePage } from '../../pages/products';
import { OrdersListPage, OrderDetailsPage, OrderEditPage, OrderCreatePage } from '../../pages/orders';
import { ShoppingCartPage } from '../../pages/shopping-cart';
import { CustomersListPage, CustomerDetailsPage, CustomerEditPage, CustomerCreatePage } from '../../pages/customers';


const App = () =>{
    
    const UsersSwitchPage 
        = withBaseSwitch({ListPage: UsersListPage, DetailsPage: UserDetailsPage, EditPage: UserEditPage, CreatePage:UserCreatePage});
    const ProductsSwitchPage
        = withBaseSwitch({ListPage: ProductsListPage, DetailsPage: ProductDetailsPage, EditPage: ProductEditPage, CreatePage:ProductCreatePage});
    const OrdersSwitchPage 
        = withBaseSwitch({ListPage: OrdersListPage, DetailsPage: OrderDetailsPage, EditPage: OrderEditPage, CreatePage:OrderCreatePage});
    const CustomersSwitchPage 
        = withBaseSwitch({ListPage: CustomersListPage, DetailsPage: CustomerDetailsPage, EditPage: CustomerEditPage, CreatePage:CustomerCreatePage});
    
    return (
        <div className="gm-app-container">
            <Router>
                    <React.Fragment>
                        <HeaderBar/>
                        <NavigationBar/>
                        <BreadcrumbsBar/>
                        <div className="d-flex column mt-4 justify-content-center">
                            <Switch>
                                <Route path = '/' component={HomePage} exact />
                                <Route path = '/showcase' component={ShowcasePage} />
                                <Route path = '/customers' component={CustomersSwitchPage} />
                                <Route path = '/users' component={UsersSwitchPage} />
                                <Route path = '/products' component={ProductsSwitchPage} />
                                <Route path = '/orders' component={OrdersSwitchPage} />
                                <Route path = '/cart' component={ShoppingCartPage} />
                                <Redirect to="/" />
                            </Switch>
                        </div>
                        <FooterBar/>
                    </React.Fragment>
            </Router>
        </div>
    
    );
}

export default App;