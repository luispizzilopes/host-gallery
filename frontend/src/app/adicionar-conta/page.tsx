"use client"

import Link from "next/link"
import { ChevronLeftIcon } from "@radix-ui/react-icons"
import { useRouter } from 'next/navigation'
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
import { useState } from "react"
import { CadastroInterface } from "@/interfaces/CadastroInterface"
import { cadastrarNovaConta } from "@/features/adicionar-conta/services/adicionar-conta-service"

export default function AdicionarConta() {
    const router = useRouter();
    const [informacoesNovaConta, setInformacoesNovaConta] = useState<CadastroInterface | null>(null);

    return (
        <div className="flex items-center justify-center min-h-screen bg-muted">
            <div className="fixed left-2 top-2">
                <Button variant="outline" size="icon" onClick={() => router.push("/login")}>
                    <ChevronLeftIcon className="h-4 w-4" />
                </Button>
            </div>
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
                                <Input
                                    placeholder="João"
                                    required
                                    onChange={(e) => setInformacoesNovaConta({ ...informacoesNovaConta, primeiroNome: e.target.value })}
                                />
                            </div>
                            <div className="grid gap-2">
                                <Label htmlFor="last-name">Último nome</Label>
                                <Input
                                    placeholder="Oliveira"
                                    required
                                    onChange={(e) => setInformacoesNovaConta({ ...informacoesNovaConta, ultimoNome: e.target.value })}
                                />
                            </div>
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="email">Email</Label>
                            <Input
                                id="email"
                                type="email"
                                placeholder="exemplo@gmail.com"
                                required
                                onChange={(e) => setInformacoesNovaConta({ ...informacoesNovaConta, email: e.target.value })}
                            />
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="email">Apelido</Label>
                            <Input
                                id="apelido"
                                placeholder=""
                                required
                                onChange={(e) => setInformacoesNovaConta({ ...informacoesNovaConta, apelido: e.target.value })}
                            />
                        </div>
                        <div className="grid gap-2">
                            <Label htmlFor="password">Senha</Label>
                            <Input
                                id="password"
                                type="password"
                                onChange={(e) => setInformacoesNovaConta({ ...informacoesNovaConta, senha: e.target.value })} />
                        </div>
                        <Button type="submit" className="w-full" onClick={async (): Promise<void> => {
                            if (await cadastrarNovaConta(informacoesNovaConta)) {
                                router.push("/login");
                            }
                        }}>
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
