   M S B A M L   `   `   `  ����M  ISelectDataTemplate, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Petzold.ContentTemplateDemoPetzold.ContentTemplateDemo  5   	   G(clr-namespace:Petzold.SelectDataTemplatePetzold.SelectDataTemplate  5   	   3    -Petzold.SelectDataTemplate.SelectDataTemplate   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   7emp)clr-namespace:Petzold.ContentTemplateDemo    5   	   6src(clr-namespace:Petzold.SelectDataTemplate    5   	     � Title$  Select DataTemplate��5	   	    � 	Resources 5
      9   3Petzold.SelectDataTemplate.EmployeeTemplateSelector   selectTemplate  templateRight �� Path A� Rows �� TextAlignment �� Orientation  templateLeft �� 
TargetType �� Property �� Value��%  &	        &	      &	 4    '�� T      5   
   6'   �� 5   
   .R�5      ]� .+�5      �� $��Right=�6   $
��None=�6/   ��5      �� $
 Face�A� 5      $ 2��6   $��Center=�6'   $��12q�6B   .+�5      �� $
��16pt(�6    $ Center=�60   ��5       �� $
 Name��� 5      $ 
Horizontal=�6!   $
��12pt(�5   !   .+�5      �� ��6$   �� $ BirthDate.Month��� 5      $��/��6$   �� 5      ��6$   �� $ BirthDate.Day��� 5      $��/��6$   �� 5      ��6$   �� $ BirthDate.Year�5      5      5      5      �� 5    
   .R�5!      ]� .+�5"      �� $
��Left=�6   $
��None=�6.   ��5#      �� $
 Face�A� 5$      $ 2��6   $��Center=�6'   $��12q�6B   .+�5%      �� $
��16pt(�6    $ Center=�60   ��5&       �� $
 Name��� 5'      $ 
Horizontal=�6!   $
��12pt(�5(   !   .+�5)      �� ��6$   �� $ BirthDate.Month��� 5*      $��/��6$   �� 5+      ��6$   �� $ BirthDate.Day��� 5,      $��/��6$   �� 5-      ��6$   �� $ BirthDate.Year�5.      5/      50      51      �� 53   
   " ��6   .�54      ��  � ��$ Center=�64   �� 55       � ��$ Center=�62   �� 56       � ��$ 12q�6'   57      58      .��5:      �� .+�5;   
   �� #��[  6   ��5<      *   $Petzold.ContentTemplateDemo.Employee  5=      	   Name$	 Betty��6   
   	BirthDate$
 	8/31/1970��5>         Face$ 	Betty.png��5?         
LeftHanded .  5@      5B      �� 5D   
   #��[  6   ��5E        5F      $	 Edgar��6   $
 2/2/1965��5G      $ 	Edgar.png��5H       . 5I      5K      �� 5M   
   #��[  6   ��5N        5O      $	 Sally��6   $
 	7/12/1980��5P      $ 	Sally.png��5Q       . 5R      5T      �� 5V   
   #��[  6   ��5W        5X      $		 Jim��6   $
 	6/15/1975��5Y      $ Jim.png��5Z       .  5[      5]      5^      5_      