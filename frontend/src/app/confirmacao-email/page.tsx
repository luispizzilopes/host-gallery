"use client"

import { Button } from "@/components/ui/button"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card" // Importe os componentes de card
import { useRouter } from 'next/navigation'

export default function ConfirmarEmail() {
    const router = useRouter();

    return (
        <div className="flex items-center justify-center min-h-screen bg-muted p-6">
            <Card className="max-w-md w-full shadow-md">
                <CardHeader>
                    <CardTitle className="text-3xl font-extrabold text-center text-primary">Confirme seu E-mail</CardTitle>
                </CardHeader>
                <CardContent>
                    <p className="text-lg text-center mb-6 text-muted-foreground">
                        Por favor, verifique sua caixa de entrada e clique no link de confirmação que enviamos para o seu e-mail.
                        Isso é necessário para ativar sua conta.
                    </p>
                    <p className="text-md text-center text-muted-foreground">
                        Se você não receber o e-mail, verifique a pasta de spam ou a lixeira.
                    </p>
                </CardContent>
                <div className="flex justify-center mb-4">
                    <Button
                        onClick={() => router.push("/login")}
                        className="bg-primary hover:bg-primary-dark transition duration-200"
                    >
                        Voltar para o Login
                    </Button>
                </div>
            </Card>
        </div>
    )
}
