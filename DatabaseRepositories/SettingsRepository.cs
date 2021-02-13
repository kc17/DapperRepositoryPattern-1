﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureLibraryModel.Repositories.DatabaseRepositories
{
    public class SettingsRepository : DatabaseRepository<Model.Settings.Settings>, ISettingsRepository
    {
        public SettingsRepository() : base("Settings")
        {

        }

        public async Task<Model.Settings.Settings> GetByUserId(Guid id)
        {
            using(var conn = GetConnection())
            {
                var list = (await conn.QueryAsync<Model.Settings.Settings>($"SELECT * FROM {_tableName} WHERE UserId=@Id", new { Id = id })).ToList();

                if (list.Any()) return list[0];
                else return null;
            }
        }
    }
}
