"use client";

import React, { createContext, useState, ReactNode } from "react";

interface LoadingContextType {
    carregando: boolean;
    setCarregando: React.Dispatch<React.SetStateAction<boolean>>;
}

export const LoadingContext = createContext<LoadingContextType | undefined>(undefined);

export const LoadingProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [carregando, setCarregando] = useState<boolean>(false);

    return (
        <LoadingContext.Provider value={{ carregando, setCarregando }}>
            {children}
        </LoadingContext.Provider>
    );
};

