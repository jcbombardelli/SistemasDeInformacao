﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace ParaCasa1
{
    class LivroDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BDLivros.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta() {
            try {
                conn.Open();
            }
            catch {
                Erro.setMsg("A conexão falhou!");
                return;
            }
        }

        public static void desconecta() {
            try {
                conn.Close();
            }
            catch {
                Erro.setMsg("Desconexão falhou!");
                return;
            }
        }

        public static void inseriUmLivro()
        {
            String aux = "insert into TabLivro(codigo,titulo,autor,editora,ano) values ('" 
                + Livro.getCodigo() + "','" + Livro.getTitulo() + "','" + Livro.getAutor() + "','" 
                + Livro.getEditora() + "','" + Livro.getAno() + "')";

            conecta();
            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
            desconecta();
        }

        public static void consultaUmLivro()
        {
            String aux = "select * from TabLivro where codigo ='" + Livro.getCodigo() + "'";

            conecta();
            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                Livro.setTitulo(result.GetString(1));
                Livro.setAutor(result.GetString(2));
                Livro.setEditora(result.GetString(3));
                Livro.setAno(result.GetString(4));
            }
            else
                Erro.setMsg("Livro não cadastrado.");
            desconecta();
        }


    }
}
