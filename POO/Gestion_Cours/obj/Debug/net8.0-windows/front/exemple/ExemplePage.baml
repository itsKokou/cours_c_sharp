   M S B A M L   `   `   `  ����H  DGestion_Cours, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Gestion_Cours.front.exempleGestion_Cours.front.exemple  5      -    'Gestion_Cours.front.exemple.ExemplePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Gestion_Cours.front.exemple     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5	        N� Title$  
ClassePage��5      $	��720��5
      $
��1080��6    N� 
Background
 ����  � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �� -   5         �� CornerRadius$ 30��5      ���#EFF2F7._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5       ��   	topButton#��[ 6   $
��Left=�6<   $��
20 28 0 35q�6W   .��5!      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�6,   $��15��68   $��15��6C   5"      �� 5$      $��1��6   ���#409EA4$ 	0 50 0 30��6;   ._�5%      ]� .+�5'      �� $��80��6!   $��80��6,    �� Padding$ 3q�68   
�������$	 100��6W   $	��Top=�6j   $
��Left=�6   $��
20 -30 0 0q�6�   ._�5(      A� ��5)   "   �� 5*   &    �� ImageSource$ /Images/p1.jpg��61   5,      5-      �� 50      $��Kokou's World��6$   
�������$��22(�6L   $��SemiBold"�6Z   $	��Top=�6p   $��	5 25 0 10q�6�   	 �� TextAlignment$	 Center=�6�   �� 51      $��Humain, Sénégal��6$   ���#C1EDEF$��14(�6P   $��SemiBold"�6^   $	��Top=�6t   $	 Center=�6�   �� 54      $��25q�6$   ���#409EA4$	��Top=�6E   $	��0.8��6Z   �� 57      $	��Top=�6%   .+�58      ��   
menuButton#��[ 6%   .��59   "   �� 
 �� Orientation$
 
Horizontal=�6-   .+�5:   &     $ HomeVariant=�6<     menuButtonIcon#��[ 6O   �� 5;   &   $��	Dashboard��60   5<   #   5=      �� 5?      #��[ 6%   .��5@   "   �� $
 
Horizontal=�6-   .+�5A   &     $ CalendarClock=�6<   #��[ 6Q   �� 5B   &   $��Events��60   5C   #   5D      �� 5F      -   5        #��[ 5F   %   ���#4EB1B6
�������.��5G   "   �� $
 
Horizontal=�6-   .+�5H   &     $ AccountMultipleOutline=�6<   #��[ 6Z   �� 5I   &   $��Members��60   5J   #   5K      �� 5M      #��[ 6%   .��5N   "   �� $
 
Horizontal=�6-   .+�5O   &     $ CashMultiple=�6<   #��[ 6P   �� 5P   &   $��Wallet��60   5Q   #   5R      �� 5T      #��[ 6%   .��5U   "   �� $
 
Horizontal=�6-   .+�5V   &     $ ForumOutline=�6<   #��[ 6P   �� 5W   &   $��Messages��60   5X   #   5Y      5[      �� 5]      #��[ 6!   $��Bottom=�6E   $��Bottom=�6`   $��
15 0 15 20q�6x   .��5^      �� $
 
Horizontal=�6)   .+�5_   "     $ Logout=�68   #��[ 6F   �� 5`   "   $��Logout��6,   5a      5b      5d      5e      5g      � 5j      $��1��6   $��30,20,13,20q�6#    5k      �� 5l      $
��auto �6$   �� 5m      $
��auto �6$   �� 5n      $
��auto �6$   �� 5o      $
��auto �6$   �� 5p      $
��auto �6$   �� 5q      $��* �6$   �� 5r      $
��auto �6$   .+�5v      � $	��300��6   $
��Left=�6#   .+�5w      �� $
��20 0q�6    $��Center=�6.   ���#B0B9C6 J� IsHitTestVisible$ False��6^    K� ZIndex$ 1��5x      $��Search here ...��6%   y�5y      ��  �� ElementName$ textBoxSearch�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5{      -   5        $��textBoxSearch��5{        searchTextbox#��[ 63     5}      $ Magnify=�6,   $��15��6;   $��15��6F   $��Center=�6R   $��0 0 15 0q�6m   ���#B0B9C6$��Right=�6�   5~      �� 5�      #��[ 6   $��0 0 35 0q�6<   ���#dcdcdc.��5�        $	 Cog=�6,   5�      �� 5�      #��[ 6   $��0 0 70 0q�6<   .��5�        $
 Bell=�6,   5�      �� 5�      -   5        $��../../Images/close.png��5�      $��0 14 0 0q�68   $ 1��6K     imgClose#��[ 6t   �� 5�      $��Members��6   $��1��6+   $��32(�68   $��SemiBold"�6F   $��0 20 0 0q�6\   ���#121518$
