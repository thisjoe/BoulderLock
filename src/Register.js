import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export const Register = () => {
    const [userId, Idchange] = useState('');
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [firstName, setfirstName] = useState('');
    const [lastName, setlastName] = useState('');
    //const [role, setRole] = useState('');

    const navigate=useNavigate();

    const IsValidate = ()=>{
        let isproceed=true;
        let errormessage = 'Please enter the value in ';
        if (username === null || username === ''){
            isproceed = false;
            errormessage += 'Username'
        }
        if (email === null || email === ''){
            isproceed = false;
            errormessage += 'Email'
        }
        if (password === null || password === ''){
            isproceed = false;
            errormessage += 'Username'
        }
        if (!isproceed){
            toast.warning(errormessage)
        }else{
            if(/^[a-zA-Z9-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/.test(email)){

            }else{
                isproceed = false;
                toast.warning('Please enter a valid email')
            }
        }
        return isproceed;
    }

    const handlesubmit = (e) =>{
        e.preventDefault();
        let regobj={email, username, password, confirmPassword};
        if(IsValidate()){
            
            fetch("http://localhost:5272/api/User/Register",{
                method:"POST",
                headers:{'Content-Type': 'application/json'},
                body:JSON.stringify(regobj)
                
            }).then((res)=>{
                toast.success('Registered Successfully.')
                navigate('/login');
            }).catch((err)=>{
                toast.error('Failed :'+err.message);
            });
        }
    }
    return (
        <div>
            <div className="offset-lg-3 col-lg-6">
                <form className="container" onSubmit={handlesubmit}>
                    <div className="card">
                        <div className="card-header">
                        <h1>User Registration</h1>
                        </div>
                        <div className="card-body">

                            <div className="row">
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>Email<span className="errmsg">*</span></label>
                                        <input value={email} onChange={e=>setEmail(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>Username<span className="errmsg">*</span></label>
                                        <input value={username} onChange={e=>setUsername(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>Password<span className="errmsg">*</span></label>
                                        <input value={password} onChange={e=>setPassword(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>Confirm Password<span className="errmsg">*</span></label>
                                        <input value={confirmPassword} onChange={e=>setConfirmPassword(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>First Name<span className="errmsg">*</span></label>
                                        <input value={firstName} onChange={e=>setfirstName(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <div className="form-group">
                                        <label>Last Name<span className="errmsg">*</span></label>
                                        <input value={lastName} onChange={e=>setlastName(e.target.value)} className="form-control"></input>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="card-footer">
                            <button type="submit" className="btn btn-primary">Register</button>
                            <Link to={'/login'} className="btn btn-danger">Close</Link>
                        </div>
                    </div>
                </form>
            </div>            
        </div>
    );
}

export default Register;