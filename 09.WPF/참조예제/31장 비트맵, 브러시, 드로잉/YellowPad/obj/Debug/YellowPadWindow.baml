   M S B A M L   `   `   `  ����D  @YellowPad, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Petzold.YellowPadPetzold.YellowPad  5   	   '    !Petzold.YellowPad.YellowPadWindow   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   -srcclr-namespace:Petzold.YellowPad    5   	     � Title$  
Yellow Pad��5   	    � SizeToContent$ WidthAndHeight=�5	   	   .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $
��_New��6    m� Command$	 New��6)   m� 5      $��_Open...��6   $
 Open��6-   m� 5      $��_Save...��6   $
 Save��6-   �� 5      m� 5      $��E_xit��6   $ Close��6*   5      m� 5      -   5        $��_Edit��5      .@�5      m� $
��Cu_t��6   $	 Cut��6)   m� 5      $��_Copy��6   $
 Copy��6*   m� 5      $��_Paste��6   $ Paste��6+   m� 5      $��_Delete��6   $ Delete��6,   �� 5      m� 5      $��Select _All��6   $ 	SelectAll��60   m� 5      -   5        $��
itemFormat��5   9   $��_Format Selection...��6   5       5!      m� 5$      -   5        $��_Stylus-Mode��5$      .@�5%      m� -   5        $
��_Ink��5%      2  ,System.Windows.Controls.InkCanvasEditingMode
   Ink
 � Tag# Z 5&      m� 5'      -   5        $��Erase by _Point��5'         EraseByPoint# Z 5(      m� 5)      -   5        $��_Erase by Stroke��5)         EraseByStroke# Z 5*      m� 5+      -   5        $��_Select��5+         Select# Z 5,      5-      m� 50      -   5        $��menuEraserMode��51      $��E_raser-Mode��50      .@�52      m� -	   5        $
��_Ink��52      # Z 53      m� 54      -
   5        $��Erase by _Point��54      # Z 55      m� 56      -   5        $��_Erase by Stroke��56      # Z 57      m� 58      -   5        $��_Select��58      # Z 59      5:      m� 5=      $��_Tools��6   .@�5>      m� -   5        $��
_Stylus...��5>      6/   m� 5?      -   5        $��
_Eraser...��5?      6/   5@      m� 5C      $��_Help��6   .@�5D      m� $��_Help...��6   $
 Help��6-   m� 5E      -   5        $��_About YellowPad...��5E      68   5F      5G      �� 5J   
   $
��Auto=�6   .��5K      �� -   5        $��inkcanv��5K      '   !Petzold.YellowPad.YellowPadWindow   widthCanvas#��Z 5L      	   heightCanvas#��Z	 5M      
 �� 
Background

 �����.H�5O      �� 
���  ��	 �� X1$ 0.875in��6$   	 �� Y1$ 0��61   	 �� X2$ 0.875in��68   	 �� Y2# Z	 5P      �� 5Q      
���  ��$ 0.9375in��6$   $ 0��62   $ 0.9375in��69   # Z	 5R      5S      5T      5U       J� CommandBindings 5X      )  #System.Windows.Input.CommandBinding  5Y   
   -   5           Command$	 New��5Y      6'     5Z   
   -   5        $
 Open��5Z      6(     5[   
   -   5        $
 Save��5[      6(     5\   
   -   5        $ Close��5\      6)     5]   
   -   5        $	 Cut��5]      5^        5_   
   -   5        $
 Copy��5_      5`        5a   
   -   5        $ Paste��5a      5b        5c   
   -   5        $ Delete��5c      5d        5e   
   -   5        $ 	SelectAll��5e      6-     5f   
   -   5        $
 Help��5f      6(   5h      