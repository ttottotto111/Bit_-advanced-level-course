//---------------------------------------------------
// NotepadClone.Print.cs (c) 2006 by Charles Petzold
//---------------------------------------------------
using Petzold.PrintWithMargins;     // for PageMarginsDialog.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Printing;

namespace Petzold.NotepadClone
{
    public partial class NotepadClone : Window
    {
        // Fields for printing.
        PrintQueue prnqueue;                        //���� ����Ͽ��� print�ڵ����ð���
        PrintTicket prntkt;                         //����ڰ� �����Ͽ��� ��������
        //����ڰ� ������ �����ߴ� print Dialog�� �ɼǵ��� �����ϴ� ��ü
        Thickness marginPage = new Thickness(96);   //������ ����


        //NotepadClone.cs �� ȣ���
        void AddPrintMenuItems(MenuItem itemFile)   //����Ʈ ���� �߰� �ϴ� �Լ�
        {
            // Page Setup menu item.
            MenuItem itemSetup = new MenuItem();    //Page Set_up �޴��� ���� ����
            itemSetup.Header = "Page Set_up...";    //Page Set_up �޴� �̸� ��Ÿ����
            itemSetup.Click += PageSetupOnClick;    //Ŭ���� PageSetupOnClick �̺�Ʈ ȣ��
            itemFile.Items.Add(itemSetup);          //�޴� ��Ͽ� �߰� �� �ش�.
            //���ڷ� ���� itemFile �Ŵ��������� ���� �Ŵ��� �ȴ�.

            // Print menu item.
            MenuItem itemPrint = new MenuItem();             //Print �޴��� ���� ����
            itemPrint.Header = "_Print...";                  //_Print �޴� �̸� ��Ÿ����
            itemPrint.Command = ApplicationCommands.Print;   //�޴� �׸� ����� ��� ��������
            itemFile.Items.Add(itemPrint);                   //�޴� ��Ͽ� �߰� �� �ش�.
            CommandBindings.Add(                             //����Ʈ ���� ���� ���̾�α׸� �����´�.
                new CommandBinding(ApplicationCommands.Print, PrintOnExecuted));
        }
        void PageSetupOnClick(object sender, RoutedEventArgs args)
        {       //PageSetupOnClick �̺�Ʈ ȣ��� �߻�
           
            PageMarginsDialog dlg = new PageMarginsDialog();                    
            //PageMarginsDialog ��ü����.

            dlg.Owner = this;                                                   
            //���� �����Ǿ� �ִ� �޸����� ������ ��´�.(ũ��, ���� �̸�, ��ġ ��)

            dlg.PageMargins = marginPage;
            //������ ������ �־��� margin ������ �� ���̾�α׿� ������.                           
            //Left ,Right ,Top, Bottom�� ���� ������ �����´�.

            if (dlg.ShowDialog().GetValueOrDefault())                           
            {       //ok�� ������...

                marginPage = dlg.PageMargins;
                //Page Setup���� ������ ������ �Է¹޾� �����´�.
                //Left, Right, Top, Bottom�� ���� ���� �������� �� marginPage�� ����
            }
        }
        void PrintOnExecuted(object sender, ExecutedRoutedEventArgs args)       
            //PrintOnExecuted �̺�Ʈ ȣ��� �߻�
        {
            PrintDialog dlg = new PrintDialog();      
            //PrintDialog ��ü����.
           
            if (prnqueue != null)         
                dlg.PrintQueue = prnqueue;
            //���� ���� �����ߴ� ������ ���ٸ�..(ó���״ٸ�) �Ѿ�� �ִٸ�
            //���� printdlg�� �־��ش�.

            if (prntkt != null) 
                dlg.PrintTicket = prntkt;
            //���� ����...  (�̰��� ���γ� ���η� �������ϴ°Ͱ� ���� �ɼ�)

            if (dlg.ShowDialog().GetValueOrDefault())                           
            {   //ok�� ������...
                //PrintDialog���� ������ ������ �Է¹޾� �����´�.              
                prnqueue = dlg.PrintQueue; 
                prntkt = dlg.PrintTicket;
                //dlg���� ����� ���� �ɼ��� ���߿� �ٽ� �� �� �ֵ���
                //�� ��ü�� �����Ѵ�.

                PlainTextDocumentPaginator paginator =                         
                    new PlainTextDocumentPaginator();
                //PlainTextDocumentPaginator ��ü ����.               
                paginator.PrintTicket = prntkt;                                 
                //������ ���� ������ �����´�.
                paginator.Text = txtbox.Text;                                   
                //������ ������ �����´�.
                paginator.Header = strLoadedFile;                               
                //������ ������ִ� ������ �����´�.
                paginator.Typeface =
                    new Typeface(txtbox.FontFamily, txtbox.FontStyle,
                                 txtbox.FontWeight, txtbox.FontStretch);
                //���� �۲ÿ� ���� ��Ÿ�ϵ��� �����ش�.  (���⼭�� ���߽�Ÿ�� ���� �ȵ�)
                paginator.FaceSize = txtbox.FontSize;                           
                //�۲� ������
                paginator.TextWrapping = txtbox.TextWrapping;                   
                //���õ� Wrapping ������ �����ش�.
                //����ڰ� ������ ��� text�� ���õ� �ΰ����� ������ paginator��ü�� �����ش�.
                paginator.Margins = marginPage;                                 
                //���� ������ �����ش�.
                paginator.PageSize = new Size(dlg.PrintableAreaWidth,           
                                              dlg.PrintableAreaHeight);
                //������ ��ü ũ�⸦ �����ش�.
                dlg.PrintDocument(paginator, Title);
                //paginator ��ü�� �̿��Ͽ� ���� ����Ʈ�� �Ѵ�.
                //�� ���������� PlainTextDocumentPaginator.cs�� �ִ� GetPage���� ���Ϲ���
                //�������� ���������ִ� �� ����.
            }
        }
    }
}
