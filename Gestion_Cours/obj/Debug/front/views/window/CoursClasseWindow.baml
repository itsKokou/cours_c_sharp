   M S B A M L   `   `   `  ����H  DGestion_Cours, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gestion_Cours.front.views.window Gestion_Cours.front.views.window  5   	   8    2Gestion_Cours.front.views.window.CoursClasseWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Gestion_Cours.front.views.window     5   	     � Title$  CoursClasseWindow��5   	   $	��450��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�5	       � AllowsTransparency .  � WindowStyle$
 None=�5
   
   
������  � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      ��  �� CornerRadius$ 30��6   
�������
���   �$��2q�6J   $	��450��6^   $	��800��6k   ._�5   
   � -   5         �Name$ 	Container��5       � ColumnDefinitions 5      �� 5      $
��491* �6#   �� 5      $��0* �6#   �� 5      $��9* �6#   .+�5      �� -   5        $%��../../../front/images/close.png��5      $��0 14 0 0q�6=    K� ZIndex$ 1��6P     imgClose#��[ 6y   � 5      $��
30,20,4,20q�6   	 � RowDefinitions	 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$   �� 5!      $
��auto �6$   �� 5"      $��* �6$   �� 5#      $
��auto �6$   .+�5,      �� -   5        
 ��Name$
 txtTitle��5,      $��Les Classe du cours ��6.   $��1��6J   $��32(�6W   $��SemiBold"�6e   $��0 20 0 0q�6{   ���#121518$
��Left=�6�   �� 50      $��1��6   $��3��6'   ���#DAE2EA$��	0 -1 0 10q�6I   �� 55      $��
ISM, Dakar��6   $��4��6.   $��18(�6;   $��SemiBold"�6I   ���#121518$
��Left=�6t   $��Center=�6�   &   System.Windows.Controls.DataGrid  5>      -   5          Name$ dgClasse��5>   �     DataGridRowStyle1   RowStyle# �  6     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6J     DataGridCellStyle1   	CellStyle# �  6�     DataGridStyle1#���  6�      Columns 5?      4  .System.Windows.Controls.DataGridCheckBoxColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ C��61      CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6R     CheckBoxStyle11  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6_      HeaderTemplate 5A      �� 5B   "   .R�5C   &   �� #��[ 6/   5D   #   5F      0  *System.Windows.Controls.DataGridTextColumn  5G      $	 N°��6-      
IsReadOnly .  .  $
 auto 6a      Binding 6n   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ Libelle��61    . $ * 6T      CellTemplate 5I      �� 5J   "   .R�5K   &   ��  �� Orientation$ 
Horizontal=�61   .+�5L   *   �� $��Center=�6J   ��64   �� *Name+6J   5M   '   5N   #   5P        5Q      $ Niveau��6-    . $ * 6j    6=   �� *Niveau+6j     5R      $ Filiere��6-    . $ * 6l    6>   �� *	Filiere+6l     5S      $ Effectif��6-    . $ * 6n    6?   �� *
Effectif+6n   5U      �� 5X      $
��Left=�6   $��	155,4,0,0q�67   $��5��6J   $	��Top=�6W   �� 5Y      $
��Left=�6   $��	392,0,0,0q�67   $��5��6J   $	��Top=�6W   5[      5]      5^      5_      