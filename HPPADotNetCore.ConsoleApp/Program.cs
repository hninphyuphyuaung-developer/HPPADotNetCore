﻿// See https://aka.ms/new-console-template for more information
using HPPADotNetCore.ConsoleApp.AdoDotNetExamples;
using HPPADotNetCore.ConsoleApp.DapperExamples;
using HPPADotNetCore.ConsoleApp.EFCoreExamples;
using HPPADotNetCore.ConsoleApp.HttpClientExamples;
using HPPADotNetCore.ConsoleApp.HttpClientExamples1;
using HPPADotNetCore.ConsoleApp.RefitExamples;
using HPPADotNetCore.ConsoleApp.RefitExamples1;
using HPPADotNetCore.ConsoleApp.RestClientExamples;
using HPPADotNetCore.ConsoleApp.RestClientExamples1;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder() 
//{ 
//    DataSource = ".",
//    InitialCatalog = "HppaDotNetCore",
//    UserID = "sa",
//    Password = "sa@123",
//    TrustServerCertificate = true
//};
//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//Console.WriteLine("connection opening");
//sqlConnection.Open();
//Console.WriteLine("connection opened");

//string query = "select * from Tbl_Family";
//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//Console.WriteLine("connection closing");
//sqlConnection.Close();
//Console.WriteLine("connection closed");

////DataSet
////DataTable
////DataRow
////DataColumn

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["FamilyId"]);
//    Console.WriteLine(dr["ParentName"]);
//    Console.WriteLine(dr["SonName"]);
//    Console.WriteLine(dr["DaughterName"]);
//    Console.WriteLine("___________________________");
//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Run();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();  
//eFCoreExample.Run();

Console.WriteLine("Waiting Api");
Console.ReadKey();
//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

RestClientExample1 restClientExample1 = new RestClientExample1();
await restClientExample1.Run();

//RefitExample refitExample = new RefitExample();
//await refitExample.Run();

RefitExamples1 refitExamples1 = new RefitExamples1();
await refitExamples1.Run();

//HttpClientExample1 httpClientExample1 = new HttpClientExample1();
//await httpClientExample1.Run();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

Console.WriteLine("Press enter to continue");
Console.ReadKey();

