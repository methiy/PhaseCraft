using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//编辑器的命名空间
using System.IO;//文件流
using Excel;//读取excel
using System.Data;



/// <summary>
/// 编辑器脚本
/// </summary>

public static class MyEditor
{
    [MenuItem("我的工具/excel转成txt")]
   public static void ExportExcelToTxt()
    {
        //_Excel文件夹路径
        string assetPath = Application.dataPath + "/_Excel";

        //获得——Excel文件夹中的Excel文件
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for(int i = 0;i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');//反斜杠替换成正斜杠
            
            //通过文件流读取文件
            using(FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                //文件流转化成Excel对象
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                //获得excel数据
                DataSet dataSet = excelDataReader.AsDataSet();

                //读取excel第一张表
                DataTable table = dataSet.Tables[0];

                //将表中的内容读取后储存到对应的TXT文件中
                readTableToTxt(files[i], table);
            }
        }

        //刷新编辑器
        AssetDatabase.Refresh();
    }

    private static void readTableToTxt(string filePath,DataTable table)
    {
        //获得文件名（不要文件后缀，生成与之名字相同的txt）
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        //txt文件储存的路径
        string path = Application.dataPath + "/resources/Data/" + fileName + ".txt";

        //判断/Resources/Data/文件夹中是否已经存在对应的txt文件，如果是，则删除
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        //文件流创建TXT文件
        using(FileStream fs = new FileStream(path, FileMode.Create))
        {
            //文件流转写入流，方便写入字符串
            using (StreamWriter sw = new StreamWriter(fs))
            {
                //遍历Table
                for(int row = 0;row < table.Rows.Count; row++)
                {
                    DataRow dataRow = table.Rows[row];

                    string str = "";
                    //遍历列
                    for(int col = 0;col < table.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();

                        str = str + val + "\t";//每一列tab分割
                    }

                    //写入
                    sw.Write(str);

                    //如果不是最后一行，换行
                    if(row != table.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }

    }
}
