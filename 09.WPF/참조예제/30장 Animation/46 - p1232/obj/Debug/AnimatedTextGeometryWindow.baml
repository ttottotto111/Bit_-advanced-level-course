   M S B A M L   `   `   `  ����O  KAnimatedTextGeometry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Petzold.TextGeometryDemoPetzold.TextGeometryDemo  5   	   @    :Petzold.AnimatedTextGeometryDemo.AninmatedTextGeometryDemo   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   4src&clr-namespace:Petzold.TextGeometryDemo    5   	     � Title$   Animated TextGeometry Demo��5   	    � 	Resources 5	      +   %Petzold.TextGeometryDemo.TextGeometry   txtXaml   Text   
FontFamily   FontSize��%[   &	          5
   
   $
 XAML��6+   $ Times New Roman Bold)�5      $	 288Q�6=   5      .��5      �� .@�5   
   �� $��Runners��6   .��5      �� 
���   �.+�5      F� -   5        $��runners��5      
�������$��5��5   &    �� StrokeDashCap$ Round=�6:    �� StrokeDashArray 5      �� %  System.Windows.Media.DashStyles
   Dot �� Source# Z 	 �� Path$	 Dashes���5      �� # [  $	 Geometry�5      
 � Triggers
 5      :� 5       :� RoutedEvent$ TabItem.Loaded��6   [�5      �� 5      .��5      ��  �� 
TargetName$ runners��6)    �� TargetProperty$ StrokeDashOffset�5   )   .��5    "   W�  W� From$ 0X�62   	 W� To$ 2X�6;    g� Duration$ 0:0:1D�5!   2    g� RepeatBehavior$ Forever��5"   2   5#      5$      5&      5(      �� 5+   
   $��Chasers��6   .��5,      �� 
���   �.+�5-      F� -   5        $��chasers��5-      
�������$��5��5.   &   $	 0 3R�5/      $ Round=�6-   ��50      �� # [  $	 Geometry�52      
 54      :� 55      $ TabItem.Loaded��6   [�56      �� 57      .��58      �� $ chasers��6)   $ StrokeDashOffset�59   )   .��5:   "   U� $ 0:0:0.5D�5;   )   $ Forever��5<   )   .\�5=   &   n�  O� KeyTime$	 33%��6=    O� Value$ 1Q�5>   =   n� 5?   &   $	 66%��6=   $ 2Q�5@   =   n� 5A   &   $
 100%��6=   $ 3Q�5B   =   5C   #   5D      5E      5G      5I      �� 5L   
   $��Outline��6   .��5M      �� 
���   �.+�5N      F� 
���������5O      �� # [  $	 Geometry�F� 5Q      
���  ����5R      @� 5S      -   5        	elips�� @� RadiusX$ 3Q�5S   5    @� RadiusY$ 3Q�6A   5U      F� 5V      
���  ����5W      � 5X      .��5Y      ��  �� 
StartPoint 6+   �� # [  $	 Geometry.Bounds.TopLeft� �� EndPoint 5\   +   ��  �� ElementName$ elips��$	 Center��� 5_       6+   �� # [  $	 Geometry.Bounds.TopRight� 5b   +   �� $ elips��$	 Center��� 5e       6+   �� # [  $ 	 Geometry.Bounds.BottomLeft� 5h   +   �� $ elips��$	 Center��� 5k       6+   �� # [  $!	 Geometry.Bounds.BottomRight� 5n   +   �� $ elips��$	 Center�5q      5s      5t      
 5u      :� 5v      $ TabItem.Loaded��6   .[�5w      �� .��5x      �� $ elips��6%   $ Center�68   .��5y      )� $ 0:0:10D�5}   !   $ Forever��63    )� PathGeometry 5z   !   �� # [  $	 PathGeometry�5}   3   5~      5      5�      5�      5�      5�      