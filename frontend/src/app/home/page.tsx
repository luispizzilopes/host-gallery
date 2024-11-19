import DefaultPage from "@/components/DefaultPage"
import { Button } from "@/components/ui/button"
import { EnterIcon } from "@radix-ui/react-icons"

export default function Dashboard() {
    return (
        <DefaultPage nomePagina="Dashboard">
            <div className="flex flex-col items-center gap-1 text-center">
                <h3 className="text-2xl font-bold tracking-tight">
                    Você não possui nenhum evento no momento
                </h3>
                <p className="text-sm text-muted-foreground">
                    Para ingressar ou criar um novo evento clique no botão abaixo.
                </p>
                <Button className="mt-4"><EnterIcon className="mr-2"/> Novo Evento</Button>
            </div>
        </DefaultPage>
    )
}



