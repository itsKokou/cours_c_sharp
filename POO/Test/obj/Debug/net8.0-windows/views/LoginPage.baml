   M S B A M L   `   `   `  ����?  ;Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Test.views
Test.views  5          Test.views.LoginPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Test.views     5        N� Title$  	LoginPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5        $��./../Images/close.png��5      $��1��6/    K� ZIndex$ 1��6?      imgClose#��[  6h   �� 5   
    �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #3AA9AD��6#    � Offset$ 0Q�63   � 5      $ #3AADA1��6#   $ 1Q�63   5      ._�5      � .+�5      �� .+�5      �  � Points �    -1��� ;X�����#4EB1B66:   � 5      ' �    �� �� ���� ��
�����#4EB1B66?   A� 5      $��250 450 0 0q�6   $��40��63   $��40��6>   ���#4EB1B66J   A� 5       $��
50 400 0 0q�6   $��20��62   $��20��6=   ���#4EB1B66I   5!      �� 5#      $��Center=�6   .+�5$      �� $��	Bienvenue��6      	TitleText#��[ 61   �� 5%      $>��8Profitez du moment présent avec nous. The Kokou's world��6    	 J� Opacity$		 0.8Q�6_   $��20 30 20 30q�6m     
NormalText#��[ 6�   �� 5&      $��
Découvrir��6    
 button#��[ 61   5'      5(      5)      �� 5+   
   -   5        ���#FFFFFF$��1��5+   &   $ 	0 10 10 0��66   ._�5,      �� $��Center=�6   .+�5-      �� $��	Connexion��6   ���#3AB19B#��[ 6B   �� 5.      
 �� Orientation$
 
Horizontal=�6   $
��0 20q�66   $��Center=�6D   .+�5/      ��   buttonCircle#��[ 6   .��50      �� $��../Images/google.png��6    $��20��6>   $��20��6I   51      �� 52      #��[ 6   .��53      �� $��../Images/facebook.png��6    $��20��6@   $��20��6K   54      �� 55      #��[ 6   .��56      �� $��../Images/linkedin.png��6    $��20��6@   $��20��6K   57      58      �� 5:      $.��(utilisez vos informations de connexion :��6   $��	0 10 0 15q�6L   ���#878787#��[ 6t   �� 5<      ���#ACB0AF$��1q�6/   $
��70 7q�6C   $ 5��6Q   ._�5=      � $	��7 9q�6    5>      �� 5?      $
��auto �6/   �� 5@      $��* �6/   .+�5C      �� $��../Images/Email.png��6    $��20��6=   �� 5D      -   5         ��Name$ 	textEmail��5D   $   $��Email��6W     textHint#��[ 6d   �� 5E      -   5        $��txtEmail��5E   "     textBox#��[ 6U   5F      5G      �� 5I      ���#ACB0AF$��1q�6/   $
��70 7q�6C   $ 5��6Q   ._�5J      � $	��7 9q�6    5K      �� 5L      $
��auto �6/   �� 5M      $��* �6/   .+�5P      �� $��../Images/Lock.png��6    $��20��6<   �� 5Q      -   5        $ textPassword��5Q   $   $��Password��6]   #��[ 6m   G� 5R      -   5         G�Name$ passwordBox��5R   &   #��[ 6i   5S      5T      �� 5V      -   5        $��Se Connecter��5V        
mainButton#��[ 6E   5W      5X      5Z      5[      