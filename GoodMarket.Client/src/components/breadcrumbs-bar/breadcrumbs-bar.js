import React from 'react';
import {withRouter} from 'react-router-dom';
import './breadcrumbs-bar.css'
import { StrUtils } from '../../utils';

class BreadcrumbsBar extends React.Component {

    componentDidMount(){
        console.log("BreadcrumbsBar", "componentDidMount", this.state);
        const { location} = this.props;
        this.setState({path: location.pathname});
    }

    componentDidUpdate(prevProps, prevState){
        if (prevProps.location.pathname !== this.props.location.pathname){
            console.log(">>> BreadcrumbsBar", "PATH CHANGED", prevProps.location.pathname, this.props.location.pathname);
        }
    }

    getParentPath (pathArr, count) {
        const pa = pathArr.filter((p,i)=>i<=count).map(p=>`/${p}`);
        const path = pa.join("");
        console.log("Breadcrumb redirect:", path)
    }

    getPathArr(path) {
        return path.split("/").filter((p,i)=>p!=="");
    }

    render () {
        const { location} = this.props;
        console.log("BreadcrumbsBar", "render", this.state);

        const path = location.pathname;
        const pathArr = this.getPathArr(path);

        const jsxCrumbs = pathArr.map((p, i) => {
            const isActive = i===(pathArr.length-1);
            const cn = ` ${isActive ? "current" : ""}`;
            const title = StrUtils.capitalize(p);
            return (<li key={i+1} className={cn}><a href="#" onClick={this.getParentPath(pathArr, i)}>{title}</a></li>);
        });

        if (jsxCrumbs.length>0){
            jsxCrumbs.unshift(
                <li key="0">
                    <a href="/"><i className="fa fa-home"></i>
                    </a>
                </li>
            );
        }

        return (
            <ol id="breadcrumb">
                {jsxCrumbs}
            </ol>
        );
    }
}

export default withRouter(BreadcrumbsBar);