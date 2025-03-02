import React, { useContext, useEffect } from 'react'
import { ProjectContext } from '../../contexts/ProjectContext'
import ProjectItemList from './ProjectItemList'

const ProjectList = () => {
    const {projects, getProjects} = useContext(ProjectContext);

    useEffect(() => {
        getProjects()
    }, [])

  return (
      <table className='project-list'>
         <thead>
             <tr>
                 <th className='projectnumber'>Projektnummer</th>
                 <th className='projectname'>Projektnamn</th>
                 <th className='start'>Start</th>
                 <th className='enddate'>Slut</th>
                 <th className='projectmanager'>Projektledare</th>
             </tr>
         </thead>
        <tbody>
            {
              projects.map(project => (<ProjectItemList key ={project.projectNumber} project ={project}/>))
            }
        </tbody>
      </table>
  )
}

export default ProjectList