   M S B A M L   `   `   `  ����g  cServiceForWorkingWithApartmentBuildingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:ServiceForWorkingWithApartmentBuildingClient,ServiceForWorkingWithApartmentBuildingClient  5   	   =    7ServiceForWorkingWithApartmentBuildingClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:ServiceForWorkingWithApartmentBuildingClient     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)    � 
ResizeMode$ NoResize=�65   ���#AB80AB � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �� .+�5   
   �� -   5         ��Name$# tbOpenManagementCompanyWindow��5      $��0,0,5,0q�6;   $��Right=�6L   $��11(�6h   ���	#F4FFEBFF$��	Underline{�6�   .,Мы управляющая компания5   �   �� 5   
   -   5         ��Name$ lblName��5      $��Center=�6!   $��20(�6>   $��0,30,0,0q�6L   
�������.��6u   Добрый день6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0,30,0,0q�6.   $��Center=�6@   .+�5      �� 
�������$��14(�6+   $��70��69   .��6E   	Имя:6K   �� 5      -   5         ��Name$ tblogin��5      $	��250��6'   $��23��63   6\   5      �� 5   
   $ 
Horizontal=�6   $��0,30,0,0q�6.   $��Center=�6@   .+�5      �� 
�������$��14(�6+   $��70��69   .��6E   Фамилия:6O   �� 5      -   5        $ 	tbSurname��5      $	��250��6)   $��23��65   6^   5      �� 5   
   $ 
Horizontal=�6   $��0,20,0,0q�6.   $��Center=�6@   .+�5      �� 
�������$��14(�6+   $��70��69   .��6D   Пароль:6M   G� 5      -   5         G�Name$ psbPass��5      $	��250��6+   $��23��67    G� 	MaxLength$ 64��6]   6n   5      �� 5   
   -   5        $ lblErrorAuthentification��5      $��	125,0,0,0q�62   $��25��6E   
�������$��10(�6k   6{   �� 5   
   -   5        	 ��Name$	 btnAuthentification��5      $��60��6.   $��25��69   $��0,15,0,0q�6E   .��6z   Ок6~   �� 5   
   -   5        $ lblOpenRegistration��5      
�������$��Center=�6G   .��6�   Регистрация5      5      5       