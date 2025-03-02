import React, { useContext, useEffect, useState } from 'react';
import { ProjectContext } from '../../contexts/ProjectContext';
import { useParams, useNavigate } from 'react-router-dom';

const UpdateProjectForm = () => {
    const { projectNumber } = useParams();
    const { project, getProject, updateProject } = useContext(ProjectContext);
    const [formData, setFormData] = useState({ projectName: '', startDate: '', endDate: '', notes: ''});
    const navigate = useNavigate();

    useEffect(() => {
        if (projectNumber){
            getProject(projectNumber)
        }
    }, [projectNumber]);

    useEffect(() => {
        if (project) {
            setFormData({
                projectName: project.projectName || '',
                startDate: project.startDate ? project.startDate.split('T')[0] : '',
                endDate: project.endDate ? project.endDate.split('T')[0] : '',
                notes: project.notes || ''
            });
        }
    }, [project]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }))
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        const updatedProject = { ...formData, projectNumber }

        const result = await updateProject(updatedProject, navigate);
        if (result) {
            navigate(`/projects`)
            alert('Projektet är uppdaterat!')
        } else {
            alert('Uppdateringen misslyckades!')
        }
    }

       if (!project) {
        return <div>Loading...</div>;
    }

    return (
        <section>
            <div className='container'>
                <form onSubmit={handleSubmit}>
                <h3>Projektinformation</h3>

                    <div className='form-group'>
                        <label htmlFor='projectName'>Projektnamn:</label>
                        <input
                            type="text"
                            name="projectName"
                            value={formData.projectName}
                            onChange={handleChange}
                        />
                    </div>

                    <div className='form-group'>
                        <label htmlFor='startDate'>Startdatum:</label>
                        <input
                            type="date"
                            name="startDate"
                            value={formData.startDate}
                            onChange={handleChange}
                        />
                    </div>

                    <div className='form-group'>
                        <label htmlFor='endDate'>Slutdatum:</label>
                        <input
                            type="date"
                            name="endDate"
                            value={formData.endDate}
                            onChange={handleChange}
                        />
                    </div>

                    <div className='form-group'>
                        <label htmlFor='notes'>Anteckningar:</label>
                        <textarea
                            name="notes"
                            value={formData.notes}
                            onChange={handleChange}
                        />
                    </div>

                    <button className='btn' type='submit'>Spara</button>
                </form>
            </div>
        </section>
    );
}

export default UpdateProjectForm;