//------------------------------------------------
// ControlMenuItem.cs (c) 2006 by Charles Petzold
//------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.DumpControlTemplate
{
    public class ControlMenuItem : MenuItem
    {
        public ControlMenuItem()
        {
            //Control Ŭ������ ���ǵ� ������� ����
            Assembly asbly = Assembly.GetAssembly(typeof(Control));

            // �� Ŭ���� ���� Ÿ�� ��θ� �迭�� ����
            Type[] atype = asbly.GetTypes();

            //Control�� �Ļ�Ŭ������ ���ĵ� ����Ʈ�� ����
            SortedList<string, MenuItem> sortlst = 
                                    new SortedList<string, MenuItem>();

            Header = "Control";
            Tag = typeof(Control);
            //             KEY   , Value
            sortlst.Add("Control", this);

            //�迭 ���� ��� Ÿ���� ������
            //ControlŬ������ �װ��� �Ļ� Ŭ������ ���� �޴� �׸��� ������
            //SortedList ��ü�� �߰���
            //�޴� �׸��� Tag������Ƽ�� Type ��ü�� ���õ� ������ �˾Ƶ� ��
            foreach (Type typ in atype)
            {
                if (typ.IsPublic && (typ.IsSubclassOf(typeof(Control))))
                {
                    MenuItem item = new MenuItem();
                    item.Header = typ.Name;
                    item.Tag = typ;
                    sortlst.Add(typ.Name, item);
                }
            }

            // ���ĵ� ������ ��ȸ�ϸ� �޴��� �θ� ����
            foreach (KeyValuePair<string, MenuItem> kvp in sortlst)
            {
                if (kvp.Key != "Control")
                {
                    string strParent = ((Type)kvp.Value.Tag).BaseType.Name;
                    MenuItem itemParent = sortlst[strParent];
                    itemParent.Items.Add(kvp.Value);
                }
            }

            //�ٽ� ��ȸ
            //�߻� Ŭ�����̰� ������ ���� ������ ��Ȱ��
            //�߻� Ŭ������ �ƴϰ� ������ ���� ������ �׸� �߰�
            foreach (KeyValuePair<string, MenuItem> kvp in sortlst)
            {
                Type typ = (Type)kvp.Value.Tag;

                if (typ.IsAbstract && kvp.Value.Items.Count == 0)
                    kvp.Value.IsEnabled = false;

                if (!typ.IsAbstract && kvp.Value.Items.Count > 0)
                {
                    MenuItem item = new MenuItem();
                    item.Header = kvp.Value.Header as string;
                    item.Tag = typ;
                    kvp.Value.Items.Insert(0, item);
                }
            }
        }
    }
}
