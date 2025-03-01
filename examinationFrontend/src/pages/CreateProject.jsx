import React from 'react'
import CreateProjectForm from '../components/elements/CreateProjectForm'
import SectionHeader from '../components/elements/SectionHeader'

const CreateProject = () => {

  return (
    <>
      <section className='section-title'>
          <div className='container'>
            <CreateProjectForm/>     
            <SectionHeader title={`PROJEKT - SKAPA NYTT`}/>     
          </div>
      </section>
    </>
  )
}

export default CreateProject