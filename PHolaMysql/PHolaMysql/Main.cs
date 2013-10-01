using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace serpis.ad
{
	class MainClass
	{
		//Metodo sin acabar
//		private static string[] getColumNames(MySqlDataReader mySqlDataReader){
//			int numeroCol=mySqlDataReader.FieldCount; 
//			string[] columnNames = new string[numeroCol];
//			
//			int colums = mySqlDataReader.FieldCount;
//			
//			for(int i= 0; i<colums; i++){
//				columnNames.add(mySqlDataReader.GetName(i));
//				
//			}
//			
//			while(mySqlDataReader.Read()){
//				for(int i= 0; i<numeroCol; i++){			
//					columnNames.add(mySqlDataReader.GetValue(i));
//				}
//			}
//			return columnNames;
//		}
		
		public static void Main (string[] args)
		{
			string connectionString = "Server=localhost;" +
				"Database=dbprueba;" +
				"User Id=root; " +
				"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection (connectionString);
			
			mySqlConnection.Open();
			
//			Select * from categoria
			MySqlCommand mysqlCommand = mySqlConnection.CreateCommand();
			
			mysqlCommand.CommandText = "Select * from categoria";
			
			MySqlDataReader mySqlDataReader = mysqlCommand.ExecuteReader();
			
//			int colums = mySqlDataReader.FieldCount;
//			
//			for(int i= 0; i<colums; i++){
//				Console.Write(mySqlDataReader.GetName(i));
//				Console.Write("     ");
//			}
//			
//			Console.WriteLine("");
			Console.WriteLine(string.Join("  ", getColumnNames(mySqlDataReader)));
			
//			while(mySqlDataReader.Read()){
//				for(int i= 0; i<colums; i++){
//					Console.Write(mySqlDataReader.GetValue(i));
//					Console.Write("     ");
//					
//				}
//				Console.WriteLine("");
//				
//			}
//			Console.WriteLine(mySqlDataReader.GetName(1));
			
			
			mySqlDataReader.Close();
			
			mySqlConnection.Close();
			
			Console.WriteLine ("OK");
			
		}
		private static string[] getColumnNames(MySqlDataReader mySqlDataReader){
			int fieldCount = mySqlDataReader.FieldCount;
			String[] columnNames = new String[ fieldCount ];
			for(int index = 0; index < fieldCount; index ++)
					columnNames[index] = mySqlDataReader.GetName (index);
			
				return columnNames;		
	}
		private static string[] getColumnNames2(MySqlDataReader mySqlDataReader){
			int fieldCount = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string>();
			for(int index=0; index < fieldCount; index ++)
				columnNames.Add (mySqlDataReader.GetName(index));
			return columnNames.ToArray();
		}		
	}
}
