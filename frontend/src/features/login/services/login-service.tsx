import ApiPicsum from "@/services/api-picsum";
import { toastSistema } from "@/utils/toastSistema";
import { LoginInterface } from "../interfaces/login-interface";
import apiHostGallery from "@/services/apiHostGallery";

export async function carregarImagemBackground(setImagem: (imagem: string) => void): Promise<void> {
    try {
        const resposta = await ApiPicsum.get("/1920/1080", { responseType: "blob" });
        const blob = URL.createObjectURL(resposta.data);
        setImagem(blob);
    } catch (error: Error | any) {
        toastSistema({
            cabecalho: "Ocorreu um erro.",
            descricao: error.message,
        });
    }
};

export async function realizarAutenticacao(informacoesLogin: LoginInterface, setCarregandoRequisicao: (status: boolean) => void): Promise<boolean> {
    setCarregandoRequisicao(true);

    try {
        const resposta = await apiHostGallery
            .post("/Autenticacao/login", informacoesLogin);

        if (resposta.status === 200) {
            return true;
        }

        return false;
    } catch (error: Error | any) {
        let errors = error.response.data.Errors;

        if (errors.length > 0) {
            for (error of errors) {
                toastSistema({
                    cabecalho: "Ocorreu um erro.",
                    descricao: error.Message,
                });
            }
        } else {
            toastSistema({
                cabecalho: "Ocorreu um erro.",
                descricao: error.message,
            });
        }
    }

    setCarregandoRequisicao(false);

    return false;
}