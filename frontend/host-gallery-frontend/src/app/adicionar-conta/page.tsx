import Link from "next/link"

import { Button } from "@/components/ui/button"
import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
} from "@/components/ui/card"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"

export default function AdicionarConta() {
    return (
        <div className="flex items-center justify-center min-h-screen bg-muted">
          <Card className="mx-auto max-w-md">
                <CardHeader>
                    <CardTitle className="text-xl">Cadastre-se</CardTitle>
                    <CardDescription>
                        Entre com suas informações para criar uma nova conta.
                    </CardDescription>
                </CardHeader>
                <CardContent>
                    <div className="grid gap-4">
                        <div className="grid grid-cols-2 gap-4">
                            <div className="grid gap-2">
                                <Label htmlFor="first-name">Primeiro nome</Label>
                                <Input id="first-name" placeholder="João" required />
                            </div>
                            <div className="grid gap-2">
                                <Label htmlFor="last-name">Último nome</Label>
                                <Input id="last-name" placeholder="Oliveira" required />
                            </div>
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="email">Email</Label>
                            <Input
                                id="email"
                                type="email"
                                placeholder="exemplo@gmail.com"
                                required
                            />
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="email">Apelido</Label>
                            <Input
                                id="apelido"
                                placeholder=""
                                required
                            />
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="password">Senha</Label>
                            <Input id="password" type="password" />
                        </div>
                        <Button type="submit" className="w-full">
                            Criar nova conta
                        </Button>
                    </div>
                    <div className="mt-4 text-center text-sm">
                        Possui uma conta?{" "}
                        <Link href="login" className="underline">
                            Realize o login
                        </Link>
                    </div>
                </CardContent>
            </Card>
        </div>
    )
}
