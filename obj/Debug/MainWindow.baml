   M S B A M L   `   `   `  ����M  IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   	   ? ;DoAn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DoAnDoAn 5   	      DoAn.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:DoAn     5   	   -   5          � Title$  	Dashboard��5	   	   $	��450��6   $	��800��6(    � 	Resources 5
      $  DoAn.ByteArrayToImageConverter   	converter��%   &	          5   
   6*   5      .��5      ]� ��. $��
0,0,-0.4,0q�6%   .+�5   
      Fluent.Ribbon  $	��Top=�6   $	��117��6-   $��
0,0,-0.4,0q�6:      Tabs. 5         Fluent.RibbonTabItem     Header$ Master Data��6#      Groups. 5         Fluent.RibbonGroupBox  $��Import��6(   $��76��68   .@�5         Fluent.Button  -   5          Name$ importFromExcel��5   Q      Header$ Excel��6$   $��
5, 0, 5, 0q�6j   $
��Auto��6   $��	0,0,0,4.8q�6�      	LargeIcon 5      �� 5      $��/Images/xls.png��6$    �� BitmapScalingMode$ HighQuality=�6=   5        5      -   5        $ 	importCSV��5   1   $	 CSV��6$   $��
5, 0, 5, 0q�6D   $
��Auto��6Y   $��	0,0,0,4.8q�6g    5      �� 5      $��/Images/csv.png��6$   $ HighQuality=�6=   5      5        5      $��Action��6(   $��76��68   .@�5        -   5        $ 
addProduct��5   1   $	 Add��6$   $��
5, 0, 5, 0q�6E   $
��Auto��6Z   $��	0,0,0,5.8q�6h    5      �� 5      $��/Images/plus.png��6$   $ HighQuality=�6>   5!        5"      -   5        $ deleteProduct��5"   4   $ Delete��6$   $��
5, 0, 5, 0q�6K   $
��Auto��6`   $��	0,0,0,5.8q�6n    5#      �� 5$      $��/Images/clear.png��6$   $ HighQuality=�6?   5&        5'      -   5        $ editProduct��5'   2   $
 Edit��6$   $��
5, 0, 5, 0q�6G   $
��Auto��6\   $��	0,0,0,5.8q�6j    5(      �� 5)      $��/Images/edit.png��6$   $ HighQuality=�6>   5+      5,      5-      5.      ]� 5/   
   $	��Top=�6   .+�50      �� -   5        	 ��Name$	 categoriesComboBox��50      $	��163��63   ��51      �� 52      .R�53      �� .+�54      �� ��6(   �� *Name+55      56      58      �� 59      -   5        
 ��Name$
 searchProductTextBox��59      64   5:      ]� 5;   
   $��Bottom=�6   .+�5<      �� -	   5        $��pagingComboBox��5<      $	��100��6V   $��35��6b   6p   5=      &   System.Windows.Controls.DataGrid  5>   
   -
   5          Name$ productDataGrid��5>      5@      5A      5B      