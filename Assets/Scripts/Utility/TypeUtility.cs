using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class TypeUtility
    {
        public static string ReturnFilePathByType(Type type)
        {
            string[] strs = type.Module.FullyQualifiedName.Split('\\');

            string directoryPath = "";

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i] != "Library") directoryPath += strs[i] + '\\';
                else break;
            }

            directoryPath += "Assets";

            var files = Directory.GetFiles(directoryPath, type.Name + ".cs", SearchOption.AllDirectories);

            return files[0];
        }
    }
}
