   M S B A M L   `   `   `  ����W  SWPFResourceDictionaryLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:WPFResourceDictionaryLibrary;assembly=WPFResourceDictionaryLibraryWPFResourceDictionaryLibrary  5       WPFControls   WPFControls.ObjectEditor   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `resPclr-namespace:WPFResourceDictionaryLibrary;assembly=WPFResourceDictionaryLibrary     5      -   5        $��	objEditor��5
      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $��29 �6   �� 5      $��29 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��29 �6   .+�5   
   �� -   5         ��Name$ txtBlockTitle��5      $��5q�5      
���   �$
��Bold"�5      $��Center=�5      ��5      ��  �� ElementName$ 	objEditor�� �� Path$ ObjectTitle�5      �� 5   
   -   5        $��	btnSearch��5      $��1��5      $��搜索��5      $��0,4,85,4q�5      $��Right=�5      $��75��5      6    �� 5    
   -   5        $��btnAdd��5       $��1��5!      $��添加��5"      $��Right=�5#      $��0,4,5,4q�5$      $��75��5%      6    �� 5&   
   -   5        $��cmbBoxObjects��5&      $��1��5'      $��	5,4,165,4q�5(      $��21��5)      $��Center=�5*       �� 
IsEditable . 5+      �� 5,   
   -   5        $��	btnDelete��5,      $��删除选中项��5-      $��Right=�5/      $��0,3,5,4q�50      $��4��51      $��75��52      y�5.      �� $ 	objEditor��$ CheckBoxVisibility�53      �� 54   
   -   5        $��ltBoxObject��54      $��Stretch=�55       J� SnapsToDevicePixels . $��1,1,0,1q�57      $��0q�58      $��3��59      2   ,WPFResourceDictionaryLibrary.CustomResources$   ExpandListBoxItemDataTemplate#���  5;      ��5:      �� $ 	objEditor��$ BoxBackground�5<      � 5=   
   -   5        $��grdEdit��5=      $��2��6   $��0q�6+   
�������$y�	Collapsed=�6I     5>      �� 5?      �� 5@      �� 5A       � ColumnDefinitions 5C      �� 5D      $��60 �6#   �� 5E      .+�5G      �� -	   5        $��txtBlock��5G      $��值：��5H      $��5q�5I      $	��Top=�5J      �� 5K      -
   5        $��txtBox��5K      $��1��5L      $��5,5,5,5q�5M      �� 5N      -   5        $��txtBlockDescription��5N      $��1��5O      $��5q�5P      $��	描述：��5Q      $	��Top=�5R      �� 5S      -   5        $��txtBoxDescription��5S      $��1��5T      $��1��5U      $��5,5,5,5q�5V       �� TextWrapping$
 Wrap=�5W      "	 �� VerticalScrollBarVisibility$
	 Auto=�5X      $��44��5Y      �� 5Z      -   5        $��btnOK��5Z      $��22��5[      $��确定��5\      $��Right=�5]      $��3q�5^      $��2��5_      $��1��5`      5a      5b      5c      5d      