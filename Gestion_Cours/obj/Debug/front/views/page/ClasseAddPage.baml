   M S B A M L   `   `   `  ����H  DGestion_Cours, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Gestion_Cours.front.views.pageGestion_Cours.front.views.page  5      2    ,Gestion_Cours.front.views.page.ClasseAddPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Gestion_Cours.front.views.page     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5	        N� Title$  ClasseAddPage��5       N� 
Background
 ����  � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      ��  �� CornerRadius$ 30��6   ���#EFF2F7._�5   
   � -   5         �Name$ 	Container��5       � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5       ��   	topButton#��[ 6   $
��Left=�6<   $��
20 28 0 35q�6W   .��5!      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�6,   $��15��68   $��15��6C   5"      �� 5$      $��1��6   ���#409EA4$ 	0 50 0 30��6;   ._�5%      ]� .+�5'      �� $��80��6!   $��80��6,    �� Padding$ 3q�68   
�������$	 100��6W   $	��Top=�6j   $
��Left=�6   $��
20 -30 0 0q�6�   ._�5(      A� ��5)   "   �� 5*   &   	 �� ImageSource$	 /front/images/p1.jpg��61   5,      5-      �� 50      $��Kokou's World��6$   
�������$��22(�6L   $��SemiBold"�6Z   $	��Top=�6p   $��	5 25 0 10q�6�   
 �� TextAlignment$
 Center=�6�   �� 51      $��Humain, Sénégal��6$   ���#C1EDEF$��14(�6P   $��SemiBold"�6^   $	��Top=�6t   $
 Center=�6�   �� 54      $��25q�6$   ���#409EA4$	��Top=�6E   $	��0.8��6Z   �� 57      $	��Top=�6%   .+�58      �� -   5         ��Name$ 	btnModule��58   %     
menuButton#��[ 68   .��59   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5:   &     $ ClipboardCheckMultiple=�6<     menuButtonIcon#��[ 6Z   �� 5;   &   $��Modules��60   5<   #   5=      �� 5?      -   5        $ btnCours��5?   %   #��[ 67   .��5@   "   �� $ 
Horizontal=�6-   .+�5A   &     $ CalendarClock=�6<   #��[ 6Q   �� 5B   &   $��Cours��60   5C   #   5D      �� 5F      -   5        $ btnProfesseur��5F   %   #��[ 6<   .��5G   "   �� $ 
Horizontal=�6-   .+�5H   &     $ AccountMultipleOutline=�6<   #��[ 6Z   �� 5I   &   $��Professeurs��60   5J   #   5K      �� 5M      -   5        $ 	btnClasse��5M   %   #��[ 68   ���#4EB1B6
�������.��5N   "   �� $ 
Horizontal=�6-   .+�5O   &     $ GoogleClassroom=�6<   #��[ 6S   �� 5P   &   $��Classes��60   5Q   #   5R      �� 5T      -   5        $ btnSalle��5T   %   #��[ 67   .��5U   "   �� $ 
Horizontal=�6-   .+�5V   &     $
 Home=�6<   #��[ 6H   �� 5W   &   $��Salles��60   5X   #   5Y      5[      �� 5]      -   5        $ 	btnLogout��5]   !   #��[ 64   $��Bottom=�6X   $��Bottom=�6s   $��
15 0 15 20q�6�   .��5^      �� $ 
Horizontal=�6)   .+�5_   "     $ Logout=�68   #��[ 6F   �� 5`   "   $��Logout��6,   5a      5b      5d      5e      5g      � 5j      $��1��6   $��30,20,13,20q�6#    5k      �� 5l      $
��auto �6$   �� 5m      $
��auto �6$   �� 5n      $
��auto �6$   �� 5o      $
��auto �6$   �� 5p      $
��auto �6$   �� 5q      $��* �6$   �� 5r      $
��auto �6$   .+�5v      � $	��300��6   $
��Left=�6#   .+�5w      �� $
��20 0q�6    $��Center=�6.   ���#B0B9C6 J� IsHitTestVisible .   K� ZIndex$ 1��5x      $��Search here ...��6!   y�5y      ��  �� ElementName$ textBoxSearch�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5{      -   5        $��textBoxSearch��5{        searchTextbox#��[ 63     5}      $ Magnify=�6,   $��15��6;   $��15��6F   $��Center=�6R   $��0 0 15 0q�6m   ���#B0B9C6$��Right=�6�   5~      �� 5�      #��[ 6   $��0 0 35 0q�6<   ���#dcdcdc.��5�        $	 Cog=�6,   5�      �� 5�      #��[ 6   $��0 0 70 0q�6<   .��5�        $
 Bell=�6,   5�      �� 5�      -	   5        $%��../../../front/images/close.png��5�      $��0 14 0 0q�6A   $ 1��6T     imgClose#��[ 6}   �� 5�      $��Ajout de Classe��6   $��1��63   $��32(�6@   $��SemiBold"�6N   $��0 20 0 0q�6d   ���#121518$
