   M S B A M L   `   `   `  ����?  ;Exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Exam.front.viewsExam.front.views  5   	       Exam.front.views.FormView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Exam.front.views     5   	     � Title$  FormView��5   	   
�������.��5
      ��  �� CornerRadius$ 30��6   ���#EFF2F7 �� Padding$ 20q�64   ._�5   
   �  � RowDefinitions 5      �� 5      $	��110 �6    �� 5      $	��200 �6    �� 5      $	��120 �6    �� 5      $��* �6    .+�5      � $��0��6    5      �� 5      $��* �6$   .+�5      �� $��Client��6   $��0��6+   .��5      �  5      �� 5   "   $��* �60   �� 5   "   $��* �60   .+�5      �� $
��Wrap=�6$   $��0��68   $��20 0 0 0q�6E   $��Télephone :��6W   $��18(�6j   $��Times new roman)�6x   $��20��6�   �� 5      -   5         ��Name$ txtPortable��5   "   $��0��68   
�������$��
20 0 200 0q�6\   $	��260��6p   $��30��6|   $��10 0 0 0q�6�   $��Center=�6�   $��18(�6�   �� 5      $
��Wrap=�6$   $��1��68   $��20 0 0 0q�6E   $��Nom :��6W   $��18(�6d   $��Times new roman)�6r   $��20��6�   �� 5       -   5         ��Name$ txtNom��5    $   $�� ��64   $��1��6=   
�������$��
-150,0,0,0q�6a   $	��260��6u   $��30��6�    �� Padding$ 10 0 0 0q�6�   $��20(�6�   �� 5!      $
��Wrap=�6$   $��1��68   $��	380 0 0 0q�6E   $��Prenom :��6X   $��18(�6h   $��Times new roman)�6v   $��20��6�   �� 5"      -   5        $ 	txtPrenom��5"   $   $�� ��67   $��1��6@   
�������$��	450 0 0 0q�6d   $	��260��6w   $��30��6�   $ 10 0 0 0q�6�   $��20(�6�   5$      5%      5'      � 5)      $��1��6    5*      �� 5+      $��* �6$   .+�5-      �� $��Article��6   $��0��6,   $��0 20 0 0q�69   .��5.      �  5/      �� 50      $��* �6,   �� 51      $��* �6,   �� 52      $��* �6,   .+�54      �� $
��Wrap=�6$   $��0��68   $��20 0 0 0q�6E   $��Ref :��6W   $��18(�6d   $��Times new roman)�6r   $��20��6�   �� 55      -   5        $ txtReference��55   "   $��0��69   
�������$��-180 0 200 0q�6]   $	��100��6s   $��30��6   $��10 0 0 0q�6�   $��Center=�6�   $��18(�6�   �� 56      $
��Wrap=�6$   $��0��68   $��	300 0 0 0q�6E   $��Prix :��6X   $��18(�6f   $��Times new roman)�6t   $��20��6�   �� 57      -   5        $ txtPrix��57   $   $��0��66   
�������$��370 0 200 0q�6Z   $	��200��6o   $��30��6{   $ 10 0 0 0q�6�   $��20(�6�   �� 58      $
��Wrap=�6$   $��1��68   $��20 0 0 0q�6E   $��Nom :��6W   $��18(�6d   $��Times new roman)�6r   $��20��6�   �� 59      -   5        $ 
txtLibelle��59   $   $�� ��68   $��1��6A   
�������$��
20 0 200 0q�6e   $	��260��6y   $��30��6�   $ 10 0 0 0q�6�   $��20(�6�   �� 5:      $
��Wrap=�6$   $��1��68   $��	380 0 0 0q�6E   $��
QteStock :��6X   $��18(�6j   $��Times new roman)�6x   $��20��6�   �� 5;      -   5        $ txtQteStock��5;   $   $�� ��69   $��1��6B   
�������$��	450 0 0 0q�6f   $	��260��6y   $��30��6�   $ 10 0 0 0q�6�   $��20(�6�   �� 5<      $
��Wrap=�6$   $��2��68   $��20 0 0 0q�6E   $��
Qte Cmde :��6W   $��18(�6i   $��Times new roman)�6w   $��20��6�   �� 5=      -   5        $ 	txtQteCmd��5=   "   $�� ��65   $��2��6>   
�������$��
20 0 200 0q�6b   $	��200��6v   $��30��6�   $��10 0 0 0q�6�   $��20(�6�   �� 5>      -	   5         ��Name$ btnAdd��5>   /   $	��Add��6!   {�.  $
��Left=�6Q   $��
484,10,0,0q�6l   $��2��6�   
��� � �$	��Top=�6�   $	��120��6�   
�������$��20(�6�   $��40��6�   5@      5A      5C      &   System.Windows.Controls.DataGrid  5D      -
   5          Name$ 	dgArticle��5D   $   $��2��6   6$   � 5F      $��3��6    5G      �� 5H      $��* �6'   �� 5I      $��* �6'   .+�5K      �� $
��Wrap=�6$   $��0��68   $��20 0 0 0q�6E   $��Total :��6W   $	�� 18(�6f   $��Times new roman)�6u   $��20��6�   �� 5L      -   5        $ txtTotal��5L   $   $��0��67   
�������$�� ��6[   $��
-200 0 0 0q�6c   $	��100��6w   $��30��6�   $ 10 0 0 0q�6�   
���  ��$��20(�6�   �� 5M      -   5        $ btnEnregistrer��5M   E   $��Enregistrer��6   {�.  $
��Left=�6]   $��
484,10,0,0q�6x   $��2��6�   
��� � �$	��Top=�6�   $	��120��6�   
�������$��20(�6�   $��40��6�   5O      5P      5Q      5R      