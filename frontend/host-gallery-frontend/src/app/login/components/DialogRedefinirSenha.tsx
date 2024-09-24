import React from "react";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogHeader,
    DialogTitle,
    DialogFooter
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

interface DialogRedefinirSenhaProps {
    open: boolean;
    setOpen: (open: boolean) => void;
}

const DialogRedefinirSenha: React.FC<DialogRedefinirSenhaProps> = ({ open, setOpen }) => {
    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogContent className="sm:max-w-[425px]">
                <DialogHeader>
                    <DialogTitle>Redefinir Senha</DialogTitle>
                    <DialogDescription>
                        Insira seu e-mail para redefinir sua senha.
                    </DialogDescription>
                </DialogHeader>
                <div className="grid gap-4 py-4">
                    <Input id="email" type="email" placeholder="exemplo@gmail.com" required />
                </div>
                <DialogFooter>
                    <Button variant="outline" onClick={() => setOpen(false)}>Cancelar</Button>
                    <Button type="submit">Enviar</Button>
                </DialogFooter>
            </DialogContent>
        </Dialog>
    );
};

export default DialogRedefinirSenha;
