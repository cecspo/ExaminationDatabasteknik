import React from 'react'
import { Link } from 'react-router-dom'

const SectionHeader = ({projectName}) => {

  return (
    <div className='section-header'>
        <h1>{projectName}</h1>
        <div className='nav-buttons'>
            <Link to="/projects/create" className='btn'>Skapa Projekt</Link>
            <Link to="/projects" className='btn'>Visa Lista</Link>
        </div>
    </div>  
    )
}

export default SectionHeader