��Left=�6�   �� 5�        	addButton#��[ 6   .��5�      �� $
 
Horizontal=�6!   .+�5�        $
 Plus=�60   $��Center=�6<   $��0 1 8 0q�6W   $��11��6h   $��11��6s   �� 5�      $��Add New Member��6$   5�      5�      �� 5�      $��1��6   $��3��6'   ���#DAE2EA$��	0 -1 0 10q�6I   �� 5�      $��2��6   $
 
Horizontal=�6*   $��0 10 0 0q�6C   .+�5�      ��   	tabButton#��[ 6   $��
Club staff��6@   ���#409EA46U   �� 5�      #��[ 6   $��Players��6@   �� 5�      #��[ 6   $��Archived��6@   5�      �� 5�      $��68 Club Staff��6   $��4��61   $��18(�6>   $��SemiBold"�6L   ���#121518$
��Left=�6w   $��Center=�6�   �� 5�      $��	Filter by��6   $��4��6-   $��13(�6:   $��SemiBold"�6H   $��	0 0 215 0q�6^   ���#121518$��Right=�6�   $��Center=�6�   � 5�      $	��200��6   $��Right=�6#   $��4��6?   .+�5�      �� $
��15 0q�6    $��Center=�6.   ���#B0B9C6$ False��6^   $ 1��5�      $��Search in Members ...��6%   y�5�      �� $ textBoxFilter��$ Text.IsEmpty�# [  �� 5�      -   5        $��textBoxFilter��5�        filterTextBox#��[ 63   5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ membersDataGrid��5�   �    	 DataGridRowStyle1   RowStyle# � 	 6    
 DataGridColumnHeaderStyle1   ColumnHeaderStyle# � 
 6J     DataGridCellStyle1   	CellStyle# �  6�     DataGridStyle1#���  6�      Columns 5�      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ C��61      CanUserResize$ False��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R     CheckBoxStyle11  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6_      HeaderTemplate 5�      �� 5�   "   .R�5�   &   �� #��[ 6/   5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $ #��6-      
IsReadOnly$
 True��68   $ False��6J   $
 auto 6`      Binding 6m   �� *Number+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Member��61   $
 True��6A   $ * 6S      CellTemplate 5�      �� 5�   "   .R�5�   &   �� $
 
Horizontal=�61   .+�5�   *   �� $��25��61   $��25��6<   $ 50��6H   $��0 0 10 0q�6Z   ��6l   �� *	BgColor+._�5�   .   �� $��Center=�6S   $��Center=�6n   
�������$��0 0 0 1q�6�   ��68   �� *	Character+6�   5�   +   �� 5�   *   $��Center=�6J   ��64   �� *Name+6J   5�   '   5�   #   5�        5�      $ Position��6-   $
 True��6\   $ * 6n    6?   �� *
Position+6n     5�      $ Email Address��6-   $
 True��6^   $ * 6p    6D   �� *Email+6p     5�      $ Phone Number��6-   $
 True��6]   $ * 6o    6C   �� *Phone+6o     5�      $ 
Operations��61   $
 True��6E   $
 auto 6W    5�      �� 5�   "   .R�5�   &   �� $
 
Horizontal=�61   .+�5�   *   ��   gridEditButton#��[ 61   .��5�   .     $ PencilOutline=�6D     gridButtonIcon#��[ 6Y   5�   +   �� 5�   *   $��5 0 0 0q�61     gridRemoveButton#��[ 6B   .��5�   .     $ DeleteOutline=�6D   #��[ 6Y   5�   +   5�   '   5�   #   5�      5�      �� 5�      $��6��6   $��Right=�6&   ���#DEE4EC$��1q�6X   $ 5��6l   $ 5q�6}   ���#ffffff$��
0 10 10 10q�6�   ._�5�      �� $
 
Horizontal=�6!   .+�5�      ��   pagingButton#��[ 6!   .��5�        $ ChevronLeft=�64     pagingButtonIcon#��[ 6G   5�      �� 5�      $��1��6$   ���#DEE4EC$	��3 7q�6=   �� 5�      #��[ 6!   $��1��6G   �� 5�      #��[ 6!   $��2��6G   ���#409EA4���#ffffff6h   �� 5�      #��[ 6!   $��3��6G   �� 5�      $	��...��6$   ���#6C7682$��Center=�6D   $
��10 0q�6_   $��15(�6m   �� 5�      #��[ 6!   $��7��6G   �� 5�      #��[ 6!   $��8��6G   �� 5�      #��[ 6!   $��9��6G   �� 5�      $��1��6$   ���#DEE4EC$	��3 7q�6=   �� 5�      #��[ 6!   .��5�        $ ChevronRight=�64   #��[ 6H   5�      5�      5�      5�      5�      5�      5�      