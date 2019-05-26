import React from 'react';
import './footer-bar.css'

import {withRouter} from 'react-router-dom';


const FooterBar = ({history, location}) =>{

    //const func = (path) =>{ history.push(path) }

    return (

        <div className="navbar-fixed-bottom row-fluid">
            <div className="navbar-inner">
                <div className="container">
                    <div className="footer-copyright text-center py-3">© {new Date().getFullYear()} Copyright:
                        <a href="/"> Good Market</a>
                    </div>
                </div>
            </div>
        </div>

        
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

export default withRouter(FooterBar) ;

//export default HeaderBar;
