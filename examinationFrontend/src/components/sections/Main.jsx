import React from 'react'
import { Route, Routes } from 'react-router-dom'
import CreateProject from '../../pages/CreateProject'
import Project from '../../pages/Project'
import Projects from '../../pages/Projects'
import UpdateProject from '../../pages/UpdateProject'

const Main = () => {
  return (
    <Routes>
      <Route path="/" element={<Projects/>}/>
      <Route path="/projects" element={<Projects/>}/>
      <Route path="/projects/create" element={<CreateProject/>}/>
      <Route path="/projects/:projectNumber" element={<Project/>}/>
      <Route path="/projects/:projectNumber/update" element={<UpdateProject/>}/>
    </Routes>
  )
}

export default Main

