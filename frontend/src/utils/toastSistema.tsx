import { toast } from "sonner";

interface ToastProps {
    cabecalho: string;
    descricao: string;
}

export const toastSistema = ({ cabecalho, descricao }: ToastProps): void => {
    setTimeout(() => {
        toast(cabecalho, {
            description: descricao,
        });
    });
};
