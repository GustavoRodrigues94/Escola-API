using System;
using System.IO;
using Escola.Core.Utilitarios.DTOs;
using Microsoft.AspNetCore.Http;

namespace Escola.Core.Utilitarios
{
    public static class FormFileManipulador
    {
        public static FormFileDTO ObterFormFileDetalhes(IFormFile formFile)
        {
            if (formFile.Length <= 0) return null;

            var formFileDTO = new FormFileDTO
            {
                Base64Arquivo = ObterBase64(formFile),
                FormatoArquivo = ObterFormato(formFile),
                NomeArquivo = ObterNomeArquivo(formFile)
            };

            return formFileDTO;
        }

        private static string ObterNomeArquivo(IFormFile formFile) =>
            Path.GetFileNameWithoutExtension(formFile.FileName);

        private static string ObterFormato(IFormFile formFile) => Path.GetExtension(formFile.FileName);

        private static string ObterBase64(IFormFile formFile)
        {
            using var ms = new MemoryStream();
            formFile.CopyTo(ms);
            var fileBytes = ms.ToArray();
            var base64 = Convert.ToBase64String(fileBytes);
            return base64;
        }
    }
}
