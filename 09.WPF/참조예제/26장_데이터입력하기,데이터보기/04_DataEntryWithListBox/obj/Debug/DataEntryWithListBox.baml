   M S B A M L   `   `   `  ����R  NDataEntryWithNavigation, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Petzold.SingleRecordDataEntryPetzold.SingleRecordDataEntry  5   	   7    1Petzold.DataEntryWithListBox.DataEntryWithListBox   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   9pnl+clr-namespace:Petzold.SingleRecordDataEntry    5   	     � Title$  Data Entry With ListBox��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   .��5      ]� -   5        $
��dock��5      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $
��_New��6    m� Command$	 New��6)   m� 5      $��_Open...��6   $
 Open��6-   m� 5      $��_Save...��6   $
 Save��6-   5      5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5       �� -   5        $��lstbox��5       $��0��6$   $	��300��5!      $	��300��6"   $��24q�6/   ��5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6%   .+�5%      �� ��6(   ��  �� Path$ 	FirstName��� 5&      $�� ��6(   �� 5'      ��6(   �� $ 
MiddleName��� 5(      $��txtblkSpace��61   $�� ��6(   61   �� 5)      ��6(   �� $ LastName��� 5*      $�� (��6(   �� 5+      ��6(   �� $ BirthDate.Year��� 5,      $��-��6(   �� 5-      $��txtblkDeath��5.   (   ��5-   (   �� $ DeathDate.Year�5.   (   �� 5/      $��)��6(   50       �� Triggers 52      �� 53      	 �� Binding	 6*   �� $ 	DeathDate�
 �� Value
 54   *   Z� .a�55   "   ��  �� 
TargetName$ txtblkDeath��6)    �� Property � �� �� Value$ present��56   9   57      �� 58      $
  ��59   *   	 58   *   �� $ 
MiddleName�.a�5:   "   �� $ txtblkSpace��6)    � ��$  ��5;   9   5<      5>      5@      /   )Petzold.SingleRecordDataEntry.PersonPanel  5C      -   5          Name$ 	pnlPerson��5C      $��1��61   �� 5F      $ 
Horizontal=�6   $��1��62   $��1��6?   .+�5G      �� -   5        $��12q�5G      .��68   신규데이터추가5I      �� 5J      -   5        $��12q�5J      .��6;   데이터아이템삭제5L      5M      5N      5O       J� CommandBindings 5Q      )  #System.Windows.Input.CommandBinding  5R   
   -   5           Command$	 New��5R      6'     5S   
   -   5        $
 Open��5S      6(     5T   
   -   5        $
 Save��5T      6(   5V      