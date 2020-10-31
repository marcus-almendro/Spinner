using Dapper;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Spinner.Infrastructure
{
    public static class TempDbFactory
    {
        private const string DB = "temp.sqlite";

        public static SQLiteConnection CreateConnection()
        {
            var con = new SQLiteConnection("Data Source=" + DB);
            con.Open();
            con.Trace += (s, e) => Debug.WriteLine(e.Statement);
            return con;
        }

        public static void CreateDatabase()
        {
            if (File.Exists(DB))
                File.Delete(DB);

            using (var cnn = CreateConnection())
            {
                cnn.Execute(
                    @"create table Produto
                    (
                        Id                  int not null primary key,
                        Nome                varchar(100) not null,
                        Estoque             int not null
                    )");
                cnn.Execute(
                    @"create table NotaFiscal
                    (
                        Id           uniqueidentifier primary key,
                        CNPJ         int not null,
                        Empresa      varchar(100) not null
                    )");
                cnn.Execute(
                    @"create table NotaFiscalLinhas
                    (
                        IdNotaFiscal            uniqueidentifier not null,
                        NumeroLinha             int not null,
                        IdProduto               int not null,
                        Quantidade              int not null,
                        Preco                   float not null,
                        PRIMARY KEY (IdNotaFiscal, NumeroLinha),
                        FOREIGN KEY(IdNotaFiscal) REFERENCES NotaFiscal(Id),
                        FOREIGN KEY(IdProduto) REFERENCES Produto(Id)
                    )");
                cnn.Execute(
                    @"create table Eventos
                    (
                        CreationDate  date not null,
                        EventType     varchar(100) not null,
                        Blob          text not null
                    )");
            }
        }
    }
}
