import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

const CreateProjectForm = () => {
    const navigate = useNavigate()

    const submitUrl = 'https://localhost:7044/api/project'
    const customerUrl = 'https://localhost:7044/api/customer'
    const statusUrl = 'https://localhost:7044/api/statuscode'
    const managerUrl = 'https://localhost:7044/api/projectmanager'
    const serviceUrl = 'https://localhost:7044/api/service'
    
    const [customers, setCustomers] = useState([])
    const [statuses, setStatuses] = useState([])
    const [managers, setManagers] = useState([])
    const [services, setServices] = useState([])

    const [formData, setFormData] = useState({ projectName: '', notes: '', customerId: '', projectManagerId: '', startDate: '', endDate: '', statusCodeId: '', serviceId: ''})

    const handleChange = (e) => {
        console.log('Selected value:', e.target.value); 
        setFormData(current => ({ ...current, [e.target.id]: e.target.value }));
    }

    useEffect(() => {
        console.log("FormData uppdaterat:", formData);
    }, [formData]);
    

    const getData = async (url) => {
        try {
            const res = await fetch(url)
            const data = await res.json()
            return data
        } catch (error) {
            console.error('Error fetching customers:', error)
        }
    }

    useEffect(() => {
        setData()
    }, []);

    const setData = async () => {
        setCustomers(await getData(customerUrl))
        setStatuses(await getData(statusUrl))
        setManagers(await getData(managerUrl))
        setServices(await getData(serviceUrl))
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const res = await fetch(submitUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });

            if (res.ok) {
                navigate('/projects')
                alert('Projektet har skapats!')
            } else {
                alert('Misslyckades att skapa projektet!!')
            }
        } catch (error) {
            console.error('Error creating project:', error);
        }
    };

    return (
        <section>
            <div className='container'>
                <form onSubmit={handleSubmit}>
                <h3>Skapa projekt</h3>

                    <div className='form-layout'>
                        <div left-column>
                            <div className='form-group'>
                                <label htmlFor='projectName'>Projektnamn</label>
                                <input
                                    type="text"
                                    id='projectName'
                                    value={formData.projectName}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <div className='form-group'>
                                <label htmlFor='startDate'>Startdatum</label>
                                <input
                                    type="text"
                                    id='startDate'
                                    value={formData.startDate}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <div className='form-group'>
                                <label htmlFor='endDate'>Slutdatum</label>
                                <input
                                    type="text"
                                    id='endDate'
                                    value={formData.endDate}
                                    onChange={handleChange}
                                    required
                                />
                            </div>

                            <div className='form-group'>
                                <label htmlFor='notes'>Anteckningar</label>
                                <textarea
                                    name="notes"
                                    id='notes'
                                    value={formData.notes}
                                    onChange={handleChange}
                                    required
                                ></textarea>
                            </div>
                        </div>

                        <div className=' right-column'>
                            <div className='form-group'>
                                <label htmlFor='customerId'>Kunder</label>
                                <select
                                    name="customers"
                                    id='customerId'
                                    value={formData.customerId}
                                    onChange={handleChange}
                                    required
                                >
                                    <option disabled hidden value=''>Välj en kund i listan</option>
                                    {customers.map(customer => (
                                        <option key={customer.id} value={customer.id}>
                                            {customer.customerName}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <div className='form-group'>
                                <label htmlFor='serviceId'>Service</label>
                                <select
                                    name="services"
                                    id='serviceId'
                                    value={formData.serviceId}
                                    onChange={handleChange}
                                    required
                                >
                                    <option disabled hidden value=''>Välj en service i listan</option>
                                    {services.map(service => (
                                        <option key={service.id} value={service.id}>
                                            {service.serviceName}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <div className='form-group'>
                                <label htmlFor='projectManagerId'>Projektledare</label>
                                <select
                                    name="projectManagers"
                                    id='projectManagerId'
                                    value={formData.projectManagerId}
                                    onChange={handleChange}
                                    required
                                >
                                    <option disabled hidden value=''>Välj en projektledare i listan</option>
                                    {managers.map(projectmanager => (
                                        <option key={projectmanager.id} value={projectmanager.id}>
                                            {projectmanager.fullName}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <div className='form-group'>
                                <label htmlFor='statusCodeId'>Status</label>
                                <select
                                    name="statusCode"
                                    id='statusCodeId'
                                    value={formData.statusCodeId}
                                    onChange={handleChange}
                                    required
                                >
                                    <option disabled hidden value=''>Välj en status i listan</option>
                                    {statuses.map(statusCode => (
                                        <option key={statusCode.id} value={statusCode.id}>
                                            {statusCode.statusCodeName}
                                        </option>
                                    ))}
                                </select>
                                <button className='btn btn-create' type='submit'>Skapa</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </section>
    );
};

export default CreateProjectForm;