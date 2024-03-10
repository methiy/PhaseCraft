using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//�༭���������ռ�
using System.IO;//�ļ���
using Excel;//��ȡexcel
using System.Data;



/// <summary>
/// �༭���ű�
/// </summary>

public static class MyEditor
{
    [MenuItem("�ҵĹ���/excelת��txt")]
   public static void ExportExcelToTxt()
    {
        //_Excel�ļ���·��
        string assetPath = Application.dataPath + "/_Excel";

        //��á���Excel�ļ����е�Excel�ļ�
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for(int i = 0;i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');//��б���滻����б��
            
            //ͨ���ļ�����ȡ�ļ�
            using(FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                //�ļ���ת����Excel����
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                //���excel����
                DataSet dataSet = excelDataReader.AsDataSet();

                //��ȡexcel��һ�ű�
                DataTable table = dataSet.Tables[0];

                //�����е����ݶ�ȡ�󴢴浽��Ӧ��TXT�ļ���
                readTableToTxt(files[i], table);
            }
        }

        //ˢ�±༭��
        AssetDatabase.Refresh();
    }

    private static void readTableToTxt(string filePath,DataTable table)
    {
        //����ļ�������Ҫ�ļ���׺��������֮������ͬ��txt��
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        //txt�ļ������·��
        string path = Application.dataPath + "/resources/Data/" + fileName + ".txt";

        //�ж�/Resources/Data/�ļ������Ƿ��Ѿ����ڶ�Ӧ��txt�ļ�������ǣ���ɾ��
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        //�ļ�������TXT�ļ�
        using(FileStream fs = new FileStream(path, FileMode.Create))
        {
            //�ļ���תд����������д���ַ���
            using (StreamWriter sw = new StreamWriter(fs))
            {
                //����Table
                for(int row = 0;row < table.Rows.Count; row++)
                {
                    DataRow dataRow = table.Rows[row];

                    string str = "";
                    //������
                    for(int col = 0;col < table.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();

                        str = str + val + "\t";//ÿһ��tab�ָ�
                    }

                    //д��
                    sw.Write(str);

                    //����������һ�У�����
                    if(row != table.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }

    }
}
