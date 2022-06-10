﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEngegraph_Console.Database
{
    internal class TriggerContact
    {
        ClientBD client = new ClientBD("Logs");

        public void Identity()
        {
            try
            {
                BD_Connection db = new BD_Connection();
                string sql = "SET IDENTITY_INSERT Logs ON";
                SqlCommand sqlCommand = new SqlCommand(sql, db.Connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao criar tabela: " + e.Message);
            }
            
        }

        public void Create()
        {    
            string sql = "CREATE TRIGGER Historico_Contacts ON Contacts " +
                    "FOR INSERT, DELETE, UPDATE AS " +
                    "BEGIN " +
                    "INSERT INTO Logs (Id, DataModificacao, Acao) SELECT Id, DataModificacao = GETDATE(), Acao = 'INSERT' from INSERTED " +
                    "INSERT INTO Logs (Id, DataModificacao, Acao) SELECT Id, DataModificacao = GETDATE(), Acao = 'DELETE' from DELETED " +
                    //"SELECT Id, DataModificacao = GETDATE(), Acao = 'INSERT' from inserted " +
                    //"SELECT Id, DataModificacao = GETDATE(), Acao = 'DELETE' from deleted " +
                    //"SELECT Id, DataModificacao = GETDATE(), Acao = 'UPDATE' from deleted " +
                    "END;";
            Identity();
            Console.WriteLine(client.CreateTable(sql));
        }
    }
}
