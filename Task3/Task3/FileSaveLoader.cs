// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.IO;
using Task3.Utils;

namespace Task3
{
    public static class FileSaveLoader
    {
        public static void Save<T>(T data, string filePath) where T : notnull
        {
            var bytes = data.GetBytes();

            try
            {
                File.WriteAllBytes(filePath, bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static T Load<T>(string filePath)
        {
            try
            {
                var bytes = File.ReadAllBytes(filePath);

                return (T)bytes.GetData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return default;
            }
        }
    }
}