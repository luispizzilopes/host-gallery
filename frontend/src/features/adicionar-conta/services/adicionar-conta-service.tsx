import { CadastroInterface } from "@/interfaces/CadastroInterface";
import { toastSistema } from "@/utils/toastSistema";
import apiHostGallery from "@/services/apiHostGallery";

export function validarCamposCadastro(informacoesNovaConta: CadastroInterface | null): boolean {
    if (informacoesNovaConta == null) {
        return false;
    }

    if (informacoesNovaConta.email == null ||
        informacoesNovaConta.apelido == null ||
        informacoesNovaConta.primeiroNome == null ||
        informacoesNovaConta.ultimoNome == null ||
        informacoesNovaConta.senha == null) {
        return false;
    }

    return true;
}


export async function cadastrarNovaConta(informacoesNovaConta: CadastroInterface | null): Promise<boolean> {
    if (!validarCamposCadastro(informacoesNovaConta)) {
        toastSistema({
            cabecalho: "Ocorreu um erro.",
            descricao: "Preencha todos os campos e tente novamente!",
        });

        return false; 
    }

    try {
        const resposta = await apiHostGallery
            .post("/Autenticacao/adicionar-conta", informacoesNovaConta);

        if (resposta.status === 200) {
            toastSistema({
                cabecalho: "Cadastro realizado.",
                descricao: "Seu cadastro foi realizado com sucesso! Siga os próximos passos para continuar.",
            });

            return true; 
        }
    } catch (error: Error | any) {
        toastSistema({
            cabecalho: "Ocorreu um erro.",
            descricao: error.message
        });
    }

    return false; 
}