   M S B A M L   `   `   `  ����H  DGestion_Cours, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gestion_Cours.front.viewsGestion_Cours.front.views  5      .    (Gestion_Cours.front.views.page.LoginPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Gestion_Cours.front.views     5        N� Title$  	LoginPage��5	       N� 
Background
 ���� .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5        $��../../../Images/close.png��5      $��1��63    K� ZIndex$ 1��6C      imgClose#��[  6l   �� 5   
    �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #3AA9AD��6#    � Offset$ 0Q�63   � 5      $ #3AADA1��6#   $ 1Q�63   5      ._�5      � .+�5      �� .+�5      � 	 � Points	 �    -1��� ;X�����#4EB1B66:   � 5      '	 �    �� �� ���� ��
�����#4EB1B66?   A� 5       $��250 450 0 0q�6   $��40��63   $��40��6>   ���#4EB1B66J   A� 5!      $��
50 400 0 0q�6   $��20��62   $��20��6=   ���#4EB1B66I   5"      �� 5$      $��Center=�6   .+�5%      �� $��	Bienvenue��6      	TitleText#��[ 61   �� 5&      $>��8Profitez du moment présent avec nous. The Kokou's world��6    
 J� Opacity$	
 0.8Q�6_   $��20 30 20 30q�6m     
NormalText#��[ 6�   �� 5'      $��
Découvrir��6    
 button#��[ 61   5(      5)      5*      �� 5,   
   ���#FFFFFF$��1��6&   $ 	0 10 10 0��66   ._�5-      �� $��Center=�6   .+�5.      �� $��	Connexion��6   ���#3AB19B#��[ 6B   �� 5/       �� Orientation$ 
Horizontal=�6   $
��0 20q�66   $��Center=�6D   .+�50      ��   buttonCircle#��[ 6   .��51      �� $ ��../../../Images/google.png��6    $��20��6D   $��20��6O   52      �� 53      #��[ 6   .��54      �� $%��../../../../Images/facebook.png��6    $��20��6I   $��20��6T   55      �� 56      #��[ 6   .��57      �� $"��../../../Images/linkedin.png��6    $��20��6F   $��20��6Q   58      59      �� 5;      $.��(utilisez vos informations de connexion :��6   $��	0 10 0 15q�6L   ���#878787#��[ 6t   �� 5=      ���#ACB0AF$��1q�6/   $
��70 7q�6C   $ 5��6Q   ._�5>      � $	��7 9q�6    5?      �� 5@      $
��auto �6/   �� 5A      $��* �6/   .+�5D      �� $��../../../Images/Email.png��6    $��20��6C   �� 5E      -   5         ��Name$ 	textEmail��5E   $   $��Email��6W     textHint#��[ 6d   �� 5F      -   5        $��txtEmail��5F   "     textBox#��[ 6U   5G      5H      �� 5J      ���#ACB0AF$��1q�6/   $
��70 7q�6C   $ 5��6Q   ._�5K      � $	��7 9q�6    5L      �� 5M      $
��auto �6/   �� 5N      $��* �6/   .+�5Q      �� $��../../../Images/Lock.png��6    $��20��6B   �� 5R      -   5        $ textPassword��5R   $   $��Password��6]   #��[ 6m   G� 5S      -   5         G�Name$ passwordBox��5S   &   #��[ 6i   5T      5U      �� 5W      -   5        $��Se Connecter��5W        
mainButton#��[ 6E   5X      5Y      5[      5\      