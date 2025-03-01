import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import { BrowserRouter } from 'react-router-dom'
import { ProjectProvider } from './contexts/ProjectContext.jsx'
import { StatusProvider } from './contexts/StatusCodeContext.jsx'


createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <StatusProvider>
      <ProjectProvider>
        <App />
      </ProjectProvider>
    </StatusProvider>
  </BrowserRouter>,
)
