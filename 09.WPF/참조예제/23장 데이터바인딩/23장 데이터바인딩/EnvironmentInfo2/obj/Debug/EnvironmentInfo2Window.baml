   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   K GEnvironmentInfo2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Petzold.EnvironmentInfo2Petzold.EnvironmentInfo2 5   	   � 5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   2s&clr-namespace:System;assembly=mscorlib    5   	   4src&clr-namespace:Petzold.EnvironmentInfo2    5   	     � Title$  Environment Info��5   	    � 	Resources 5	      :   4Petzold.EnvironmentInfo2.FormattedMultiTextConverter   conv��%   &	           5
   
   6*   5      .��5      �� ��5   
   `� 5       `� 	Converter# [  6    `� ConverterParameter$� �Operating System Version: {0} 
.NET Version: {1} 
Machine Name: {2} 
User Name: {3} 
User Domain Name: {4} 
System Directory: {5} 
Current Directory: {6} 
Command Line: {7}��5      .1�5      ��    System.Environment   	OSVersion �� Source# Z 6   �� 5         Version# Z 6   �� 5         MachineName# Z 6   �� 5         UserName# Z 6   �� 5      	   UserDomainName# Z	 6   �� 5      
   SystemDirectory# Z
 6   �� 5         CurrentDirectory# Z 6   �� 5          CommandLine# Z 6   5!      5#      5$      