   M S B A M L   `   `   `  ����O  KMultiRecordDataEntry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Petzold.SingleRecordDataEntryPetzold.SingleRecordDataEntry  5   	   7    1Petzold.MultiRecordDataEntry.MultiRecordDataEntry   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   9pnl+clr-namespace:Petzold.SingleRecordDataEntry    5   	     � Title$  Multi-Record Data Entry��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   .��5      ]� -   5        $
��dock��5      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $
��_New��6    m� Command$	 New��6)   m� 5      $��_Open...��6   $
 Open��6-   m� 5      $��_Save...��6   $
 Save��6-   5      5      �� 5   
   .+�5      /   )Petzold.SingleRecordDataEntry.PersonPanel  -   5          Name$ 	pnlPerson��5      A� 5       A� Columns$ 6��6   $��Center=�6&    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%Q   '��       �� 5      " ��6   .�5      ��  � ��$	 6q�63   5      5      .+�5      �� -   5        $��btnFirst��5      $��처음��6)   66   �� 5       -   5        $��btnPrev��5       $��이전��6(   65   �� 5!      -   5        $��btnNext��5!      $��다음��6(   65   �� 5"      -   5        $��btnLast��5"      $��	마지막��6(   66   �� 5#      -   5        $��btnAdd��5#      $��데이터추가��6'   67   �� 5$      -   5        $��btnDel��5$      $��데이터삭제��6'   67   5%      5&      5'      
 J� CommandBindings
 5)      )  #System.Windows.Input.CommandBinding  5*   
   -	   5           Command$	 New��5*      6'     5+   
   -
   5        $
 Open��5+      6(     5,   
   -   5        $
 Save��5,      6(   5.      