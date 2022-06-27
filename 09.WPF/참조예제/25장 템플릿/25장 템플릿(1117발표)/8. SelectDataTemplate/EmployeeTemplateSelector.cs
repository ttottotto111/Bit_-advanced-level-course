//---------------------------------------------------------
// EmployeeTemplateSelector.cs (c) 2006 by Charles Petzold
//---------------------------------------------------------
using Petzold.ContentTemplateDemo;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.SelectDataTemplate
{   
    //����Ʈ Ÿ�Կ� ���� ����Ʈ�� �پ��� ���·� �����ִ� ���
    //ContentControl���� ���ǵ� ContentTemplateSelector�� ��� ���
    //1. DataTemplateSelector�� ���    
    public class EmployeeTemplateSelector : DataTemplateSelector
    {
        //2. SelectTemplate�� �������̵�
        
        public override DataTemplate SelectTemplate(object item, 
                                                    DependencyObject container)
        {
            //2-1. SelectTemplate�޼ҵ��� ù��° ���ڴ� ContentControl�� ������ ��ü
            //2-2. �ι�° ���ڴ� ContentPresenterŸ��
            Employee emp = item as Employee;
            FrameworkElement el = container as FrameworkElement;

            return (DataTemplate) el.FindResource(
                emp.LeftHanded ? "templateLeft" : "templateRight");
        }
    }
}
