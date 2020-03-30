﻿using Models.Admin.Json;
using Models.Admin.Json.Outputs;
using Models.Admin.ModelView;
using Models.Admin.Outputs;
using Models.Admin.Outputs.HttpResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin.Interfaces
{
    public interface IUsuarioBLL
    {
        Task<IList<UsuarioJsonResult>> ListarUsuariosJson();
        Task<bool> UnlockLockUser(string email);
        Task<bool> UnlockLockUserById(int userId);
        Task<HttpResponse> EfetuarLogin(UserModelView user);

        Task<HttpResponse> CriarUsuario(UserModelView registerUser);

        Task<bool> ExcluirUsuario(UserModelView registerUser);
    }
}
