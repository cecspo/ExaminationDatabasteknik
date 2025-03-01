    import { createContext, useEffect, useState } from "react";
    import { useNavigate } from "react-router-dom";
    export const ProjectContext = createContext()

    export const ProjectProvider = ({children}) => {
        const apiUri = 'https://localhost:7044/api/project'
        const defaultProjectValues = {projectNumber: 0, projectName: '', notes: '', status: {}, startDate: '', endDate: '', projectManagerId: {}, customerName: {}, serviceName: {}}
        
        const [projects, setProjects] = useState([])
        const [project, setProject] = useState(defaultProjectValues)
        
        const getProjects = async () => {
            try {
                const res = await fetch(`${apiUri}`);
                if (!res.ok) throw new Error('Failed to fetch projects')
                const data = await res.json()
                setProjects(data)
            } catch (error) {
                console.error('Error fetching projects:', error);
            }
        }
        
        const getProject = async (projectNumber) => {
            try {
                const res = await fetch(`${apiUri}/${projectNumber}`)
                if (!res.ok) throw new Error('Failed to fetch project')
                const data = await res.json()
                setProject(data)
            } catch (error) {
                console.error('Error fetching project:', error);
            }
        }

        const updateProject = async (updatedProject) => {
            try {
                const res = await fetch(`${apiUri}/${updatedProject.projectNumber}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(updatedProject)
                });

                if (!res.ok) throw new Error('Failed to update project');
                
                const data = await res.json();
                setProject(data); // Uppdatera projektet med den nya informationen
                setProjects(prevProjects => prevProjects.map(proj => proj.projectNumber === data.projectNumber ? data : proj));
                
                console.log("Uppdateringen lyckades!"); // Logga success

                // Navigera tillbaka till /projects efter uppdateringen
                navigate('/projects');  // Skickar användaren till projektlistan

            } catch (error) {
                console.error('Error updating project:', error);
            }
        };

        useEffect(() => {
            getProjects()
        }, [])

        return (
            <ProjectContext.Provider value={{project, projects, getProjects, getProject, updateProject}}>
                {children}
            </ProjectContext.Provider>
        )
    }   