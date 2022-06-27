//-----------------------------------------------------------
// PlainTextDocumentPaginator.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------------

/*************************************************************************************
 Ŭ������ : PlainTextDocumentPaginator 
 ��      �� : 
	char[] charsBreak
        string txt					// �μ��� ���� ������
	string txtHeader				// �۲� ���õ� �йи�(�۲��� �β�, 
	Typeface face				        // �۲� ���õ� �йи�(�۲��� �β�,							//��Ÿ�� �� ���̱� ����� �����մ�.)

	double em	                                // ��Ʈ ������
        Size sizePage					// �μ� ������
        Size sizeMax					// �ִ� ������
        Thickness margins			        // �μ� ����
        PrintTicket prntkt			        // �μ� �۾��� ���� Ŭ����
        TextWrapping txtwrap			        // �ؽ�Ʈ �� �ٲ� ���

        
        List<DocumentPage> listPages;			// DocumentPage ��ü�� �� �������� ����.

 ��      �� : �μ⿡ �ʿ��� ��� ���� �� ����.
**************************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Petzold.NotepadClone
{
    public class PlainTextDocumentPaginator : DocumentPaginator
    {
        // Private fields, including those associated with public properties.
        char[] charsBreak = new char[] { ' ', '-' };
        string txt = "";                                // �μ��� ���� ������
        string txtHeader = null;
        Typeface face = new Typeface("");               // �۲� ���õ� �йи�(�۲��� �β�, 								//��Ÿ�� �� ���̱� ����� �����մ�.)

        double em = 11;                                 // ��Ʈ ������
        Size sizePage = new Size(8.5 * 96, 11 * 96);    // �μ� ������
        Size sizeMax = new Size(0, 0);
        Thickness margins = new Thickness(96);          // �μ� ����
        PrintTicket prntkt = new PrintTicket();         // �μ� �۾��� ���� Ŭ����
        TextWrapping txtwrap = TextWrapping.Wrap;       // �ؽ�Ʈ �� �ٲ� ���

        // DocumentPage ��ü�� �� �������� ����.
        List<DocumentPage> listPages;

        // Public properties.
        public string Text 
        {
            set { txt = value; }
            get { return txt; }
        }
        public TextWrapping TextWrapping
        {
            set { txtwrap = value; }
            get { return txtwrap; }
        }
        public Thickness Margins
        {
            set { margins = value; }
            get { return margins; }
        }
        public Typeface Typeface
        {
            set { face = value; }
            get { return face; }
        }
        public double FaceSize
        {
            set { em = value; }
            get { return em; }
        }
//      PrintTicket ��ü�� PrintTicket ������� Ư�� ������ XML ������ ����ϱ� ���� ǥ���� ���Դϴ�. 
//      PrintTicket ������ ��� �μ�, �� �ξ� �μ�, �������ø� �� �������� �پ��� ����� �����ϴ� ����� �����Ϳ� �����ϴ� ��� �����Դϴ�     
        public PrintTicket PrintTicket
        {
            set { prntkt = value; }
            get { return prntkt; }
        }
        public string Header
        {
            set { txtHeader = value; }
            get { return txtHeader; }
        }

        // Required overrides.
        //�Ļ� Ŭ�������� �����ǵǴ� ��� 
        // PageCount�� �� ������ ������ ���θ� ��Ÿ���� ���� �����ɴϴ�
        public override bool IsPageCountValid
        {
            get 
            {
                if (listPages == null)
                    Format();

                return true; 
            }
        }
        //�Ļ� Ŭ�������� �����ǵǴ� ��� ���� ������ ������ ������ ���� �����ɴϴ�.
        public override int PageCount
        {
            get 
            {
                if (listPages == null)
                    return 0;

                return listPages.Count; 
            }
        }
        public override Size PageSize
        {
            set { sizePage = value; }
            get { return sizePage; }
        }

        //������ �����ڿ� ���� ������ ���� �������� ��Ÿ���ϴ�
        public override DocumentPage GetPage(int numPage)
        {
            return listPages[numPage];
        }

        //�Ļ� Ŭ�������� �����ǵǴ� ��� ������ ������ �ű�⸦ �����ϴ� ��ü�� �����ɴϴ�.
        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }

        // �μ��� �� �ؽ�Ʈ �� ���� �������� �˷��ִ� 
	// ȭ��ǥ�� ǥ���ϴ� ���� Ŭ����
        class PrintLine
        {
            public string String;
            public bool Flag;

            public PrintLine(string str, bool flag)
            {
                String = str;
                Flag = flag;
            }
        }

        // ��ü ������ �������� ������.
        void Format()
        {
            // LinewWithFlag ��ü�� ������ �� ���� ����
            List<PrintLine> listLines = new List<PrintLine>();

            // �� ���� �⺻���� ��꿡 �̸� �̿�
            FormattedText formtxtSample = GetFormattedText("W");

            // �μ�Ǵ� ���� ��
            double width = PageSize.Width - Margins.Left - Margins.Right;

            // �ɰ��� ���� : �۾����� -> �μ⹮���� ����������� Ŭ��
            if (width < formtxtSample.Width)
                return;

            string strLine;
            Pen pn = new Pen(Brushes.Black, 2);
            StringReader reader = new StringReader(txt);

            // listLines�� �� ���� �����ϱ� ���� ProcessLine�� ȣ��.
            while (null != (strLine = reader.ReadLine()))
                ProcessLine(strLine, width, listLines);

            reader.Close();

            // �������� �μ��� �غ� ����.
            double heightLine = formtxtSample.LineHeight + formtxtSample.Height;
            double height = PageSize.Height - Margins.Top - Margins.Bottom;
            int linesPerPage = (int)(height / heightLine);

            // Serious problem: Abandon ship.   // �μ��� ������ ������ ������
            if (linesPerPage < 1)
                return;

            int numPages = (listLines.Count + linesPerPage - 1) / linesPerPage;// �μ��� ������ ��
            double xStart = Margins.Left;
            double yStart = Margins.Top;

            // DocumentPage.
            listPages = new List<DocumentPage>();
            
            for (int iPage = 0, iLine = 0; iPage < numPages; iPage++)
            {
                // DrawingVisual ��ü�� ������ Drawing Context�� ����.
                // DrawingVisual class
                // DrawingVisual�� ȭ�鿡�� ���� �׷����� �������ϴ� �� 
                //  ����� �� �ִ� �ð��� ��ü�Դϴ�. ������ �ý��ۿ��� �����˴ϴ�. 

                DrawingVisual vis = new DrawingVisual();

                //DrawingContext class
                //�׸���, Ǫ�� �� �� ����� ����Ͽ� ǥ�� ������ �����մϴ�
                DrawingContext dc = vis.RenderOpen();

                // ������ ��ܿ� ����� ���.
                if (Header != null && Header.Length > 0)
                {
                    FormattedText formtxt = GetFormattedText(Header);
                    formtxt.SetFontWeight(FontWeights.Bold);
                    Point ptText = new Point(xStart, yStart - 2 * formtxt.Height);
                    dc.DrawText(formtxt, ptText);
                } 

                // ������ �ϴܿ� ������ ���.
                if (numPages > 1)
                {
                    FormattedText formtxt = 
                        GetFormattedText("Page " + (iPage+1) + " of " + numPages);
                    formtxt.SetFontWeight(FontWeights.Bold);
                    Point ptText = new Point(
                        (PageSize.Width + Margins.Left - 
                                            Margins.Right - formtxt.Width) / 2,
                        PageSize.Height - Margins.Bottom + formtxt.Height);
                    dc.DrawText(formtxt, ptText);
                }

                // ���������� �� �ٿ� ���� ó��.
                for (int i = 0; i < linesPerPage; i++, iLine++)
                {
                    if (iLine == listLines.Count)
                        break;

                    // ���� �ؽ�Ʈ�� �����ֱ� ���� ������ ����.
                    string str = listLines[iLine].String;
                    FormattedText formtxt = GetFormattedText(str);
                    Point ptText = new Point(xStart, yStart + i * heightLine); 
                    dc.DrawText(formtxt, ptText);

                    // ���� ȭ��ǥ �÷��� ���.
                    if (listLines[iLine].Flag)
                    {
                        double x = xStart + width + 6;
                        double y = yStart + i * heightLine + formtxt.Baseline;
                        double len = face.CapsHeight * em;
                        dc.DrawLine(pn, new Point(x, y), 
                                        new Point(x + len, y - len));
                        dc.DrawLine(pn, new Point(x, y), 
                                        new Point(x, y - len / 2));
                        dc.DrawLine(pn, new Point(x, y), 
                                        new Point(x + len / 2, y));
                    }
                }
                dc.Close();

                // Visual ����� Document Page ��ü�� ����.
                //������ �����ڿ� ���� ������ ���� �������� ��Ÿ���ϴ�. 
                DocumentPage page = new DocumentPage(vis);
                listPages.Add(page);
            }
            reader.Close();
        }

        // �ؽ�Ʈ�� �� �ٿ� ���� ���� �ٷ� �̷���� �ؽ�Ʈ�� ó��
        void ProcessLine(string str, double width, List<PrintLine> list)
        {
            str = str.TrimEnd(' ');

            // TextWrapping == TextWrapping.NoWrap.
            // ------------------------------------
            if (TextWrapping == TextWrapping.NoWrap)
            {
                do
                {
                    int length = str.Length;

                    while (GetFormattedText(str.Substring(0, length)).Width > 
                                                                        width)
                        length--;

                    list.Add(new PrintLine(str.Substring(0, length), 
                                                    length < str.Length));
                    // �ι� ���ڿ��� �˻��մϴ�.
                    str = str.Substring(length);
                }
                while (str.Length > 0);
            }
            // TextWrapping == TextWrapping.Wrap or TextWrapping.WrapWithOverflow.
            // -------------------------------------------------------------------
            else 
            {
                do
                {
                    int length = str.Length;
                    bool flag = false;

                    while (GetFormattedText(str.Substring(0, length)).Width > width)
                    {
                        int index = str.LastIndexOfAny(charsBreak, length - 2);

                        if (index != -1)
                            length = index + 1; // Include trailing space or dash.
                        else
                        {
                            // At this point, we know that the next possible 
                            //  space or dash break is beyond the allowable 
                            //  width. Check if there's *any* space or dash break.
                            index = str.IndexOfAny(charsBreak);

                            if (index != -1)
                                length = index + 1;

                            // If TextWrapping.WrapWithOverflow, just display the
                            //  line. If TextWrapping.Wrap, break it with a flag.
                            if (TextWrapping == TextWrapping.Wrap)
                            {
                                while (GetFormattedText(str.Substring(0, length)).
                                                                    Width > width)
                                    length--;

                                flag = true;
                            }
                            break;  // out of while loop.
                        }
                    }

                    list.Add(new PrintLine(str.Substring(0, length), flag));
                    str = str.Substring(length);
                }
                while (str.Length > 0);
            }
        }
        // FormattedText ��ü�� ����
        FormattedText GetFormattedText(string str)
        {
            // FormattedText class
            //Windows Presentation Foundation (WPF)
            //���� ���α׷����� �ؽ�Ʈ�� �׸��� ���� ���� ���� ��Ʈ���� �����մϴ�
            return new FormattedText(str, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, face, em, Brushes.Black);
            // �Ķ����
            // 1. ������ �ؽ�Ʈ
            // 2. CultureInfo ==>
            //              culture �̸�, ���� �ý���, ���� �޷�, ��¥ ���� ���� �� ���ڿ� ���� ��� �� Ư�� culture�� ���� ������ �����մϴ�.
            // 3. ��ü ==> �ؽ�Ʈ �� UI ����� ������ �帧 ������ �����ϴ� ���
            // 4. �۲�
            // 5. �۲� ũ��
            // 6. �귯�� ����
        }
    }
}
