"use client"

import { useRouter } from 'next/navigation'
import { useEffect } from "react";

export default function ModeToggle() {
  const route = useRouter();

  useEffect(()=>{
    route.push("/login"); 
  }, [])

  return (
    <div className='flex h-screen justify-center items-center'>
      <p>Redirecionando para tela de login...</p>
    </div>
  )
}
