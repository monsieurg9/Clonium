   M S B A M L   `   `   `  ����E  AClonium.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Clonium.UI
Clonium.UI  5   	       Clonium.UI.NewGameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Clonium.UI     5   	   -   5          �Name$  
NewGameWin��5   	    � Title$ Новая игра��5   	   $	��450��6   $	��550��6)    � WindowStyle$ 
ToolWindow=�65    � WindowStartupLocation$ CenterScreen=�6N   .��5	      � .+�5
   
   �� $)��#Количество игроков��6   $
��Left=�6-   $��30��6H   $��
66,103,0,0q�6T   $	��Top=�6h   $	��127��6�   �� 5   
   -   5         ��Name$ cbxPlayerCount��5      $
��Left=�6+   $��30��6F   $��248,103,0,0q�6R   $	��Top=�6g   $	��153��6   
���������5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 1Q�61   5      5      �� 5   
   $&�� Время хода игрока��6   $
��Left=�6,   $��28��6G   $��
66,174,0,0q�6S   $	��Top=�6g   $	��127��6   �� 5   
   -   5        $ cbxTimerSetting��5      $
��Left=�6,   $��28��6G   $��248,174,0,0q�6S   $	��Top=�6h   $	��153��6�   
���������5      �� 5      $	 0,1&�6&   $	 0,0&�65   .��5      � $ 	#FFF0F0F0��6#   $ 0Q�65   � 5      $ White��6#   $ 1Q�61   5      5      �� 5   
   -   5        	 ��Name$	 btnStart��5      $��Начать игру��6#   $
��Left=�69   $��40��6T   $��179,317,0,0q�6`   $	��Top=�6u   $	��143��6�   6�   5      5      