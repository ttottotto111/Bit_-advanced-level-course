   M S B A M L   `   `   `  ����R  NDataEntryWithNavigation, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Petzold.CreateDatePickerPetzold.CreateDatePicker  5      M+clr-namespace:Petzold.SingleRecordDataEntryPetzold.SingleRecordDataEntry  5      /    )Petzold.SingleRecordDataEntry.PersonPanel   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      3dp&clr-namespace:Petzold.CreateDatePicker    5      9src+clr-namespace:Petzold.SingleRecordDataEntry    5        � 	Resources  5
       �� 
TargetType �� Property �� Value)   #Petzold.CreateDatePicker.DatePicker��%  '��       '�� p     '  �     �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 12q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 12q�6'   5      �� 5   
   "  6   .�5      ��  � ��$ 12q�6'   5      5       � ColumnDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6    � RowDefinitions 5      �� 5   
   $
��Auto �6   �� 5    
   $
��Auto �6   �� 5!   
   $
��Auto �6   �� 5"   
   $
��Auto �6   �� 5#   
   $
��Auto �6   .+�5&      �� $��0��6   $��0��6   $��_First Name: ��5'      �� 5)      $��0��6   $��1��6   $��12q�6+   ��5*      ��  �� Path$ 	FirstName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5.      $��1��6   $��0��6   $��_Middle Name: ��5/      �� 51      $��1��6   $��1��6   $��12q�6+   ��52      �� $ 
MiddleName�$ TwoWay=�$ PropertyChanged=��� 56      $��2��6   $��0��6   $��_Last Name: ��57      �� 59      $��2��6   $��1��6   $��12q�6+   ��5:      �� $ LastName�$ TwoWay=�$ PropertyChanged=��� 5>      $��3��6   $��0��6   $��_Birth Date: ��5?        5A      $��3��6   $��1��6!   $��12q�61   $��Center=�5B      	   Date	 5C      �� $ 	BirthDate�$ TwoWay=��� 5E      $��4��6   $��0��6   $��_Death Date: ��5F        5H      $��4��6   $��1��6!   $��12q�61   $��Center=�5I      	 5J      �� $ 	DeathDate�$ TwoWay=�5K      