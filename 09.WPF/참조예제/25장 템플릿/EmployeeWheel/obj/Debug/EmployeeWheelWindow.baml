   M S B A M L   `   `   `  ����H  DEmployeeWheel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Petzold.CircleTheButtonsPetzold.CircleTheButtons  5   	   )    #Petzold.EmployeeWheel.EmployeeWheel   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   3rp&clr-namespace:Petzold.CircleTheButtons    5   	     � Title$  Employee Wheel��5   	    � 	Resources 5
         emps � Source � XPath��%J   &	        � 5   
   $ Employees.xml?�5      $ 	Employees��61   5      .��5      � .+�5   
   �� -   5        $��lstbox��5      $��Center=�5      $��Center=�6/    �� SelectedValuePath$
 Face��5      ��5      ��  �� Source# [   �� XPath$ Employee����5      �� 5      .R�5      *   $Petzold.CircleTheButtons.RadialPanel     Orientation$ ByHeight=�6%   5      ��5      �� 5      .R�5       ]� $��3q�6    .+�5!      �� $��Right=�6    $
��None=�67   ��5"       �� $
 Face��A� 5#       A� Rows$ 3��6&   $��Center=�6/   $��12q�5$   &   .+�5%      �� $
��16pt(�6(   	 �� TextAlignment$	 Center=�68   ��5&   (   �� $ @Name���� 5'      $
��12pt(�6(   $	 Center=�68   ��5(   (   �� $ 	BirthDate���� 5)      $��txtblkHanded��6(   $
��12pt(�5*   (   $	 Center=�68   $��Right-Handed��5+   (   5,      5-      
 �� Triggers
 50      �� 51       �� Value$
 True��52   &    �� Binding 51   &   �� $ 
LeftHanded��.a�53      ��  �� 
TargetName$ txtblkHanded��6%    �� Property � �� �� Value$ Left-Handed��54   %   55      57      59      �� 5<   
   $��Center=�6   $��Center=�6-   $
��None=�5=      ��5>      ��  �� ElementName$ lstbox�� �� Path$ SelectedValue�5?      5@      