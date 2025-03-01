import React from 'react'
import SectionHeader from '../components/elements/SectionHeader'
import ProjectInfo from '../components/elements/ProjectInfo'

const Project = () => {
    return (
        <main id='project'>
            <div className='container'>
                <SectionHeader title=''/>
                <ProjectInfo/>
            </div>
    </main>
    )
}

export default Project

// import React, { useContext, useEffect, useState } from 'react';
// import SectionHeader from '../components/elements/SectionHeader';
// import { ProjectContext } from '../contexts/ProjectContext';
// import { useParams, useNavigate } from 'react-router-dom';

// const Project = () => {
//     const { projectNumber } = useParams();
//     const { project, getProject, updateProject } = useContext(ProjectContext);
//     const [formData, setFormData] = useState({
//         projectName: '',
//         startDate: '',
//         endDate: '',
//         notes: ''
//     });
//     const navigate = useNavigate();

//     useEffect(() => {
//         getProject(projectNumber);
//     }, [projectNumber]);

//     useEffect(() => {
//         if (project) {
//             // Sätt formens initialvärden baserat på projectet
//             setFormData({
//                 projectName: project.projectName || '',
//                 startDate: project.startDate ? project.startDate.split('T')[0] : '',
//                 endDate: project.endDate ? project.endDate.split('T')[0] : '',
//                 notes: project.notes || ''
//             });
//         }
//     }, [project]);

//     // Hantera formändringar
//     const handleChange = (e) => {
//         const { name, value } = e.target;
//         setFormData(prevState => ({
//             ...prevState,
//             [name]: value
//         }));
//     };

//     // Hantera formulärets inskick
//     const handleSubmit = async (e) => {
//         e.preventDefault();
        
//         const updatedProject = {
//             ...formData,
//             projectNumber,
//         };

//         // Anropa updateProject-funktionen från context
//         const result = await updateProject(updatedProject);
//         if (result) {
//             // Navigera tillbaka till projektlistan eller någon annan sida
//             navigate(`/projects`);
//         } else {
//             console.error('Failed to update project');
//         }
//     };

//     if (!project) {
//         return <div>Loading...</div>;
//     }

//     return (
//         <main id='project'>
//             <div className='container'>
//                 <SectionHeader title='Projektinformation'/>
//             </div>

//             <div>
//                 <h3>Projektinformation</h3>
//                 <form className="project-details" onSubmit={handleSubmit}>
//                     <label>
//                         Projektnamn:
//                         <input
//                             type="text"
//                             name="projectName"
//                             value={formData.projectName}
//                             onChange={handleChange}
//                         />
//                     </label>

//                     <label>
//                         Startdatum:
//                         <input
//                             type="date"
//                             name="startDate"
//                             value={formData.startDate}
//                             onChange={handleChange}
//                         />
//                     </label>

//                     <label>
//                         Slutdatum:
//                         <input
//                             type="date"
//                             name="endDate"
//                             value={formData.endDate}
//                             onChange={handleChange}
//                         />
//                     </label>

//                     <label>
//                         Noteringar:
//                         <textarea
//                             name="notes"
//                             value={formData.notes}
//                             onChange={handleChange}
//                         />
//                     </label>

//                     <button className='btn' type='submit'>Spara</button>
//                 </form>
//             </div>
//         </main>
//     );
// }

// export default Project;


