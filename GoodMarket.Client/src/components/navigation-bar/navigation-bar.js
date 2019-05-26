import React from 'react';
import './navigation-bar.css'

import {withRouter} from 'react-router-dom';


const NavigationBar = ({history, location}) =>{

    const redirect = (path) =>{ history.push(path) }

    return (
        <nav className = "navbar navbar-expand-sm bg-secondary navbar-dark">
            {/* <span className="navbar-brand" onClick={()=>func("/")}>Logo</span> */}
            <ul className = "navbar-nav">
                <NavbarLink label = "Home" onClick={()=>redirect("/home")}/>
                <NavbarLink label = "Showcase" onClick={()=>redirect("/showcase")}/>
                <NavbarLink label = "Customers" onClick={()=>redirect("/customers")}/>
                <NavbarLink label = "Users" onClick={()=>redirect("/users")}/>
                <NavbarLink label = "Products" onClick={()=>redirect("/products")}/>
                <NavbarLink label = "Orders" onClick={()=>redirect("/orders")}/>
                <NavbarLink label = "Cart" onClick={()=>redirect("/cart")}/>
            </ul>
        </nav>
    );
}

const NavbarLink = ({label, onClick, active, disable})=>{
    let classData = "nav-item";
    if (active)
        classData +=" active";
    if (disable)
        classData +=" disabled";

    return(
        <li className = {classData} onClick={onClick}>
            <span className = "nav-link" >{label}</span>
        </li>
    );
}

export default withRouter(NavigationBar) ;
