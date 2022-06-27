//--------------------------------------------------------------
// DumpContentPropertyAttributes.cs (c) 2006 by Charles Petzold
//--------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

public class DumpContentPropertyAttributes
{
    [STAThread]
    public static void Main()
    {
        // PresentationCore�� PresentationFramework�� �ε�Ǵ��� Ȯ��
        UIElement dummy1 = new UIElement();
        FrameworkElement dummy2 = new FrameworkElement();

        // ����Ʈ ������Ƽ�� Ŭ������ ������ SortedList
        SortedList<string, string> listClass = new SortedList<string, string>();

        // ���ڿ��� ������
        string strFormat = "{0,-35}{1}";

        // �ε��� ������� ��ȸ�ϴ� ����
        foreach (AssemblyName asmblyname in 
                    Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            // Ÿ�� ����
            foreach (Type type in Assembly.Load(asmblyname).GetTypes())
            {
                // Ŀ���� �Ӽ� ����
                // (��ӹ��� ���� �Ϳ� ���� false�� ���ڸ� ����)
                foreach (object obj in type.GetCustomAttributes(
                                        typeof(ContentPropertyAttribute), true))
                {
                    // ContentPropertyAttribute�̸� ����Ʈ�� �߰�
                    if (type.IsPublic && obj as ContentPropertyAttribute != null)
                        listClass.Add(type.Name,
                                      (obj as ContentPropertyAttribute).Name);
                }
            }
        }
        // ��� ���
        Console.WriteLine(strFormat, "Class", "Content Property");
        Console.WriteLine(strFormat, "-----", "----------------");

        foreach (string strClass in listClass.Keys)
            Console.WriteLine(strFormat, strClass, listClass[strClass]);
    }
}