��Left=�6�   �� 5�      $��1��6   $��3��6'   ���#DAE2EA$��	0 -1 0 10q�6I   �� 5�      
�������$ 10��6,   $	��680��6>   
�������$��1q�6a   $��5��6u   $��34,33,130,40q�6�   ._�5�      � $��0,0,0,-1q�6    5�      �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   .+�5�      �� $��0��6%   $��50��62   $��0,20,0,0q�6>   $ 
Horizontal=�6P   
�������.+�5�      �� $
��Wrap=�6(   $��20 0 0 0q�6<   $��18(�6N   $��Niveau ��6\   $	��148��6k   $��34��6w   �� 5�      -
   5         ��Name$ 	cboNiveau��5�   '    �� Text$ Sélectionner un niveau��6:   $	��460��6X   $��30��6d    �� 
IsEditable .  �� 
IsReadOnly . $��Center=�6�   $��18(�6�   $��10 0 0 0q�6�   5�      �� 5�      $��1��6%   $��50��62   $��0,0,0,0q�6>   $ 
Horizontal=�6O   
�������.+�5�      �� $
��Wrap=�6(   $��20 0 0 0q�6<   $��18(�6N   $��Filiere ��6\   $	��148��6l   $��34��6x   �� 5�      -   5        $ 
cboFiliere��5�   '   $  Sélectionner une filière��6;   $	��460��6[   $��30��6g    .  . $��Center=�6�   $��18(�6�   $��10 0 0 0q�6�   5�      �� 5�      $��2��6%   $��50��62   $��0,0,0,0q�6>   $ 
Horizontal=�6O   
�������.+�5�      �� $
��Wrap=�6(   $��20 0 0 0q�6<   $��18(�6N   $��Libelle ��6\   $	��148��6l   $��34��6x   �� 5�      -   5         ��Name$ 
txtLibelle��5�   &   $	��460��6:   $��30��6F   $��10 0 0 0q�6S   $��Center=�6f   $��18(�6�   5�      �� 5�      $��3��6%   $��50��62   $��0,0,0,0q�6>   $ 
Horizontal=�6O   
�������.+�5�      �� $
��Wrap=�6(   $��20 0 0 0q�6<   $��18(�6N   $��	Effectif ��6\   $	��148��6m   $��34��6y   �� 5�      -   5        $ txtEffectif��5�   &   $	��460��6<   $��30��6H   $��10 0 0 0q�6U   $��Center=�6h   $��18(�6�   5�      �� 5�      $��4��6%   $	��150��62   $��	0,10,42,0q�6?   $ 
Horizontal=�6R   
�������.+�5�      �� $
��Wrap=�6(   $��20 0 0 0q�6<   $��18(�6N   $��Modules ��6\   $	��148��6l   $��34��6x   �� 5�      -   5        $��lbModule��5�   2   $	��460��6&    �� SelectionMode$ Multiple=�6B   $	��150��6[   5�      �� 5�      $��5��6%   $��50��62   $��	0,10,48,0q�6>   $ 
Horizontal=�6Q   $��Right=�6j   
�������.+�5�      �� -   5        $ btnEnregistrer��5�   %   $��Enregistrer��6=     Enregistrer#��[ 6S   5�      5�      5�      5�      5�      5�      5�      