   M S B A M L   `   `   `  ����  WPF그림판    WPF그림판.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��700��6)   .��5      � -   5        $��MainGrid��5      $
��550 ��6   $	��680��6)    � RowDefinitions 5   
   �� 5      $��36 �6   �� 5      $	��407 �6   �� 5	      $��10 �6   �� 5
      $��69 �6   �� 5      $	��28* �6    � ColumnDefinitions 5   
   �� 5      $	��114 �6   �� 5      $	��13* �6   �� 5      $
��553* �6   .+�5   
   �� -   5        $��OpenBtn��5   Z   $
��Open��6   $��36��6    $
��Left=�6,   $��	18,23,0,0q�6G   $	��Top=�6i   $��86��6�   $��2��6�   �� 5   
   -   5        $��SaveBtn��5   @   $
��Save��6   $��36��6    $��
18,29,10,0q�6,   $	��Top=�6O   $��1��6g   6t   �� 5   
   -   5        $��label1��5   r   $��색깔��6   $��2��6   $��3��6-   $��28��6:   $
��Left=�6F   $��0,0,0,8q�6a   $��Bottom=�6�   �� 5   
   -   5        $��label2��5   J   $��도형��6   $
��Left=�6   $��0,7,0,30q�68   $��2��6X   $��3��6h   �� 5   
   -   5        $��label_Shape��5   f   $�� ��6   $��2��6   $��3��6+   $
��Left=�68   $��	36,7,0,34q�6S   6f   �� 5   
   -   5        $��label_Color��5   U   $�� ��6   $��28��6   $
��Left=�6'   $��	36,33,0,0q�6B   $	��Top=�6h   $��2��6�   $��3��6�   �� 5   
   -   5        $��	groupBox1��5   h   $��1��6   $��기능��6    $	��169��6,   $
��Left=�69   $��
12,161,0,0q�6T   $	��Top=�6y   $��92��6�   .��5      �  5      �� 5      $	��35* �6'   �� 5      $	��45* �6'   .+�5      	� -	   5        $��radioBtn_Circle��5   c   $	��원��6   $��16��6*   $
��Left=�66   $��6,19,0,0q�6Q   $	��Top=�6z   6�   	� 5      -
   5        $��radioBtn_Rect��5   e   $��	사각형��6   $��16��6,   $
��Left=�68   $��6,49,0,0q�6S   $	��Top=�6z   $��2��6�   	� 5       -   5        $��radioBtn_Free��5    f   $��자유곡선��6   $��16��6-   $
��Left=�69   $��6,86,0,0q�6T   $	��Top=�6{   $��2��6�   	� 5!      -   5        $��radioBtn_Erase��5!   e   $��	지우기��6   $��16��6,   $
��Left=�68   $��6,0,0,13q�6S   $��Bottom=�6{   $��2��6�   5"      5#      �� 5$   
   -   5        $��border1��5$      
�������$��1q�6&   $��2��6:   $��1��6J   $	��405��6W   $
��Left=�6d   $	��Top=�6�   $	��558��6�   $��1,2,0,0q�6�   ._�5%      �� -   5         ��Name$ 	inkCanvas��5%       �� 
Background
 �����6+   5&      �� 5'   
   -   5        $��label_Point��5'   r   $�� ��6   $��2��6   $��4��6+   $��28��68   $
��Left=�6D   $��	448,0,0,0q�6_   $	��Top=�6�   $	��105��6�   �� 5(   
   -   5        $��	btn_Clear��5(   h   $��Clear��6   $��1��6!   $��36��6.   $
��Left=�6:   $��	19,71,0,0q�6U   $	��Top=�6y   $��85��6�   6�   �� 5*   
   -   5        $��
btn_Select��5*   \   $��색깔 선택��6   $��36��6!   $
��Left=�6-   $��
18,0,0,258q�6H   $��Bottom=�6n   $��85��6�   $��1��6�   5+      5,      