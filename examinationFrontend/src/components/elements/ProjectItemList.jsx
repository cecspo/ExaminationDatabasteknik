import React from 'react'
import { useNavigate } from 'react-router-dom';

const ProjectItemList = ({project}) => {
    const navigate = useNavigate();
    const fullName = project.projectManager ? project.projectManager.fullName : "Ingen projektledare";
    const startDate = project.startDate ? new Date(project.startDate).toLocaleDateString() : "Inget startdatum";
    const endDate = project.endDate ? new Date(project.endDate).toLocaleDateString() : "Inget slutdatum";

    
  return (
      <tr onClick={() => navigate(`${project.projectNumber}`)}>
        <td>{project.projectNumber}</td>
        <td>{project.projectName}</td>
        <td>{startDate}</td>
        <td>{endDate}</td>
        <td>{fullName}</td>
      </tr> 
    )
}

export default ProjectItemList

