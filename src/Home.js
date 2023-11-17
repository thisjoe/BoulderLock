import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

const Home = () => {
    const usenavigate = useNavigate();
    return  (
        <div className="header">
            <div>
                <Link to={'/'}></Link>
                <Link style={{float:'right'}} to={'/login'}>Logout</Link>
            </div>
            <div>
                <img src="/BoulderLock.png" className="App-logo" alt="logo" />
                <h1>BoulderLock</h1>
                <h1>Welcome to BoulderLock</h1>
            </div>
        </div>
    );
}

export default Home;