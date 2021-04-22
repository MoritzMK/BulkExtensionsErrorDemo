using System.Collections.Generic;
using BulkExtensionsDemo.Models;
using EFCore.BulkExtensions;

namespace BulkExtensionsDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            InsertData();
        }

        private static void InsertData()
        {
            using (var context = new Context())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                var tableA = new TableA
                {
                    Data = "string foobar"
                };

                var tableB = new TableB()
                {
                    Description = "Description"
                };

                context.Add(tableA);
                context.Add(tableB);

                context.SaveChanges();

                var tableAToTableB = new TableAToTableB
                {
                    Id = 42,
                    TableAId = tableA.Id,
                    TableBId = tableB.Id
                };

                var bulkConfig = new BulkConfig
                {
                    BulkCopyTimeout = 240,
                    SetOutputIdentity = true,
                    PreserveInsertOrder = true,
                    BatchSize = 1000,
                    UpdateByProperties = new List<string>
                    {
                        nameof(TableAToTableB.TableAId),
                        nameof(TableAToTableB.TableBId),
                    },
                    CalculateStats = true
                };

                context.BulkUpdate(new List<TableAToTableB>{tableAToTableB}, bulkConfig);
            }
        }
    }
}
