//-------------------------------------------------
// EllipseWithChild.cs (c) 2006 by Charles Petzold
//-------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.EncloseElementInEllipse
{
    public class EllipseWithChild : Petzold.RenderTheBetterEllipse.BetterEllipse
    {
        UIElement child;

        // Public Child ������Ƽ
        public UIElement Child
        {
            set
            {
                if (child != null)
                {
                    RemoveVisualChild(child);
                    RemoveLogicalChild(child);
                }
                if ((child = value) != null)
                {
                    AddVisualChild(child);          // �θ� - �ڽ� ���踦 ����.
                    AddLogicalChild(child);         // ������ ��ü�� �� ����� ���� Ʈ���� �߰�.
                }
            }
            get
            {
                return child;
            }
        }

        // VisualChildrenCount �������̵�. Child�� null�� �ƴϸ� 1�� ��ȯ
        protected override int VisualChildrenCount
        {
            get
            {
                return Child != null ? 1 : 0;
            }
        }

        // GetVisualChildren �������̵�. Child�� ��ȯ
        protected override Visual GetVisualChild(int index)			// �ε����� �����ϴ� �ڽ��� ��ȯ�� �� ����.
        {
            if (index > 0 || Child == null)					        // �� �޼ҵ�� null�� ��ȯ�ؼ��� �ȵȴٰ� ��������.
                throw new ArgumentOutOfRangeException("index");		// �׷��� �ε����� ����Ȯ�� ��쿡�� ���� ��Ȳ�� ������ ��.

            return Child;
        }

        // MeasureOverride �������̵�. Child�� Measure �޼ҵ带 ȣ��
        // �ڽ� Element�� �ʿ��� ũ�⸦ �����ϰ� ũ�⸦ �����Ѵ�.
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            Size sizeDesired = new Size(0, 0);					    // EllipseWithChild���� �� �޼ҵ�� ũ�Ⱑ 0�� sizeDesired ��ü�� ������ ����.

            if (Stroke != null)
            {
                sizeDesired.Width += 2 * Stroke.Thickness;			// �� �� Ÿ���� ��迡 2�� ���� ���� sizeDesired�� ���Ѵ�.
                sizeDesired.Height += 2 * Stroke.Thickness;			// ��� ��輱 ��ü�� ����ؾ� ���� �ǹ�.
                
                sizeAvailable.Width = Math.Max(0, sizeAvailable.Width - 2 * Stroke.Thickness);		// 0���� �۾������� �ʰ� ��.
                sizeAvailable.Height = Math.Max(0, sizeAvailable.Height - 2 * Stroke.Thickness);
            }

            if (Child != null)						                // Child ������Ƽ�� null�� �ƴϸ� MeasureOverride������ ����ؼ� ������
            {
                Child.Measure(sizeAvailable);				        // sizeAvailable�� ���ڷ� �ؼ� �ڽ��� Measure �޼ҵ带 ȣ��(�� �ڽ��� MeasureOverride ȣ��).
                                                                    // �θ� ��Ұ� �ڽĿ�ҿ��� sizeAvailable��ŭ ũ�⸦ �Ҵ��Ѵ�.
                                                                    // DesiredSize�� ������Ƽ�� ����ϱ� ���ؼ� MeasureOverride ��ȯ���� �̿�.

                                                                    // DesiredSize - ������Ʈ�� �ʿ��� ���̾ƿ� ũ�� Margin(����) ����
                sizeDesired.Width += Child.DesiredSize.Width;		// Measure �޼ҵ尡 DesiredSize ������Ƽ�� ������Ʈ�ϴ� å���� ����.
                sizeDesired.Height += Child.DesiredSize.Height;     // DesiredSize ������Ƽ�� �����Ͽ� �ڽĿ��� �ʿ��� ������ ����������� ����.
            }

            return sizeDesired;
        }

        // ArrangeOverride �������̵�. Child�� Arrange �޼ҵ带 ȣ��
        // �ڽĵ��� �迭 �Ѵ�.
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            if (Child != null)
            {
                Rect rect = new Rect(
                    new Point((sizeFinal.Width - Child.DesiredSize.Width) / 2,
                              (sizeFinal.Height - Child.DesiredSize.Height) / 2),
                              Child.DesiredSize);
                Child.Arrange(rect);
            }
            return sizeFinal;           // ���̾ƿ����� ��Ұ� ���ĵ� �� ���Ǵ� ���� ũ��
        }
    }
}
