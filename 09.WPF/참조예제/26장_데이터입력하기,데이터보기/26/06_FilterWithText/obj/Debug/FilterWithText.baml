   M S B A M L   `   `   `  ����  FilterWithText+    %Petzold.FilterWithText.FilterWithText   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$  Filter with Text��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      ]� -   5        $
��dock��5
      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $��_Open...��6    m� Command$
 Open��6-   5      5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��24q�6&    �� Orientation$ 
Horizontal=�62   $��Center=�5      .+�5      �� $��Search: ��6   �� 5      -   5        $��txtboxFilter��5      $	��1in��6.   5      5      �� 5       -   5        $��lstbox��5       $��1��6$   $��Center=�61   $	��300��5!      $	��300��6"   $��24q�6/   ��5"      �� 5#      .R�5$      �� $ 
Horizontal=�6%   .+�5%      �� ��6(   ��  �� Path$ 	FirstName��� 5&      $�� ��6(   �� 5'      ��6(   �� $ 
MiddleName��� 5(      $��txtblkSpace��61   $�� ��6(   61   �� 5)      ��6(   �� $ LastName��� 5*      $�� (��6(   �� 5+      ��6(   �� $ BirthDate.Year��� 5,      $��-��6(   �� 5-      $��txtblkDeath��5.   (   ��5-   (   �� $ DeathDate.Year�5.   (   �� 5/      $��)��6(   50       �� Triggers 51      �� 52       �� Binding 6*   �� $ 	DeathDate�	 �� Value	 53   *   Z� .a�54   "   �� 
 �� 
TargetName$
 txtblkDeath��6)    �� Property � �� �� Value$ present��55   9   56      �� 57      $	  ��58   *    57   *   �� $ 
MiddleName�.a�59   "   �� $
 txtblkSpace��6)    � ��$  ��5:   9   5;      5=      5?      5@      5A       J� CommandBindings 5C      )  #System.Windows.Input.CommandBinding  5D   
   -   5           Command$
 Open��5D      6(   5F      