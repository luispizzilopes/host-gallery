"use client";

import { useEffect, useState } from "react";
import Image from "next/image";
import Link from "next/link";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { LoadingSpinner } from "@/components/LoadingSpinner";
import { toast } from "sonner"

import ApiPicsum from "@/services/api-picsum";
import backgroundLogin from "../../assets/background-login.jpg";

export default function Login() {
    const [imagem, setImagem] = useState<string | null>(null);

    const carregarImagemBackground = async () => {
        try {
            const resposta = await ApiPicsum.get("/1920/1080", { responseType: "blob" });
            const blob = URL.createObjectURL(resposta.data);
            setImagem(blob);
        } catch (error: Error | any) {
            setTimeout(() => {
                toast("Ocorreu um erro.", {
                    description: error.message,
                })
            });
        }
    };

    useEffect(() => {
        carregarImagemBackground();
    }, []);

    return (
        <div className="w-full lg:grid lg:min-h-[600px] lg:grid-cols-2 xl:min-h-[800px]">
            <div className="flex items-center justify-center py-12">
                <div className="mx-auto grid w-[400px] gap-6">
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
                            <Input id="email" type="email" placeholder="exemplo@gmail.com" required />
                        </div>
                        <div className="grid gap-2">
                            <div className="flex items-center">
                                <Label htmlFor="password">Senha</Label>
                                <Link href="/forgot-password" className="ml-auto inline-block text-sm underline">
                                    Esqueceu sua senha?
                                </Link>
                            </div>
                            <Input id="password" type="password" required />
                        </div>
                        <Button type="submit" className="w-full">Realizar Login</Button>
                    </div>
                    <div className="mt-4 text-center text-sm">
                        Não possui uma conta?{" "}
                        <Link href="adicionar-conta" className="underline">Cadastre-se</Link>
                    </div>
                </div>
            </div>
            <div className="hidden bg-muted lg:flex items-center justify-center h-full">
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

        </div>
    );
}
