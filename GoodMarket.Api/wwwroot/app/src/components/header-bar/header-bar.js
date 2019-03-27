import React from 'react';
import './header-bar.css'

import {withRouter} from 'react-router-dom';


const HeaderBar = ({history, location}) =>{

    const func = (path) =>{ history.push(path) }

    return (
        <nav className = "navbar navbar-expand-sm bg-dark navbar-dark">
            <span className="navbar-brand" onClick={()=>func("/")}>Good Market CMS</span>
        </nav>
    );
}

// const NavbarLink = ({label, onClick, active, disable})=>{
//     let classData = "nav-item";
//     if (active)
//         classData +=" active";
//     if (disable)
//         classData +=" disabled";

//     return(
//         <li className = {classData} onClick={onClick}>
//             <span className = "nav-link" >{label}</span>
//         </li>
//     );
// }

export default withRouter(HeaderBar) ;

//export default HeaderBar;
