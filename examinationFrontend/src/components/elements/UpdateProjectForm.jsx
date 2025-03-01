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

    // Hantera formändringar
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    // Hantera formulärets inskick
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        const updatedProject = {
            ...formData,
            projectNumber          
        };

        const result = await updateProject(updatedProject, navigate);
        if (result) {
            navigate(`/projects`)
        } else {
            console.error('Failed to update project')
        }
    }

       if (!project) {
        return <div>Loading...</div>;
    }

    return (
        <main id='project'>
            <div className='container'>
                <h3>Projektinformation</h3>
                <form  className="project-details" onSubmit={handleSubmit}>
                    <label>
                        Projektnamn:
                        <input
                            type="text"
                            name="projectName"
                            value={formData.projectName}
                            onChange={handleChange}
                        />
                    </label>

                    <label>
                        Startdatum:
                        <input
                            type="date"
                            name="startDate"
                            value={formData.startDate}
                            onChange={handleChange}
                        />
                    </label>

                    <label>
                        Slutdatum:
                        <input
                            type="date"
                            name="endDate"
                            value={formData.endDate}
                            onChange={handleChange}
                        />
                    </label>

                    <label>
                        Anteckningar:
                        <textarea
                            name="notes"
                            value={formData.notes}
                            onChange={handleChange}
                        />
                    </label>

                    <button className='btn' type='submit'>Spara</button>
                </form>
            </div>
        </main>
    );
}

export default UpdateProjectForm;


// import React, { useState, useContext } from 'react';
// import { ProjectContext } from '../../contexts/ProjectContext';

// const UpdateProjectForm = ({ project }) => {
//     const { updateProject } = useContext(ProjectContext); // Få tillgång till updateProject från context
//     const [formData, setFormData] = useState({
//         projectName: project.projectName,
//         startDate: project.startDate,
//         endDate: project.endDate,
//         notes: project.notes || ''
//     });

//     const handleChange = (e) => {
//         const { name, value } = e.target;
//         setFormData(prevState => ({
//             ...prevState,
//             [name]: value
//         }));
//     };

//     const handleSubmit = async (e) => {
//         e.preventDefault();
//         console.log("Form submitted with data:", formData);
//         const updatedProject = { ...formData, projectNumber: project.projectNumber };
//         await updateProject(updatedProject); // Skicka uppdateringen till ProjectContext
//     };

//     return (
//         <form onSubmit={handleSubmit}>
//             <div>
//                 <label>Projektnamn:</label>
//                 <input
//                     type="text"
//                     name="projectName"
//                     value={formData.projectName}
//                     onChange={handleChange}
//                 />
//             </div>
//             <div>
//                 <label>Startdatum:</label>
//                 <input
//                     type="date"
//                     name="startDate"
//                     value={formData.startDate}
//                     onChange={handleChange}
//                 />
//             </div>
//             <div>
//                 <label>Slutdatum:</label>
//                 <input
//                     type="date"
//                     name="endDate"
//                     value={formData.endDate}
//                     onChange={handleChange}
//                 />
//             </div>
//             <div>
//                 <label>Anteckningar:</label>
//                 <textarea
//                     name="notes"
//                     value={formData.notes}
//                     onChange={handleChange}
//                 />
//             </div>
//             <button type="submit">Uppdatera</button>
//         </form>
//     );
// };

// export default UpdateProjectForm;
