   M S B A M L   `   `   `  ����  ListBoxWithGroups1    +Petzold.ListBoxWithGroups.ListBoxWithGroups   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$  ListBox with Groups��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      ]� -   5        $
��dock��5
      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $��_Open...��6    m� Command$
 Open��6-   5      5      �� 5   
   -   5        $��lstbox��5      $��1��6    $��Center=�5      $��Center=�6/   $	��300��5      $	��300��6   $��24q�6+   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   ��  �� Path$ 	FirstName��� 5      $�� ��6$   �� 5      ��6$   �� $ 
MiddleName��� 5      $��txtblkSpace��6-   $�� ��6$   6-   �� 5      ��6$   �� $ LastName��� 5      $�� (��6$   �� 5      ��6$   �� $ BirthDate.Year��� 5      $��-��6$   �� 5       $��txtblkDeath��5!   $   ��5    $   �� $ DeathDate.Year�5!   $   �� 5"      $��)��6$   5#       �� Triggers 5$      �� 5%       �� Binding 6&   �� $ DeathDate.Year� �� Value 5&   &   Z� .a�5'      �� 	 �� 
TargetName$	 txtblkDeath��6%   
 �� Property
 � �� �� Value$ present��5(   5   5)      �� 5*      $  ��5+   &    5*   &   �� $ 
MiddleName�.a�5,      �� $	 txtblkSpace��6%   
 � ��$  ��5-   5   5.      50       �� 
GroupStyle 54      (  "System.Windows.Controls.GroupStyle  55         HeaderTemplate 56      �� 57      .R�58      �� 
�������
�������$
��Bold"�5:   (   $
��12pt(�6:   $��6q�5;   (   ��58   (   �� $
 Name�5;   (   5<      5>      5@      5A       J� CommandBindings 5C      )  #System.Windows.Input.CommandBinding  5D   
   -   5           Command$
 Open��5D      6(   5F      