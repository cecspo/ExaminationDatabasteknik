import React, { useContext, useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
import { ProjectContext } from '../../contexts/ProjectContext';

const ProjectInfo = () => {
    const {projectNumber} = useParams();
    const  {project, getProject, updateProject} = useContext(ProjectContext);
    const navigate = useNavigate();

    useEffect(() => {
        getProject(projectNumber)
    }, [projectNumber])

    if (!project) {
        return <div>Loading...</div>
    }

    const handleUpdateClick = () => {
        navigate(`/projects/${projectNumber}/update`)
    }

  return (
    <main>
        <div className="project-details">
            <h3>Projektinformation</h3>
            <p><strong>Projektnamn:</strong> {project.projectName}</p>
            <p><strong>Projektnummer:</strong> {project.projectNumber}</p>
            <p><strong>Startdatum:</strong> {project.startDate}</p>
            <p><strong>Slutdatum:</strong> {project.endDate}</p>

            <h4>Projektledare</h4>
            <p><strong>Fullständigt namn:</strong> {project.projectManager ? project.projectManager.fullName : 'Ingen projektledare'}</p>

            <h4>Övriga detaljer</h4>
            <p><strong>Anteckningar:</strong> {project.notes || 'Inga anteckningar'} </p>
            <p><strong>Status:</strong> {project.statusCode?.status || 'Ej specificerat'}</p>
        </div>

        <button className='btn' type='button' onClick={handleUpdateClick}>Uppdatera</button>
    </main>
  )
}

export default ProjectInfo