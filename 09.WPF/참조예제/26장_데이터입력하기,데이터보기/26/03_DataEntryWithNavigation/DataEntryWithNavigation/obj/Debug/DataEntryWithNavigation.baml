   M S B A M L   `   `   `  ����R  NDataEntryWithNavigation, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Petzold.SingleRecordDataEntryPetzold.SingleRecordDataEntry  5   	   L HPetzold.DataEntry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Petzold.DataEntry;assembly=Petzold.DataEntryPetzold.DataEntry 5   	   =    7Petzold.DataEntryWithNavigation.DataEntryWithNavigation   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   9pnl+clr-namespace:Petzold.SingleRecordDataEntry    5   	   Hnav:clr-namespace:Petzold.DataEntry;assembly=Petzold.DataEntry    5   	     � Title$   Data Entry with Navigation��5	   	    � SizeToContent$ WidthAndHeight=�5
   	    � 
ResizeMode$ CanMinimize=�5   	   .��5      ]� -   5        $
��dock��5      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $
��_New��6    m� Command$	 New��6)   m� 5      $��_Open...��6   $
 Open��6-   m� 5      $��_Save...��6   $
 Save��6-   5      5      %  Petzold.DataEntry.NavigationBar  5   
   -   5        $��navbar��5      $��Bottom=�6*   /   )Petzold.SingleRecordDataEntry.PersonPanel  5   
   -   5          Name$ 	pnlPerson��5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      6'     5   
   -   5        $
 Open��5      6(     5   
   -   5        $
 Save��5      6(   5!      