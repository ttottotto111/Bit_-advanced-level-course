   M S B A M L   `   `   `  ����  CollectionViewWithFilter?    9Petzold.CollectionViewWithFilter.CollectionViewWithFilter   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$   CollectionView with Filter��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      ]� -   5        $
��dock��5
      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $��_Open...��6    m� Command$
 Open��6-   5      5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��24q�6$   $��Center=�60   $��Criteria��5      .��5      �� .+�5      	� -   5        $��radioLiving��5   "   $��Living��65   $��6q�5   ;   	� 5      -   5        $��	radioDead��5   "   $
��Dead��63   $��6q�5   ;   	� 5      -   5        $��radioAll��5   "   $	��All��62   $��6q�5    ;   5!      5"      �� 5%      -   5        $��lstbox��5%      $��1��6$   $��Center=�61   $	��300��5&      $	��300��6"   $��24q�6/   ��5'      �� 5(      .R�5)      ��  �� Orientation$ 
Horizontal=�6%   .+�5*      �� ��6(   ��  �� Path$ 	FirstName��� 5+      $�� ��6(   �� 5,      ��6(   �� $ 
MiddleName��� 5-      $��txtblkSpace��61   $�� ��6(   61   �� 5.      ��6(   �� $ LastName��� 5/      $�� (��6(   �� 50      ��6(   �� $ BirthDate.Year��� 51      $��-��6(   �� 52      $��txtblkDeath��53   (   ��52   (   �� $ DeathDate.Year�53   (   �� 54      $��)��6(   55       �� Triggers 56      �� 57       �� Binding 6*   �� $ 	DeathDate�	 �� Value	 58   *   Z� .a�59   "   �� 
 �� 
TargetName$
 txtblkDeath��6)    �� Property � �� �� Value$ present��5:   9   5;      �� 5<      $	  ��5=   *    5<   *   �� $ 
MiddleName�.a�5>   "   �� $
 txtblkSpace��6)    � ��$  ��5?   9   5@      5B      5D      5E      5F       J� CommandBindings 5H      )  #System.Windows.Input.CommandBinding  5I   
   -   5           Command$
 Open��5I      6(   5K      