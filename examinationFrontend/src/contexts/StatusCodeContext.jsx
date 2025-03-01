import { createContext, useEffect, useState } from "react";

export const StatusCodeContext = createContext()

export const StatusProvider = ({children}) => {
    const apiUri = 'https://localhost:7044/api/statusCode'    
    const [statuses, setStatuses] = useState([])
    
    const getStatuses = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setStatuses(data)
    }

    useEffect(() => {
        getStatuses()
    }, [])

    return (
        <StatusCodeContext.Provider value={{statuses, getStatuses}}>
            {children}
        </StatusCodeContext.Provider>
    )
}   