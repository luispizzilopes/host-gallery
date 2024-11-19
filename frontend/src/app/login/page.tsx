"use client";

import { useEffect, useState } from "react";
import Image from "next/image";
import Link from "next/link";

import { carregarImagemBackground, realizarAutenticacao } from "@/features/login/services/login-service";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { LoadingSpinner } from "@/components/LoadingSpinner";

import backgroundLogin from "../../assets/background-login.jpg";
import DialogRedefinirSenha from "../../features/login/components/DialogRedefinirSenha";
import { LoginInterface } from "@/features/login/interfaces/login-interface";
import ComponenteLoadingSpinner from "@/components/ComponenteLoadingSpinner";
import { useRouter } from 'next/navigation'


export default function Login() {
    const router = useRouter();
    const [carregandoRequisicao, setCarregandoRequisicao] = useState<boolean>(false);
    const [informacoesLogin, setInformacoesLogin] = useState<LoginInterface>({
        email: "",
        senha: "",
    });

    const [imagem, setImagem] = useState<string | null>(null);
    const [abrirDialogRedefinicaoSenha, setAbrirDialogRedefinicaoSenha] = useState<boolean>(false);


    useEffect(() => {
        carregarImagemBackground(setImagem);
    }, []);

    return (
        <div className="flex h-screen">
            <div className="flex items-center justify-center py-12 h-full w-full md:w-1/2 m-4 sm:m-0">
                <div className="mx-auto grid w-[95%] md:w-[65%] gap-6">
                    <div className="grid gap-2 text-center">
                        <h1 className="text-3xl font-bold">Host Gallery</h1>
                        <p className="italic text-balance text-muted-foreground text-[14px] mb-2">
                            Transforme suas imagens em memórias vivas e compartilhe com quem você ama.
                        </p>
                        <p className="text-balance">Insira seu e-mail abaixo para fazer login na sua conta</p>
                    </div>
                    <div className="grid gap-4">
                        <div className="grid gap-2">
                            <Label htmlFor="email">Email</Label>
                            <Input
                                id="email"
                                type="email"
                                placeholder="exemplo@gmail.com"
                                required
                                value={informacoesLogin.email}
                                onChange={(e) => setInformacoesLogin({ ...informacoesLogin, email: e.target.value })}
                            />
                        </div>
                        <div className="grid gap-2">
                            <div className="flex items-center">
                                <Label htmlFor="password">Senha</Label>
                                <p onClick={() => setAbrirDialogRedefinicaoSenha(true)} className="ml-auto inline-block text-sm underline cursor-pointer">
                                    Esqueceu sua senha?
                                </p>
                            </div>
                            <Input
                                id="password"
                                type="password"
                                required
                                value={informacoesLogin.senha}
                                onChange={(e) => setInformacoesLogin({ ...informacoesLogin, senha: e.target.value })}
                            />
                        </div>
                        <Button type="submit" className="w-full" onClick={async () => {
                            if (await realizarAutenticacao(informacoesLogin, setCarregandoRequisicao)) {
                                router.push("/home");
                            }
                        }}>Realizar Login</Button>
                    </div>
                    <div className="mt-4 text-center text-sm">
                        Não possui uma conta?{" "}
                        <Link href="adicionar-conta" className="underline">Cadastre-se</Link>
                    </div>
                </div>
            </div>

            <div className="hidden bg-muted lg:flex items-center justify-center h-full w-1/2">
                {
                    imagem != null ?
                        <Image
                            src={imagem ?? backgroundLogin}
                            alt="Image"
                            width="1920"
                            height="1080"
                            className="h-full w-full object-cover dark:brightness-[0.3]"
                        />
                        :
                        <div className="flex justify-center items-center h-full">
                            <LoadingSpinner />
                        </div>
                }
            </div>

            <DialogRedefinirSenha
                open={abrirDialogRedefinicaoSenha}
                setOpen={setAbrirDialogRedefinicaoSenha}
            />

            {carregandoRequisicao && <ComponenteLoadingSpinner />}
        </div>
    );

}
